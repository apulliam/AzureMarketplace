using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Identity.Client;
using MsftGps.MarketplaceAnalytics.Services;

namespace MsftGps.MarketplaceAnalytics
{
    // Class to support testing during development
    public class Test
    {
        private readonly IAnalyticsService _analyticsService;
        public Test(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        // This function returns a bearer token which can be used for testing HTTP functions using VSCode REST tools
        [FunctionName("Test")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "token")] HttpRequest req,
            ILogger log)
        {
            var analyticsService = _analyticsService as AnalyticsService;
            return new OkObjectResult(analyticsService != null ? await analyticsService.GetAccessToken() : null);
        }
    }
}
