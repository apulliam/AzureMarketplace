using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Identity.Client;
using MsftGps.MarketplaceAnalytics.Schema;
using Newtonsoft.Json;

namespace MsftGps.MarketplaceAnalytics.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfidentialClientApplication _confidentialClientApplication;

        public AnalyticsService(IHttpClientFactory httpClientFactory, IConfidentialClientApplication confidentialClientApplication)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://api.partnercenter.microsoft.com/insights/v1/cmp/");
            _confidentialClientApplication = confidentialClientApplication;
        }

        internal async Task<string> GetAccessToken()
        {
                var token =  await _confidentialClientApplication.AcquireTokenForClient(scopes: new[] { "https://graph.windows.net/.default" })        // uses the token cache automatically, which is optimized for multi-tenant access
                           .WithAuthority(AzureCloudInstance.AzurePublic, Environment.GetEnvironmentVariable("TenantId"))  // do not use "common" or "organizations"!
                           .ExecuteAsync();
                return token.AccessToken;
        }

        // Dataset API's
        public async Task<HttpResponseMessage> GetAllDatasets()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());
            var httpResponseMessage = await _httpClient.GetAsync("ScheduledDataset");
            // preserve original error response from the Analytics service                
            // if (!httpResponseMessage.IsSuccessStatusCode)
            // {
            //     string message;
            //     try
            //     {
            //         message = await httpResponseMessage.Content.ReadAsStringAsync();
            //     }
            //     catch
            //     {
            //         message = httpResponseMessage.ReasonPhrase!;
            //     }

            //     throw new HttpRequestException(message,null,httpResponseMessage.StatusCode);
            // }
            // return await httpResponseMessage.Content.ReadAsAsync<AnalyticsResponse<AnalyticsDataset>>();
            return httpResponseMessage;
        }

        // Query API's
        public async Task<HttpResponseMessage> GetQueryById(string queryId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());
            return await _httpClient.GetAsync($"ScheduledQueries?queryId={queryId}");
        }
        public async Task<HttpResponseMessage> GetQueryByName(string queryName)
        {
             _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());;
            return await _httpClient.GetAsync($"ScheduledQueries?queryName={queryName}");
        }

        public async Task<HttpResponseMessage> GetSystemQueries()
        {
             _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());;
            return await _httpClient.GetAsync($"ScheduledQueries?includeOnlySystemQueries=true");
        }

        public async Task<HttpResponseMessage> GetUserQueries()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());
            return await _httpClient.GetAsync("ScheduledQueries?includeSystemQueries=false");
        }

        public async Task<HttpResponseMessage> GetAllQueries()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());
            return await _httpClient.GetAsync("ScheduledQueries?includeSystemQueries=true");
        }

        public async Task<HttpResponseMessage> CreateQuery(AnalyticsQuery queryDefinition)
        {
            string content = JsonConvert.SerializeObject(queryDefinition, 
            new JsonSerializerSettings()
            {
                //ContractResolver = new CamelCasePropertyNamesContractResolver(), // switch from C# convention to JSON convention
                NullValueHandling = NullValueHandling.Ignore // API's don't like null values for entity creation
            });

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());
            return await _httpClient.PostAsync("ScheduledQueries", stringContent);
        }

        public async Task<HttpResponseMessage> DeleteQuery(string queryId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());
            return await _httpClient.DeleteAsync($"ScheduledQueries/{queryId}");
        }

        public async Task<HttpResponseMessage> TryQuery(string queryId, string? queryText)
        {
            var url = "ScheduledQueries/testQueryResult";
            url = QueryHelpers.AddQueryString(url,"queryId", queryId);
            if (queryText != null)
                url = QueryHelpers.AddQueryString(url,"exportQuery", queryText);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());;
            return await _httpClient.GetAsync(url);
        }

        // Report API's
        public async Task<HttpResponseMessage> CreateReport(AnalyticsReport report)
        {
            string content = JsonConvert.SerializeObject(report, 
            new JsonSerializerSettings()
            {
                //ContractResolver = new CamelCasePropertyNamesContractResolver(), // switch from C# convention to JSON convention
                NullValueHandling = NullValueHandling.Ignore // API's don't like null values for entity creation
            });

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("ScheduledReport", stringContent);
        }

        public async Task<HttpResponseMessage> UpdateReport(AnalyticsReport report)
        {
            string content = JsonConvert.SerializeObject(report, 
            new JsonSerializerSettings()
            {
                //ContractResolver = new CamelCasePropertyNamesContractResolver(), // switch from C# convention to JSON convention
                NullValueHandling = NullValueHandling.Ignore // API's don't like null values for entity creation
            });

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync($"ScheduledReport/{report.ReportId}", stringContent);
        }

        public async Task<HttpResponseMessage> DeleteReport(string reportId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());
            return await _httpClient.DeleteAsync($"ScheduledReport/{reportId}");
        }

        public async Task<HttpResponseMessage> GetReportExecutions(string reportId, string? reportStatus = null)
        {
            var url = $"ScheduledReport/execution/{reportId}";
            
            //url = QueryHelpers.AddQueryString(url,"executionStatus", "Pending, Running, Completed");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());
            return await _httpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> GetReportById(string reportId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());
            return await _httpClient.GetAsync($"ScheduledReport?reportId={reportId}");
        }

        public async Task<HttpResponseMessage> GetReportByName(string reportName)
        {
             _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());;
            return await _httpClient.GetAsync($"ScheduledReport?reportName={reportName}");
        }

        public async Task<HttpResponseMessage> GetReportByQueryId(string queryId)
        {
             _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());;
            return await _httpClient.GetAsync($"ScheduledReport?queryId={queryId}");
        }

        public async Task<HttpResponseMessage> GetAllReports()
        {
             _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());;
            return await _httpClient.GetAsync($"ScheduledReport");
        }

    }
}