namespace MsftGps.MarketplaceAnalytics.Schema
{
    public class ISVMaraketplaceInsights
    {
        // The date of page visit and/or CTA click event generation on the offer’s page in Azure Marketplace and/or AppSource.	
        public DateTime Date { get; set; }

        // The name of the commercial marketplace offering.	
        public string? OfferName { get; set; }

        // The name of the referral domain from where the page visit happened. If there are no referral domains captured for the page visit, then the corresponding entry is “Referral domain not present”.	
        public string? ReferralDomain { get; set; }

        // The name of the country from where the page visit has happened.	
        public string? CountryName { get; set; }
        
        // The number of page visits associated with the Offer Name for a particular date.	
        public string? PageVisits { get; set; }

        // The number of page visits associated with the Offer Name for a particular date.	
        public string? GetItNow { get; set; }
        
        // The number of clicks to the “Contact Me” CTA on the offer’s page for a particular date.	
        public string? ContactMe { get; set; }

        // The number of clicks to the “Test Drive” CTA on the offer’s page for a particular date.	
        public string? TestDrive { get; set; }
        
        // The number of clicks to the “Free Trial” CTA on the offer’s page for a particular date.	
        public string? FreeTrial { get; set; }
        
        // Total count of clicks for customer-provided consent to Microsoft or the partner	
        public string? ConsentGiven { get; set; }

        // The name of the storefront from which the page visit or CTA click occurred. The possible values are:
        // - AZUREMARKETPLACE
        // - APPSOURCE
        public string? Site { get; set; }

        // Ability to understand web telemetry (page visit and CTA clicks) against the campaign name.	
        public string? Campaign { get; set; }
    }
}