using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MsftGps.MarketplaceAnalytics.Services;
using MsftGps.MarketplaceAnalytics.Schema;

namespace MsftGps.MarketplaceAnalytics
{
    public class Report
    {
        private readonly IAnalyticsService _analyticsService;
         
        public Report(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [FunctionName("RunReport")]
        public async Task<IActionResult> RunReport(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "runreport/{queryId}")] HttpRequest req, 
            string queryId, ILogger log)
        {
            bool isLocal = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID"));
            var urlBaseAddress = isLocal ? Environment.GetEnvironmentVariable("NGROK_URL") : Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME");

            // Note callback does not work for executenow reports (observed behavior)
            var report = new AnalyticsReport()
            {
                ReportName = $"query-{queryId}-report",
                QueryId = queryId,
                ExecuteNow = true,
                CallbackUrl = $"{urlBaseAddress}/api/reportcallback",
                CallbackMethod = "post"
            };

            return new HttpResponseMessageResult(await _analyticsService.CreateReport(report));
        }
       
       
        [FunctionName("DeleteReport")]
        public async Task<IActionResult> DeleteReport(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "report/{reportId}")] HttpRequest req, string reportId, ILogger log)
        {
             return new HttpResponseMessageResult(await _analyticsService.DeleteReport(reportId));
        }

        [FunctionName("ReportWebhook")]
        [return: Queue("report-execution", Connection = "AnalyticsQueueStorage")]
        public static string ReportWebhook(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "reportcallback/{reportId?}")] HttpRequest req,
            string? reportId,
            ILogger log)
        {
            // ToDo - secure this endpoint with some type of signature
            // put the report ID in a storage queue
            // don't block Analytics API webhook with additional Analytics API calls here
            return reportId!;
        }

        [FunctionName("GetReportData")]
        public async Task GetReportData([QueueTrigger("report-execution", Connection = "AnalyticsQueueStorage")]string myQueueItem, ILogger log)
        {
           
            var reportId = JsonConvert.DeserializeObject<string>(myQueueItem);

            var response = await _analyticsService.GetReportExecutions(reportId!);

            if (!response.IsSuccessStatusCode)
            {
                log.LogError($"Failed to retrieve report execution for report ID: {reportId}. Message: {response.RequestMessage}");
                return;
            }

            var analyticsResponse = await response.Content.ReadAsAsync<AnalyticsResponse<AnalyticsReportExecution>>();
            var reportExecution  = analyticsResponse.Value!.FirstOrDefault();
            
            var blobStorageUrl = reportExecution!.ReportAccessSecureLink;
            log.LogInformation($"Report url: {blobStorageUrl}");
            // Get the connection string from app settings and use it to create a connection.
            // var str = Environment.GetEnvironmentVariable("sqldb_connection");
            // using (SqlConnection conn = new SqlConnection(str))
            // {
            //     conn.Open();
            //     var text = "CreateReportRecord";

            //     using (SqlCommand cmd = new SqlCommand(text, conn))
            //     {
            //         // Find the report record in the DB

            //         // Update the report status 
            //         var rows = await cmd.ExecuteNonQueryAsync();
            //         log.LogInformation($"{rows} rows were updated");

            //         // Add rows to appropriate table
            //     }
           
        }

        [FunctionName("GetReport")]
        public async Task<IActionResult> GetReport(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "report/{reportId?}")] HttpRequest req, string? reportId, ILogger log)
        {
            if (reportId != null)
                return new HttpResponseMessageResult(await _analyticsService.GetReportById(reportId));

            HttpResponseMessage? response = null;    
            if (req.Query.Count == 0)
            {
                response = await _analyticsService.GetAllReports();           
            }
            else 
            {
                string? reportName = req.Query["reportName"];
                if (reportName != null)  
                {
                    if (reportName.Equals("system")) 
                        response = await _analyticsService.GetSystemQueries();   
                    else    
                        response = await _analyticsService.GetReportByName(reportName);
                }
                else 
                {
                    string? queryId = req.Query["queryId"];
                    if (queryId != null)  
                        response = await _analyticsService.GetReportByQueryId(queryId);
                }
                if (response == null)   
                    return new OkResult();
            }
            return new HttpResponseMessageResult(response);
        }
   

        [FunctionName("GetReportExecution")]
        public async Task<IActionResult> GetReportExecution(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "reportexecution/{reportId}")] HttpRequest req, string reportId, ILogger log)
        {
            return new HttpResponseMessageResult(await _analyticsService.GetReportExecutions(reportId));
        }
    }
}
