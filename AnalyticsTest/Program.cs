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

        public async Task Cleanup()
        {
            Debug.WriteLine("Cleaning up Analytics reports and queries");
            
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("report");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var reportResponse = await httpResponseMessage.Content.ReadFromJsonAsync<AnalyticsResponse<AnalyticsReport>>();
                reportResponse!.Value!.ToList().ForEach(async report =>
                {
                    httpResponseMessage = await _httpClient.DeleteAsync($"report/{report.ReportId}");
                    Debug.WriteLine($"Deleted report {report.ReportId}: {report.ReportName}");
                });
            }

            httpResponseMessage = await _httpClient.GetAsync("query");
            if (httpResponseMessage.IsSuccessStatusCode)
            { 
                var queryResponse= await httpResponseMessage.Content.ReadFromJsonAsync<AnalyticsResponse<AnalyticsQuery>>();
                queryResponse!.Value!.ToList().ForEach(async query =>
                {
                    httpResponseMessage = await _httpClient.DeleteAsync("report/{query.QueryId}");
                    Debug.WriteLine($"Deleted query {query.QueryId}: {query.Description}");
                });
            }
        }

        public async Task Run()
        {

            var cleanupTask = Cleanup();
            cleanupTask.Wait();     

            HttpResponseMessage httpResponseMessage;
            AnalyticsQuery? query;
            httpResponseMessage = await _httpClient.GetAsync("query?queryName=ISVCustomerLifetime");
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            { 
                query = new AnalyticsQuery()
                {
                    Name = "ISVCustomer",
                    Description = "All ISVCustomer Lifetime of DB",
                    Query = @"SELECT MarketplaceSubscriptionId,
                        DateAcquired,
                        DateLost,
                        IsActive,
                        ProviderName,
                        ProviderEmail,
                        FirstName,
                        LastName,
                        Email,
                        CustomerCompanyName,
                        CustomerCity,
                        CustomerPostalCode,
                        CustomerCommunicationCulture,
                        CustomerCountryRegion,
                        AzureLicenseType,
                        PromotionalCustomers,
                        CustomerState,
                        CommerceRootCustomer,
                        CustomerId,
                        BillingAccountId,
                        CustomerType,
                        OfferName,
                        PlanId,
                        SKU from ISVCustomer TIMESPAN LIFETIME"
                };

                httpResponseMessage = await _httpClient.PostAsJsonAsync<AnalyticsQuery>("query", query);
                query = await httpResponseMessage.Content.ReadFromJsonAsync<AnalyticsQuery>()!;
            }
            else
            {
                AnalyticsResponse<AnalyticsQuery>? queryResponse = await httpResponseMessage.Content.ReadFromJsonAsync<AnalyticsResponse<AnalyticsQuery>>();
                query = queryResponse!.Value!.FirstOrDefault(); 
            }
            httpResponseMessage = await _httpClient.PostAsync($"runreport/{query!.QueryId}", null);

         
        }
    }
}
