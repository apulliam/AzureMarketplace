using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MsftGps.MarketplaceAnalytics.Services;

namespace MsftGps.MarketplaceAnalytics
{
    public class Dataset
    {
        private readonly IAnalyticsService _analyticsService;

        public Dataset(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [FunctionName("GetDataset")]
        public async Task<IActionResult> GetDataset(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "dataset")] HttpRequest req, ILogger log)
        {
            // try
            // {
            return new HttpResponseMessageResult(await _analyticsService.GetAllDatasets());
            // }
            // catch (HttpRequestException ex)
            // {
            //     return new OkResult();
            // }
        }
    }
}
