namespace MsftGps.MarketplaceAnalytics.Schema
{
    // Class used to create a custom requery with Azure Marketplace Analytics CreateQuery API
    public class AnalyticsQuery : IAnalyticsResponseContent
    {
        public string? QueryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Query { get; set; }
    }
}