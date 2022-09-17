namespace MsftGps.MarketplaceAnalytics.Schema
{
    public class AnalyticsResponse<T> where T : IAnalyticsResponseContent
    {
        // values specific to API's - to be deserialized later
        public T[]? Value { get; set; }
        public int TotalCount { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
    }
}