namespace MsftGps.MarketplaceAnalytics.Schema
{
    public class AnalyticsReportExecution : IAnalyticsResponseContent
    {
        public string? ExecutionId { get; set; }
        public string? ReportId { get; set; }
        public int RecurrenceInterval { get; set; }
        public int RecurrenceCount { get; set; }
        public string? CallbackUrl { get; set; }
        public string? CallbackMethod { get; set; }
        public string? Format { get; set; }
        public string? ExecutionStatus { get; set; }
        public string? ReportLocation { get; set; }
        public string? ReportAccessSecureLink { get; set; }
        public string? ReportExpiryTime { get; set; }
        public DateTime ReportGeneratedTime { get; set; }
    }
}