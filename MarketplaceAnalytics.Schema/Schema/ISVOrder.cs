namespace MsftGps.MarketplaceAnalytics.Schema
{
    public class ISVOrder
    {
        // The unique identifier associated with the Azure subscription the customer used to purchase your commercial marketplace offer. For infrastructure offers, this is the customer's Azure subscription GUID. For SaaS offers, this is shown as zeros since SaaS purchases do not require an Azure subscription.	
        public string? MarketplaceSubscriptionId { get; set; }
        
        // Month Start Date represents month of Purchase. The format is yyyy-mm-dd.	
        public DateTime MonthStartDate { get; set; }
        
        // The type of commercial marketplace offering.	
        public string? OfferType { get; set; }
        
        // The type of licensing agreement used by customers to purchase Azure. Also known as Channel. The possible values are:
        //      Cloud Solution Provider
        //      Enterprise
        //      Enterprise through Reseller
        //      Pay as You Go
        //      GTM
        public string? AzureLicenseType { get; set; }
        
        // The billing method of the commercial marketplace offer. The possible values are:
        //      Billed through Azure
        //      Bring Your Own License
        //      Free
        //      Microsoft as Reseller
        public string? MarketplaceLicenseType { get; set; }
        
        // The plan associated with the offer
        public string? SKU { get; set; }
        
        // The country/region name provided by the customer. Country/region could be different than the country/region in a customer's Azure subscription.
        public string? CustomerCountry { get; set; }
    
        // The value will let you know if you tagged the SKU as "preview". Value will be "Yes" if the SKU has been tagged accordingly, and only Azure subscriptions authorized by you can deploy and use this image. Value will be "No" if the SKU has not been identified as "preview".
        public string? IsPreviewSKU { get; set; }
    
        // The unique identifier of the customer order for your commercial marketplace service. Virtual Machine usage-based offers are not associated with an order.
        public Guid? AssetId { get; set; }
    
        // Number of assets associated with the order ID for active orders
        public int Quantity { get; set; }
    
        // The Microsoft Cloud in which a VM deployment occurred.
        public string? CloudInstanceName { get; set; }
    
        // The value identifies whether a new customer acquired one or more of your offers for the first time. Value will be "Yes" if within the same calendar month for "Date Acquired". Value will be "No" if the customer has purchased any of your offers prior to the calendar month reported.	
        public string? IsNewCustomer { get; set; }
    
        // Order Status	Order Status	The status of a commercial marketplace order at the time the data was last refreshed. Possible values are:
        // Active: Subscription asset is active and used by customer
        // Canceled: Subscription of an asset is canceled by customer
        // Expired: Subscription for an offer expired in the system automatically post trial period
        // Abandoned: Indicates a system error during offer creation or subscription fulfillment was not completed
        // Warning: Subscription order is still active but customer has defaulted in payments
        public string? OrderStatus { get; set; }
    
        // The date the commercial marketplace order was canceled.
        public DateTime OrderCancelDate { get; set; }
    
        // The company name provided by the customer. Name could be different than the city in a customer's Azure subscription.
        public string? CustomerCompanyName { get; set; }
        
        // The date the commercial marketplace order was created. The format is yyyy-mm-dd.
        public string? OrderPurchaseDate { get; set; }
        
        // The name of the commercial marketplace offering.
        public string? OfferName { get; set; }
        
        // Is Private Offer	Is Private Offer	Indicates whether a marketplace offer is private or a public offer
        // 0 value indicates false
        // 1 value indicates true
        // Note: Private plans are different from Private offers.
        public string? IsPrivateOffer { get; set; }
        
        // Indicates the start date of a term for an order
        public DateTime TermStartDate { get; set; }
        
        // Indicates the end date of a term for an order
        public DateTime TermEndDate { get; set; }
        
        // The identifier of the purchase record for an order purchase
        public string? PurchaseRecordId { get; set; }
        
        // The identifier of the purchase record line item related to this order.
        public string? PurchaseRecordLineItemId { get; set; }
        
        // The price the customer will be charged for all order units before taxation. This is calculated in customer transaction currency. In tax-inclusive countries, this price includes the tax, otherwise it does not.
        public string? BilledRevenue { get; set; }
        
        // Billing currency for the order purchase
        public string? Currency { get; set; }
        
        // Represents whether an offer has trial period enabled
        public string? HasTrial { get; set; }
        
        // Represents whether an offer SKU is in trial period
        public string? IsTrial { get; set; }
        
        // The date the trial period for this order will end or has ended.
        public DateTime TrialEndDate{ get; set; }
        
        // Indicates the customer action for an offer subscription. Possible values are:
        // Purchase: Order was purchased
        // Renewed: Order was renewed
        // Canceled: Order was canceled
        public string? OrderAction { get; set; }
        
        // The net change in seats added and seats removed for existing subscription orders. Same applies for sites (flat rate) pricing model
        public string? QuantityChanged { get; set; }
        
         // Indicates the timestamp of an order management event, such as an order purchase, cancelation, renewal, and so on
        public DateTime EventTimestamp{ get; set; }
        // The unique identifier assigned to a customer. A customer may have zero or more Azure Marketplace subscriptions.
        public string? CustomerId { get; set; }
        
        // The identifier of the account on which billing is generated. Map Billing Account ID to customerID to connect your Payout Transaction Report with the Customer, Order, and Usage Reports.
        public string? BillingAccountId{ get; set; }
        
        // The display name of the plan entered when the offer was created in Partner Center. Note that PlanId was originally a numeric number.
        public string? PlanId{ get; set; }
     
        // BillingTerm	Indicates the term duration of the offer purchased by the customer
        public string? BillingTerm { get; set; }
        
        // Indicates the billing frequency of the offer purchased by the customer
        public string? BillingPlan { get; set; }
        
        // A key to link orders having usage details in usage report. Map this field value with the value for Reference ID key in usage report. This is applicable for SaaS with custom meters and VM software reservation offer types
        public string? ReferenceId { get; set; }

        // Indicates whether a subscription is due for an automatic renewal. Possible values are:
        // TRUE: Indicates that on the TermEnd the subscription will renew automatically.
        // FALSE: Indicates that on the TermEnd the subscription will expire.
        // NULL: The product does not support renewals. Indicates that on the TermEnd the subscription will expire. This is displayed "-" on the UI
        public string? AutoRenew{ get; set; }
       
        	
    }
}