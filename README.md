# Azure Marketplace Backend Integration Accelerator
## Overview

This is the repo for the Azure Marketplace Backend Integration Accelerator project.  This repo contains sample code and patterns for an ISV backend integration with the Azure Marketplace.   The goal of this project is to provide guidance for integration with the Azure Marketplace events and data, including:

- Lead events emitted from the [Azure Marketplace CRM lead integration]() endpoint
- [Azure Managed Application webhook]() and [Azure Software as a Service webhook]() events
- [Azure Marketplace Analytics]() database

The first phase of this project is a sample for an ISV integration with [Azure Marketplace Analytics API's]().  There is currently limited, and, in some cases, incorrect documentation for the Azure Marketplace Analytics datasets and API's, and only one minimal [sample]() available. 

Later phases of this project will provide a holistic sample of ISV backend integration with the CRM lead data and Azure Marketplace webhooks for Azure Managed Application and Software as a Service events.

## Background

This repo is intended to complement other guidance and samples available for ISV's building offers for the Azure Marketplace.

[Mastering the Marketplace](https://microsoft.github.io/Mastering-the-Marketplace/) [(GitHub repo)](https://github.com/microsoft/Mastering-the-Marketplace) is a series of video tutorials and labs developed by the Microsoft's Commercial Marketplace Services (CMS) team.   These tutorials (links below) cover the most popular *Commercial marketplace* offer types available to ISV's via Microsoft Partner Center portal:

- Software as a Service
    * [Build Custom SaaS Offers](https://microsoft.github.io/Mastering-the-Marketplace/saas/)
    * [The SaaS Accelerator](https://microsoft.github.io/Mastering-the-Marketplace/saas-accelerator/) [(Commercial Marketplace SaaS Accelerator GitHub repo)](https://github.com/Azure/Commercial-Marketplace-SaaS-Accelerator)
- Azure Application
    * [Azure Managed Application Offers](https://microsoft.github.io/Mastering-the-Marketplace/ama/)
- [Azure Virtual Machine](https://microsoft.github.io/Mastering-the-Marketplace/vm/)
- Azure Container
- Consulting service
- Dynamics 365 (various offer types)
- IoT Edge Module
- Managed service
- Power BI (apps and visuals)

**Note:** the offer types above appear under the *Commercial marketplace* tab on the Marketplace Offer page in Partner Center.  Microsoft 365 offer types, including SharePoint, Office Add-in's and Team apps are being migrated to Partner Center, but require a separate program enrollment.  These offer types appear under the *Office store*  

The Mastering the Marketplace also include a tutorial on [Mastering Partner Center]() and [Mastering Microsoft Teams Offers]()

ISV's starting work on Azure Marketplace offers or Azure Marketplace backend integration should first start with a review of the relevant Mastering the Marketplace modules for their offer type.

Both Software as a Service and Azure Managed Application offers support metered billing, where the ISV can define custom billing units for the offer, billable via the Azure Commercial Marketplace.  Managed Application offers can be constructed 

https://aka.ms/marketplacesamples - This repo is the official location for https:/github.com/microsoft/metered-billing-accelerator

## Azure Marketplace Endpoints

When an ISV publishes an offer to the Azure Marketplace, there are potentially 3 interfaces to the Marketplace (endpoints) where the ISV can receive operational and statistical information about customer interaction with the ISV offer:
1. CRM Integration - Partner Center provides a link to a CRM system, Azure Table, or HTTP endpoint for notifications of customer activity with the ISV offer in the Marketplace
2. Webhook Notifications (SaaS and Azure Managed Appplication) - For SaaS offers, the ISV must provide a webhook to fulfill the subscription billing process with the Azure Marketplace.  Some ISV's leverage solutions from Microsoft Marketplace SI's to implement the required enpoints.  Azure Managed Applications also optionally allow the ISV to provide an HTTP endpoint which the Azure Marketplace will call with notifications on customer interactions with the Managed Application offer.  

3. Azure Marketplace Analytics - The Azure Marketplace maintains analytics data on ISV offers and customers, which is to provide dashboard visuals in the Insights section of Partner Center.  are used to


Analytics Reports for built-in (system) or custom queries can be downloaded as CSV or TSV files from Partner Center

The specific events differ by offer type.

Azure Managed Application notification


EventType	ProvisioningState	Trigger for notification
PUT	Accepted	Managed resource group has been created and projected successfully after application PUT (before the deployment inside the managed resource group is kicked off).
PUT	Succeeded	Full provisioning of the managed application succeeded after a PUT.
PUT	Failed	Failure of PUT of application instance provisioning at any point.
PATCH	Succeeded	After a successful PATCH on the managed application instance to update tags, JIT access policy, or managed identity.
DELETE	Deleting	As soon as the user initiates a DELETE of a managed app instance.
DELETE	Deleted	After the full and successful deletion of the managed application.
DELETE	Failed	After any error during the deprovisioning process that blocks the deletion.


{
  "eventType": "PUT",
  "applicationId": "/subscriptions/<subId>/resourceGroups/<rgName>/providers/Microsoft.Solutions/applications/<applicationName>",
  "eventTime": "2019-08-14T19:20:08.1707163Z",
  "provisioningState": "Succeeded",
  "billingDetails": {
    "resourceUsageId": "<resourceUsageId>"
  },
  "plan": {
    "publisher": "publisherId",
    "product": "offer",
    "name": "skuName",
    "version": "1.0.1"
  }
}


{
  "eventType": "PUT",
  "applicationId": "/subscriptions/<subId>/resourceGroups/<rgName>/providers/Microsoft.Solutions/applications/<applicationName>",
  "eventTime": "2019-08-14T19:20:08.1707163Z",
  "provisioningState": "Failed",
  "billingDetails": {
    "resourceUsageId": "<resourceUsageId>"
  },
  "plan": {
    "publisher": "publisherId",
    "product": "offer",
    "name": "skuName",
    "version": "1.0.1"
  },
  "error": {
    "code": "ErrorCode",
    "message": "error message",
    "details": [
      {
        "code": "DetailedErrorCode",
        "message": "error message"
      }
    ]
  }
}

Azure SaaS Application notifications

This repo is designed to demonstrate (and simplify) the Azure Marketplace Analytics API's.



https://docs.microsoft.com/en-us/azure/marketplace/analytics-programmatic-access


3. Azure Marketplace Analytics - The Azure Marketplace maintains 7 queryable datasets for the ISV to obtain information about their offers in the Azure Marketplace:
    [ISVOrder]()
    [ISVUsage]()
    [ISVCustomer]()
    [ISVMarketplaceInsights]()
    [ISVRevenue]()
    [ISVOfferRetention]()
    [ISVQualityOfService]()

    
    These datasets support limited SQL-like query options, but only on individual dataset and for 5 fixed time spans:
        LAST_MONTH
        LAST_3_MONTHS
        LAST_6_MONTHS
        LAST_1_YEAR
        LIFETIME
    
    The the LAST_MONTH view is used for the graphs in the Insights section of Partner Center. Reports for built-in (system) or custom queries can be downloaded as CSV or TSV files from Partner Center
    
    The Azure Marketplace Analytics API's provide programmatic access to these same DataSets, but the API semantics mimic the interactive use of the data in Partner Center.  For example, the data stil must be downloaded to CSV or TSV files and the API's only support the same fixed timespans, which, while well suited for dashboard data, don't provide precise data access options for ISV's. 

As the code in this project in being developed, it can be use by an ISV to build an integration with any single Azure Marketplace backend endpoint, and it will eventually 
This code in this repo is designed to provide a holistic sample of how an ISV can integrate with all Azure Marketplace endpoints, and consolidate data from all endpoints for use in the ISV's business opertation (e.e. finance, marketing compliances.)



