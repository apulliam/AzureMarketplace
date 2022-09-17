using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using MsftGps.MarketplaceAnalytics.Schema;
using Newtonsoft.Json.Linq;

namespace MsftGps.AnalyticsTest
{
    public class Program
    {
        private readonly HttpClient _httpClient;

        private Dictionary<string, string> QueryMap = new Dictionary<string, string>()
        {
            { "ISVCustomer", MarketplaceQueries.IsvCustomerSelectAll },
            { "ISVOrder", MarketplaceQueries.IsvOrderSelectAll },
            { "ISVUsage", MarketplaceQueries.IsvUsageSelectAll },
            { "ISVRevenue", MarketplaceQueries.IsvRevenueSelectAll },
            { "ISVMarketplaceInsights", MarketplaceQueries.IsvMarketplaceInsightsSelectAll },
            { "ISVOfferRetention", MarketplaceQueries.IsvOfferRetentionSelectAll },
            { "ISVQualityOfService", MarketplaceQueries.IsvQualityOfServiceSelectAll }
        };


        public Program()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:7072/api/")
            };
        }

        public async static Task Main(string[] args)
        {
            var program = new Program();
            await program.Run();
        }

        public async Task CleanupReports()
        {
            Debug.WriteLine("Cleaning up Analytics reports");

            var httpResponseMessage = await _httpClient.GetAsync("report");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var reportResponse = await httpResponseMessage.Content.ReadFromJsonAsync<AnalyticsResponse<AnalyticsReport>>();
                reportResponse!.Value!.ToList().ForEach(async report =>
                {
                    httpResponseMessage = await _httpClient.DeleteAsync($"report/{report.ReportId}");
                    Debug.WriteLine($"Deleted report {report.ReportName}");
                });
            }
        }

        public async Task CleanupQueries()
        {
             Debug.WriteLine("Cleaning up Analytics reports"); 

            var httpResponseMessage = await _httpClient.GetAsync("query");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var queryResponse = await httpResponseMessage.Content.ReadFromJsonAsync<AnalyticsResponse<AnalyticsQuery>>();
                queryResponse!.Value!.ToList().ForEach(async query =>
                {
                    httpResponseMessage = await _httpClient.DeleteAsync("report/{query.QueryId}");
                    Debug.WriteLine($"Deleted query {query.Name}");
                });
            }
        }

        public async Task RunReport(string datasetName, string timespan)
        {
            HttpResponseMessage httpResponseMessage;
            AnalyticsQuery? query;
            var queryName = $"{datasetName}{timespan}";
            httpResponseMessage = await _httpClient.GetAsync($"query?queryName={queryName}");
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Debug.WriteLine($"Query {queryName} not found");
                var selectAll = QueryMap[datasetName];

                query = new AnalyticsQuery()
                {
                    Name = $"{datasetName}{timespan}",
                    Description = $"All {datasetName} records for {timespan}",
                    Query = $"{selectAll} TIMESPAN {timespan}"
                };

                httpResponseMessage = await _httpClient.PostAsJsonAsync<AnalyticsQuery>("query", query);
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error creating query: {await httpResponseMessage.Content.ReadAsStringAsync()}");
                    return;
                }
                query = await httpResponseMessage.Content.ReadFromJsonAsync<AnalyticsQuery>()!;
                Debug.WriteLine($"Created new query {query!.Name}");
            }
            else
            {
                
                AnalyticsResponse<AnalyticsQuery>? queryResponse = await httpResponseMessage.Content.ReadFromJsonAsync<AnalyticsResponse<AnalyticsQuery>>();
                query = queryResponse!.Value!.FirstOrDefault();
                Debug.WriteLine($"Retrieved query {query!.Name}");
            }
            httpResponseMessage = await _httpClient.PostAsync($"runreport/{query!.QueryId}", null);
             if (!httpResponseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error running report: {await httpResponseMessage.Content.ReadAsStringAsync()}");
                return;
            }
            Debug.WriteLine($"Running report for query {query.Name}");

        }

        public async Task Run()
        {

            var cleanupTask = CleanupReports();
            cleanupTask.Wait();

            cleanupTask = CleanupQueries();
            cleanupTask.Wait();

            await RunReport("ISVOrder", "LIFETIME");
        }
    }
}
