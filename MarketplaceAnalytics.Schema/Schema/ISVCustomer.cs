namespace MsftGps.MarketplaceAnalytics.Schema
{
    public class ISVCustomer
    {
        // The unique identifier associated with the Azure subscription the customer used to purchase your commercial marketplace offer.
        // For infrastructure offers, this is the customer's Azure subscription GUID. For SaaS offers, this is shown as zeros since SaaS
        // purchases do not require an Azure subscription
        public string? MarketplaceSubscriptionId { get; set; }

        // The first date the customer purchased any offer you published.
        public DateTime DateAcquired { get; set; }

        // The last date the customer canceled the last of all previously purchased offers
        public DateTime DateLost { get; set; }
        
        public string? IsActive { get; set; }

        // The name of the provider involved in the relationship between Microsoft and the customer.
        // If the customer is an Enterprise through Reseller, this will be the reseller.
        // If a Cloud Solution Provider (CSP) is involved, this will be the CSP
        public string? ProviderName { get; set; }
        
        // The email address of the provider involved in the relationship between Microsoft and the customer.
        // If the customer is an Enterprise through Reseller, this will be the reseller. If a Cloud Solution Provider (CSP) is involved, this will be the CSP.
        public string? ProviderEmail { get; set; }
        
        // The first name provided by the customer. Name could be different than the name provided in a customer's Azure subscription.
        public string? FirstName { get; set; }
        
        // The last name provided by the customer. Name could be different than the name provided in a customer's Azure subscription.
        public string? LastName { get; set; }
        
        // The e-mail address provided by the end customer. Email could be different than the e-mail address in a customer's Azure subscription.
        public string? Email { get; set; }
        
        // The company name provided by the customer. Name could be different than the city in a customer's Azure subscription.
        public string? CustomerCompanyName { get; set; }
        
        // The city name provided by the customer. City could be different than the city in a customer's Azure subscription.
        public string? CustomerCity { get; set; }
        
        // The postal code provided by the customer. Code could be different than the postal code provided in a customer's Azure subscription.
        public string? CustomerPostalCode { get; set; }
        
        // The language preferred by the customer for communication.
        public string? CustomerCommunicationCulture { get; set; }
        
        // The country/region name provided by the customer. 
        // Country/region could be different than the country/region in a customer's Azure subscription.
        public string? CustomerCountryRegion { get; set; }
        
        // The type of licensing agreement used by customers to purchase Azure. Also known as the channel. The possible values are:
        // - Cloud Solution Provider
        // - Enterprise
        // - Enterprise through Reseller
        // - Pay as You Go
        public string? AzureLicenseType { get; set; }
        
        // The value will let you know if the customer proactively opted in for promotional contact from publishers.
        // At this time, we are not presenting the option to customers, so we have indicated "No" across the board. 
        // After this feature is deployed, we will start updating accordingly.
        public string? PromotionalCustomers { get; set; }
        
        // The state of residence provided by the customer. State could be different than the state provided in a customer's Azure subscription.
        public string? CustomerState { get; set; }
        
        // One Billing Account ID can be associated with multiple Customer IDs.
        // One combination of a Billing Account ID and a Customer ID can be associated with multiple commercial marketplace subscriptions.
        // The Commerce Root Customer signifies the name of the subscription’s customer.
        public string? CommerceRootCustomer { get; set; }
        
        // The unique identifier assigned to a customer. A customer may have zero or more Azure Marketplace subscriptions.
        public string? CustomerId { get; set; }

        // The identifier of the account on which billing is generated. Map Billing Account ID to customerID to connect your Payout Transaction Report with the Customer, Order, and Usage Reports.
        public string? BillingAccountId { get; set; }
        
        // The value of this field signifies the type of the customer. The possible values are:
        // - individual
        // - organization
        public string? CustomerType { get; set; }
        
        // The name of the commercial marketplace offer
        public string? OfferName { get; set; }
        
        // The display name of the plan entered when the offer was created in Partner Center
        public string? PlanId { get; set; }
        
        // The plan associated with the offer
        public string? SKU { get; set; }
    }
}