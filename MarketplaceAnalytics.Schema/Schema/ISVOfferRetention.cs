
namespace MsftGps.MarketplaceAnalytics.Schema
{
    public class ISVOfferRetention
    {
        // Azure Marketplace category for the offer
        public string? OfferCategory { get; set; }
        
        // The name of the commercial marketplace offer.
        public string? OfferName { get; set; }
        
        // Unique identifier for the offer in the marketplace
        public string? ProductId { get; set; }
        
        // The plan associated with the offer.
        public string? Sku { get; set; }
 
        // Indicates offer has a free or paid plan	
        public string? SkuBillingType { get; set; }
 
        // The unique identifier assigned to a customer. A customer may have zero or more Azure Marketplace subscriptions
         public string? CustomerId { get; set; }
 
        // Name of the customer using the offer
         public string? CustomerName { get; set; }
 
        // The company name provided by the customer. The name could be different than the name in a customer's Azure subscription.
        public string? CustomerCompanyName { get; set; }
 
        // The country/region name provided by the customer. Country/region could be different than the country/region in a customer's Azure subscription.
        public string? CustomerCountryName { get; set; }
 
        // Unique code associated with customer country
        public string? CustomerCountryCode { get; set; }
 
        // Unique code associated with the currency used by the customer for the usage transaction.
        public string? CustomerCurrencyCode { get; set; }
 
        // Calendar date when the customer first started using the offer
        public DateTime FirstUsageDate { get; set; }
 
        // The type of licensing agreement used by customers to purchase offers. Also known as the channel. The possible values are:
        // Cloud Solution Provider
        // Enterprise
        // Enterprise through Reseller
        // Pay as You Go
        public string? AzureLicenseType { get; set; }
 
        // =Indicates the available offer types listed in the marketplace
        public string? OfferType { get; set; }
 
        // Days from First Usage	Days from First Usage	Number of days since the customer first started using the offer
        public string? Offset { get; set; }
 
        // start of metrics (calculated columns)    

        // Total revenue accumulated up to days from first usage
        public string? RevenueGeneratedUSD { get; set; }
 
        // Revenue generated for the specific day value in the Days from first usage column
        public string? RevenueGeneratedPerDayUSD { get; set; } 

    }
}