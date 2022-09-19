namespace MsftGps.MarketplaceAnalytics.Schema
{
    public class ISVRevenue
    { 
        // An identifier for the software assets. Same as the order id in the orders report in Partner Center.
        public string? AssetId { get; set; }	

        // Represents the sales channel for the customer. It is the same as Azure license type in the orders report and usage report. The possible values are:
        // Cloud Solution Provider (CSP)
        // Enterprise (EA)
        // Enterprise through Reseller
        // Pay as You Go
        // Go to market (GTM)
        public string? SalesChannel { get; set; }
        
        // Identifier for the billing account of the customer. Same as customer id in the transaction history report.
        public string? BillingAccountId { get; set; }

        // The city name provided by the bill-to customer
        public string? CustomerCity { get; set; }

         // Name of the customer’s company
        public string? CustomerCompanyName { get; set; }

        // The country or region name provided by the customer. The country/region could be different than the country/region in a customer's Azure subscription.
        public string? CustomerCountry { get; set; }

        // The e-mail address provided by the end customer. This address could be different than the e-mail address in a customer's Azure subscription.
        public string? CustomerEmail { get; set; }
        
        // The unique identifier assigned to a customer. A customer may have zero or more Azure Marketplace subscriptions. Same as customer id in the customers report.
        public string? CustomerId { get; set; }

        // Name of the customer
        public string? CustomerName { get; set; }
        
        // The state name provided by the bill-to customer
        public string? CustomerState { get; set; }
        
         // Earnings amount in the original transaction currency
        public string? EarningsAmountCC { get; set; }
        
        // Earnings amount in partner preferred payout currency
        public string? EarningsAmountPC { get; set; }
        
        // Earnings amount in USD
        public string? EarningsAmountUSD { get; set; }
        
        // The customer currency used for a transaction
        public string? EarningCurrencyCode { get; set; }
        
        // The exchange rate used to convert transaction amount and transaction amount in USD
        public string? EarningExchangeRatePC { get; set; }
        
        // The month for receiving your estimated earnings
        public string? EstimatedPayOutMonth { get; set; }

        // Represents billed sales of a partner for customer’s offer purchases and consumption through the commercial marketplace. This is in transaction currency and will always be present in download reports.
        public string? Revenue { get; set; }

        // Estimated revenue reported in partner preferred currency. This column will always be present in download reports.
        public string? EstimatedRevenuePC { get; set; }

        // Needs documentation
        public string? EstimatedRevenueUSD { get; set; }

        // The date used to calculate exchange rates for currency conversions
        public DateTime ExchangeRateDate { get; set; }

         // Needs documentation
        public string? ExchangeRatePC { get; set; }
        
          // Needs documentation
        public string? ExchangeRateUSD { get; set; }

        // Needs documentation
        public string? PayoutStatus { get; set; }
     
        // Needs documentation
        public string? IncentiveRate { get; set; }
      
        // Denotes whether the offer was in trial deployment at the time of billing
        public string? TrialDeployment { get; set; }
    
        // Individual line in a customer's invoice. Same as lineItemId in the transaction history report.
        public string? LineItemId { get; set; }

        // The month for which the billing was done and Purchase record id and Line-item id were generated
        public DateTime MonthStartDate { get; set; }
    
        // Display name of the offer
        public string? OfferName { get; set; }

        // Type of offer, such as SaaS, VM, and so on.
        public string? OfferType { get; set; }	

        // Needs documentation
        public string? PaymentInstrumentType  { get; set; }

        // The date on which payment was sent to the partner
        public string? PaymentSentDate { get; set; }
        
         // Relates to a customer's invoice. Same as order id in the transaction history report.
        public string? PurchaseRecordId { get; set; }
        
        // Indicates billed quantity for transactions. This can represent the seats and site purchase count for subscription-based offers, and usage units for consumption-based offers.
        public string? Quantity { get; set; }

        // Specific offer plan, also referred to as SKU
        public string? SKU { get; set; }

        // The end date of the order subscription term
        public DateTime TermEndDate { get; set; }

        // The start date of the order subscription term
        public DateTime TermStartDate { get; set; }
       
        // Transaction amount in the original transaction (Customer) currency. Refers to the transaction amount column in the transaction history report
        public string? TransactionAmountCC { get; set; }
       
        // Transaction amount in Partner preferred currency. Refers to the transaction currency USD column in the transaction history report
        public string? TransactionAmountPC { get; set; }

        // Transaction amount in US dollars. Refers to the transaction currency USD column in the transaction history report
        public string? TransactionAmountUSD { get; set; }

        // Subscription or consumption-based billing model used for calculation of estimated revenue. It can have one of these two values:
        // UsageBased
        // SubscriptionBased
        public string? BillingModel { get; set; }	

        // The unit quantity. Represents count of purchased seat/site SaaS orders and core hours for VM-based offers. Units will be displayed as NA for offers with custom meters.
        public string? Units { get; set; }

        // The display name of the plan entered when the offer was created in Partner Center. Note that PlanId was originally a numeric number
        public string? PlanId { get; set; }

        // Indicates whether a marketplace offer is a private or a public offer. 
        // 0 value indicates false
        // 1 value indicates true
        public string? IsPrivateOffer { get; set; }
    }
}