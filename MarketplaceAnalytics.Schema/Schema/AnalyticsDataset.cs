namespace MsftGps.MarketplaceAnalytics.Schema
{
    // This class is used to submit a report job to the Marketplace Analytics CreateReport API
    // The same class is used for the Azure Functions facade and underlying native API
    public class AnalyticsDataset : IAnalyticsResponseContent
    {
        public string? DatasetName { get; set; }
        public string[]? SelectableColumns { get; set; }
        public string[]? AvailableMetrics { get; set; }
        public string[]? AvailableDateRanges { get; set; }
    }
}