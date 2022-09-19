This file contains notes on the Marketplace Analytics documention, including the API documentation, where the documentation has errors or omissions.  It also includes notes on API errors and inconsistencies.

This will be converted into a proper readme as the project nears the first release.

The Marketplace Analytics API's are accessed at the endpoint:
https://api.partnercenter.microsoft.com/insights/v1/cmp/

There are 4 groups of services off this root endpoint for

ScheduledDataSet - GET All, GET by Name
ScheduledQueries - POST; GET All, Get by ID, Get by Name, Get System; DELETE by ID
ScheduledReport - GET All/ID/Name, POST, PUT ID, DELETE ID
SchedulerReport/exececutions - GET/ID

All API calls require an Azure AD bearer token for authentication via a tenant associated with the Partner Center account.  Note that a Partner Center account can have multiple Azure AD tenant associations.

The setup requires two steps:
1. Create an App Registration in the ISV tenant, and create a client secret to support the OAuth2 client credentials flow.
2. Register the App Registration in Partner Center and assign the appropriate access level.  For testing with Manager (Windows) access level was used.

The sample code shows how to obtain a bearer token from Azure using the Microsoft Authentication Library, which is available for most programming languages.

The Analytics API's require a token for the scope https://graph.windows.net/.default.  This corresponds to the deprecated Azure AD Graph API's, so the Analytics API's should be updated to also accept the current Microsoft Graph endpoint https://graph.microsoft.com/.default.

The basic flow is 
1. Get DataSets (optional)
1. Create a Custom Query  This step is (optional as system queries are always available)


The ISVOfferRetention has two metric (which appear to be calculated columms) which have parenthesis which is not accepted by the API's"
    "RevenueGenerated(USD)",
    "RevenueGeneratedPerDay(USD)"


Scheduled start time must be at least four hours in future

ExecuteNow reports cannot be updated

ExecuteNow reports can only be executed once, but like all report executions, must be deleted to cleanup files in Azure blob storage

ReportName should not contain spaces as its used as part of the name of the CSV file

executionStatus flag does not work. ; separator returns bad request , doesn't find filter matches

ExecuteNow reports may take some time to execute. It appear they are being submitted to a queue. The execution time can be determined by comparing the startTime field in the CreateReport call with the reportGeneratedTime in the GetReportExececutions call.


  {
      "reportId": "70ec57fa-da22-4641-9492-86a2bfbbc30e",
      "reportName": "query-52ef45ab-61a6-43f5-b0d0-ea85de24135d-report",
      "description": null,
      "queryId": "52ef45ab-61a6-43f5-b0d0-ea85de24135d",
      "query": "SELECT MarketplaceSubscriptionId,\r\n                DateAcquired,\r\n                DateLost,\r\n                IsActive,\r\n                ProviderName,\r\n                ProviderEmail,\r\n                FirstName,\r\n                LastName,\r\n                Email,\r\n                CustomerCompanyName,\r\n                CustomerCity,\r\n                CustomerPostalCode,\r\n                CustomerCommunicationCulture,\r\n                CustomerCountryRegion,\r\n                AzureLicenseType,\r\n                PromotionalCustomers,\r\n                CustomerState,\r\n                CommerceRootCustomer,\r\n                CustomerId,\r\n                BillingAccountId,\r\n                CustomerType,\r\n                OfferName,\r\n                PlanId,\r\n                SKU from ISVCustomer TIMESPAN LIFETIME",
      "user": "162339930",
      "createdTime": "2022-09-16T17:12:09Z",
      "modifiedTime": null,
      "executeNow": true,
      "queryStartTime": null,
      "queryEndTime": null,
      "startTime": "2022-09-16T17:12:09Z",
      "reportStatus": "Inactive",
      "recurrenceInterval": -1,
      "recurrenceCount": 1,
      "callbackUrl": null,
      "callbackMethod": null,
      "format": "csv"
    }



    {
      "executionId": "9cfc2e22-ff93-44fb-ba48-6ac2374fa759",
      "reportId": "70ec57fa-da22-4641-9492-86a2bfbbc30e",
      "recurrenceInterval": -1,
      "recurrenceCount": 1,
      "callbackUrl": null,
      "callbackMethod": null,
      "format": "csv",
      "executionStatus": "Completed",
      "reportLocation": "https://pxanltx.blob.core.windows.net/programmatic-export-pi/query-52ef45ab-61a6-43f5-b0d0-ea85de24135d-report_b86fc666-5661-4951-a61a-266d5b40571e.csv",
      "reportAccessSecureLink": "https://pxanltx.blob.core.windows.net/programmatic-export-pi/query-52ef45ab-61a6-43f5-b0d0-ea85de24135d-report_b86fc666-5661-4951-a61a-266d5b40571e.csv?sv=2018-03-28&sr=b&sig=TUSsT80aZcAXFzEAhKCgMxWm5ejqWPS5hEsxwi6zqiQ%3D&se=2022-09-23T17%3A23%3A12Z&sp=r",
      "reportExpiryTime": null,
      "reportGeneratedTime": "2022-09-16T17:20:48Z"
    }

    