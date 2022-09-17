namespace MsftGps.MarketplaceAnalytics.Schema
{
    public class QualityOfService
    {
        // The name of the deployed offer
        public string? OfferID { get; set; } 
        
        // The name of the deployed offer plan/SKU
        public string? Sku { get; set; }
        
        // The offer deployment status marked as either successful or failed
        public string? DeploymentStatus { get; set; } 

        // The identifier used to distinguish different deployments.The same value means all resources being deployed are for one deployment.
        public string? DeploymentCorrelationId { get; set; }
        
        // The Subscription ID of the customer
        public string? SubscriptionId { get; set; }
        
        // The Tenant ID of the customer
        public string? CustomerTenantId { get; set; }
        
        // The name of the customer
        public string? CustomerName { get; set; }
        
        // Type of Azure App deployed.It can be either Managed App or Solution Templates and it cannot be private.
        public string? TemplateType { get; set; }
        
        // The start time of the deployment
        public DateTime StartTime { get; set; }
        
        // The end time of the deployment
        public DateTime EndTime { get; set; }
        
        // The total time duration of offer deployment in milliseconds.It is shown in minutes in the graph.
        public string? DeploymentDurationInMilliSeconds { get; set; }
        
        // The location of the Azure App deployment
        public string? DeploymentRegion { get; set; }
        
        // The resource provider for the particular deployed resource
        public string? ResourceProvider { get; set; }
        
        // The URI of the deployed resource
        public string? ResourceUri { get; set; }
        
        // The resource group where the resource is deployed
        public string? ResourceGroup { get; set; }
        
        // The type of deployed resource
        public string? ResourceType { get; set; }
        
        // The name of the deployed resource
        public string? ResourceName { get; set; }
        
        // The error code for the deployment failure
        public string? ErrorCode { get; set; }
        
        // The error name for the deployment failure
        public string? ErrorName { get; set; }
        
        // The error message for the deployment failure
        public string? ErrorMessage { get; set; }
        
        // If present, contains further information on the error code
        public string? DeepErrorCode { get; set; }
        
        // If present, contains further information on the error message
        public string? DeepMessageCode { get; set; }
      
    }
}