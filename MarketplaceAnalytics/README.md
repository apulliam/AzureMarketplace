This repo is designed to demonstrate (and simplify) the Azure Marketplace Analytics API's.

https://docs.microsoft.com/en-us/azure/marketplace/analytics-programmatic-access

This repo will also include notes on the Marketplace Analytics documention, including the API's where the API documentation has errors, omissions or the API behaviors are inconsistent or just unhelpful.

The Marketplace Analytics API's are accessed at the endpoint:
https://api.partnercenter.microsoft.com/insights/v1/cmp/

There are 3 groups of service off this root endpoint for

DataSets
Queries
Reports


Scheduled start time must be at least four hours in future
Report webhook is not executed for Execute now reports
ExecuteNow reports cannot be updated
ExecuteNow reports can only be executed once and must be deleted for cleanup
ReportName should not contain spaces as its used as part of the name of the CSV file
executionStatus flag does not work. ; separator returns bad request , doesn't find filter matches

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