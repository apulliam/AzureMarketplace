namespace MsftGps.MarketplaceAnalytics.Schema
{
    public class ISVUsage
    {
        // The unique identifier associated with the Azure subscription the customer used to purchase your commercial marketplace offer. ID was formerly the Azure Subscription GUID.
        public string? MarketplaceSubscriptionId { get; set; }

        // Month Start Date represents the month of Purchase.
        public string? MonthStartDate { get; set; }

        // The type of commercial marketplace offering.
        public string? OfferType { get; set; }

        // The type of licensing agreement used by customers to purchase Azure. Also known as the Channel. The possible values are:
        // Cloud Solution Provider
        // Enterprise
        // Enterprise through Reseller
        // Pay as You Go
        public string? AzureLicenseType { get; set; }

        // Marketplace License Type	Marketplace License Type	The billing method of the commercial marketplace offer. The possible values are:
        // Billed Through Azure
        // Bring Your Own License
        // Free
        // Microsoft as Reseller
        public string? MarketplaceLicenseType { get; set; }

        // The plan associated with the offer.
        public string? SKU { get; set; }

        // Customer Country	Customer Country/Region	The country/region name provided by the customer. Country/region could be different than the country/region in a customer's Azure subscription.
    	public string? CustomerCountry { get; set; }

        // The value shows if you have tagged the SKU as "preview". Value will be "Yes" if the SKU has been tagged accordingly, and only Azure subscriptions authorized by you can deploy and use this image. Value will be "No" if the SKU has not been identified as "preview".
       	public string? IsPreviewSKU { get; set; }

        // The Billing type associated with each SKU in the offer. The possible values are:
        // Free
        // Paid
        public string? SKUBillingType { get; set; }

        // For VM-based offer types, this entity signifies the size of the VM associated with the SKU of the offer.
       	public string? VMSize { get; set; }

        // The Microsoft Cloud in which a VM deployment occurred.
       	public string? CloudInstanceName { get; set; }
      
        // The name of the commercial marketplace offering.
    	public string? OfferName { get; set; }
      
        // Indicates whether a marketplace offer is a private or a public offer:
        // 0 value indicates false
        // 1 value indicates true
        public string? IsPrivateOffer { get; set; }
        
        // Need documentation
        public string? DeploymentMethod { get; set; }

        // Name of the billed to customer	
        public string? CustomerName { get; set; }
        
        // The company name provided by the customer. The name could be different than the name in a customer's Azure subscription.
        public string? CustomerCompanyName { get; set; }
        
        // The date of usage event generation for usage-based assets.
        public string? UsageDate { get; set; }
        
        // Signifies whether the offer is a Multisolution offer type.
        //public string? IsMultisolution { get; set; }
        
        // Need description
        public string? IsNewCustomer { get; set; }
        
        // Number of cores associated with the VM-based offer.
    	public string? CoreSize { get; set; }
        
        // Signifies whether the usage event associated with the offer is one of the following:
        // Normalized usage
        // Raw usage
        // Metered usage
        // public string? UsageType { get; set; }
        
        // The date the trial period for this order will end or has ended.
       	public DateTime TrialEndDate { get; set; }
        
        // The currency used by the customer for the commercial marketplace transaction.
    	public string? CustomerCurrencyCC { get; set; }
        
        // Unit price of the SKU shown in customer currency.
       	public string? PriceCC { get; set; }
        
        // Publisher is paid for the usage events associated with the asset in the currency configured by the publisher.
       	public string? PayoutCurrencyPC { get; set; }
        
        // Estimated Price (PC)	Estimated Price	Unit price of the SKU in the currency configured by the publisher.
       	public string? EstimatedPricePC { get; set; }
        
        // A concatenated GUID that is used to connect the Usage Report (in commercial marketplace analytics) with the Payout transaction report. Usage Reference is connected with OrderId and LineItemId in the Payout transaction report.
       	public string? UsageReference { get; set; }
        
        // Unit of consumption associated with the SKU.
       	public string? UsageUnit { get; set; }
        
        // The unique identifier assigned to a customer. A customer may have zero or more Azure Marketplace subscriptions.
       	public string? CustomerId { get; set; }
        
        // The identifier of the account on which billing is generated. Map Billing Account ID to customerID to connect your Payout Transaction Report with the Customer, Order, and Usage Reports.
       	public string? BillingAccountId { get; set; }
        
        // The total usage units consumed by the asset that is deployed by the customer.
        // This is based on Usage type item. For example, if the Usage Type is Normalized usage, then Usage Quantity is for Normalized Usage.
       	// public string? UsageQuantity { get; set; }
        
       
        
        // Applicable for offers with custom meter dimensions.
        // Metered dimension of the custom meter. For example, user/device - billing unit
       	public string? MeterDimension { get; set; }
        
        // Applicable for offers with custom meter dimensions.
        // Signifies the meter ID for the offer.
       	public string? MeterId { get; set; }
        
        // Applicable for offers with custom meter dimensions.
        // Signifies whether the publisher reported overage usage for the offer’s custom meter dimension that was is flagged as an anomaly by Partner Center. The possible values are:
        // 0 (Not an anomaly)
        // 1 (Anomaly)
        // If the publisher doesn’t have offers with custom meter dimensions, and exports this column through programmatic access, then the value will be null.
       	public string? PartnerCenterDetectedAnomaly { get; set; }
        
        // Applicable for offers with custom meter dimensions.
        // Signifies whether the publisher acknowledged the overage usage by the customer for the offer’s custom meter dimension as genuine or false. The possible values are:
        // 0 (Publisher has marked it as not an anomaly)
        // 1 (Publisher has marked it as an anomaly)
        // If the publisher doesn’t have offers with custom meter dimensions, and exports this column through programmatic access, then the value will be null.
       	public string? PublisherMarkedAnomaly { get; set; }
        
        // Applicable for offers with custom meter dimensions.
        // For overage usage by the customer for the offer’s custom meter dimension identified as anomalous by the publisher. This field specifies the new overage usage reported by the publisher.
        // If the publisher doesn’t have offers with custom meter dimensions, and exports this column through programmatic access, then the value will be null.
       	public string? NewReportedUsage { get; set; }
        
        // Action Taken At	Action Taken At	Applicable for offers with custom meter dimensions.
        // Specifies the time when the publisher acknowledged the overage usage by the customer for the offer’s custom meter dimension as genuine or false.
        // If the publisher doesn’t have offers with custom meter dimensions, and exports this column through programmatic access, then the value will be null.
       	public string? ActionTakenAt { get; set; }
        
        // Applicable for offers with custom meter dimensions.
        // Specifies the person who acknowledged the overage usage by the customer for the offer’s custom meter dimension as genuine or false.
        // If the publisher doesn’t have offers with custom meter dimensions, and exports this column through programmatic access, then the value will be null.
       	public string? ActionTakenBy { get; set; }
                
        // Applicable for offers with custom meter dimensions.
        // The unique identifier of the customer's order subscription for your commercial marketplace service. Virtual machine usage-based offers are not associated with an order.	Asset Id
        // PlanId	PlanID	The display name of the plan entered when the offer was created in Partner Center. Note that PlanId was originally a number.
       	public string? PlanID { get; set; }
        
        // A key to link transactions of usage-based offers with corresponding transactions in the orders report. For SaaS offers with custom meters, this key represents the AssetId. For VM software reservations, this key can be used for linking orders and usage reports.
       	public string? ReferenceId { get; set; }

        // Start of available metrics (compute columns)
        
        // The total normalized usage units consumed by the asset that is deployed by the customer.
        // Normalized usage hours are defined as the usage hours normalized to account for the number of VM cores ([number of VM cores] x [hours of raw usage]). VMs designated as "SHAREDCORE" use 1/6 (or 0.1666) as the [number of VM cores] multiplier.
       	public string? NormalizedUsage { get; set; }
        
        // The total usage units consumed by the meters that are configured with the offer that is deployed by the customer.
       	public string? MeteredUsage { get; set; }
        
        // The total raw usage units consumed by the asset that is deployed by the customer.
        // Raw usage hours are defined as the amount of time VMs have been running in terms of usage units.
       	public string? RawUsage { get; set; }
        
        // Estimated Extended Charge in Customer Currency	Signifies the charges associated with the usage. The column is the product of Price (CC) and Usage Quantity.
       	public string? EstimatedExtendedChargeCC { get; set; }
        
        // Estimated Extended Charge in Payout Currency	Signifies the charges associated with the usage. The column is the product of Estimated Price (PC) and Usage Quantity.
       	public string? EstimatedExtendedChargePC { get; set; }
        
        // Estimated Financial Impact (USD)	Estimated Financial Impact in USD	Applicable for offers with custom meter dimensions.
        // When Partner Center flags an overage usage by the customer for the offer’s custom meter dimension as anomalous, the field specifies the estimated financial impact (in USD) of the anomalous overage usage.
        // If the publisher doesn’t have offers with custom meter dimensions, and exports this column through programmatic means, then the value will be null.
       	public string? EstimatedFinancialImpactUSD { get; set; }

    }
}