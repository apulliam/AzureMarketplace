using System.Net.Http.Headers;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Identity.Client;
using MsftGps.MarketplaceAnalytics.Schema;

namespace MsftGps.MarketplaceAnalytics.Services
{
    // Usually a service would return actual data types but here we are 
    // passing through HttpResponeMessage to preserve underlying error messages and correlation ID's
    public interface IAnalyticsService
    {
        public Task<HttpResponseMessage> GetAllDatasets();

        public Task<HttpResponseMessage> GetUserQueries();

        public Task<HttpResponseMessage> GetAllQueries();
       
        public Task<HttpResponseMessage> GetQueryById(string queryId);

        public Task<HttpResponseMessage> GetQueryByName(string queryName);

        public Task<HttpResponseMessage> GetSystemQueries();

        public Task<HttpResponseMessage> CreateQuery(AnalyticsQuery query);

        public Task<HttpResponseMessage> DeleteQuery(string queryId);

        public Task<HttpResponseMessage> TryQuery(string queryId, string queryText);

        public Task<HttpResponseMessage> CreateReport(AnalyticsReport report);
        
        public Task<HttpResponseMessage> UpdateReport(AnalyticsReport report);

        public Task<HttpResponseMessage> DeleteReport(string reportId);
        
        public Task<HttpResponseMessage> GetReportExecutions(string reportId, string? status = null);

        public Task<HttpResponseMessage> GetAllReports();
       
        public Task<HttpResponseMessage> GetReportById(string reportId);

        public Task<HttpResponseMessage> GetReportByName(string reportName);

        public Task<HttpResponseMessage> GetReportByQueryId(string queryId);

    }
}