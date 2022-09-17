using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Identity.Client;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.WebUtilities;
using MsftGps.MarketplaceAnalytics.Services;
using MsftGps.MarketplaceAnalytics.Schema;

namespace MsftGps.MarketplaceAnalytics
{
    public class Query
    {
        private readonly IAnalyticsService _analyticsService;
         
        public Query(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [FunctionName("GetQuery")]
        public async Task<IActionResult> GetQuery(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "query/{queryId?}")] HttpRequest req, string? queryId, ILogger log)
        {
            if (queryId != null)
                return new HttpResponseMessageResult(await _analyticsService.GetQueryById(queryId));

            HttpResponseMessage response;    
            if (req.Query.Count == 0)
            {
                response = await _analyticsService.GetUserQueries();           
            }
            else 
            {
                string? queryName = req.Query["queryName"];
                if (queryName == null)
                    return new OkResult();
                if (queryName.Equals("system")) 
                    response = await _analyticsService.GetSystemQueries();   
                else
                    response = await _analyticsService.GetQueryByName(queryName);
            }
            return new HttpResponseMessageResult(response);
        }
        
        [FunctionName("CreateQuery")]
        public async Task<IActionResult> CreateQuery(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "query")] HttpRequest req, ILogger log)
        {
            var queryDefinition = JsonConvert.DeserializeObject<AnalyticsQuery>(await req.ReadAsStringAsync());
            return new HttpResponseMessageResult(await _analyticsService.CreateQuery(queryDefinition));
        }

        [FunctionName("DeleteQuery")]
        public async Task<IActionResult> DeleteQuery(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "query/{queryId}")] HttpRequest req, string queryId, ILogger log)
        {
            return new HttpResponseMessageResult(await _analyticsService.DeleteQuery(queryId));
        }

        [FunctionName("TryQuery")]
        public async Task<IActionResult> TryQuery(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "tryquery/{queryId}")] HttpRequest req, string queryId, ILogger log)
        {
            var queryText = req.Query["queryText"];
            return new HttpResponseMessageResult(await _analyticsService.TryQuery(queryId, queryText));
        }
    }
}
