namespace MsftGps.MarketplaceAnalytics.Schema
{
    // This class is used to submit a report job to the Marketplace Analytics CreateReport API
    // The same class is used for the Azure Functions facade and underlying native API
    public class AnalyticsReport : IAnalyticsResponseContent
    {
        public string? ReportId { get; set; }
        public string? ReportName { get; set; }
        public string? Description { get; set; }
        public string? QueryId { get; set; }
        public string? StartTime { get; set; }
        public int RecurrenceInterval { get; set; }
        public int RecurrenceCount { get; set; }
        public bool ExecuteNow { get; set;}
        public string? Format { get; set; }
        public string? CallbackUrl { get; set; }
        public string? CallbackMethod { get; set; }
    }
}