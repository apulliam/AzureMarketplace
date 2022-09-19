USE [AzureMarketplace]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- "a5fcc406-39d3-42f0-be3a-e399f74de289",
-- "2022-09-01",
-- "azure applications",
-- "Enterprise",
-- "Billed Through Azure",
-- "Metered Internal Only",
-- "United States",
-- "0",
-- "f9e58b12-bf61-4e8a-d5f5-291d2736e652",
-- "1",
-- "Global",
-- "0",
-- "cancelled",
-- "2022-09-12 15:27:18.0000000",
-- "SAS Institute, Inc.",
-- "2022-09-10",
-- "SAS Viya",
-- "0",
-- "2022-09-10",
-- "2022-10-09",
-- "T9rR1ne-ULF5PAar9DQOTbaV3svrJvJZ1",
-- "6040170841",
-- "0.00000",
-- "USD",
-- "0",
-- "0",
-- ,
-- "Purchase",
-- "0",
-- "2022-09-12 15:27:12.5290170",
-- "68e13b40-4046-4e25-804c-c7c1410cbe0c_2018-09-30",
-- "0c206dd8-7105-4ae6-a4ae-ce53224bd154",
-- "sas-viya-azure-metered-internal-only",
-- "1 Month",
-- "Upfront",
-- "f9e58b12-bf61-4e8a-d5f5-291d2736e652",
-- "True",
-- "7002"

CREATE TABLE [dbo].[IsvOrder]
(
	[MarketplaceSubscriptionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, -- GUID 
	[MonthStartDate] DATE NOT NULL, -- MM/DD/YYYY 
	[OfferType] NVARCHAR(20) NOT NULL, -- "azure applications", "SaaS", ...? 
	[AzureLicenseType] NVARCHAR(30) NOT NULL, -- "Cloud Solution Provider","Enterprise", "Enterprise through Reseller", "Pay as You Go", "GTM" 
	[MarketplaceLicenseType] NVARCHAR(25), -- "Billed through Azure", "Bring Your Own License", "Free", "Microsoft as Reseller"
	[SKU] NVARCHAR(50), -- Plan name from Partner Center
	[CustomerCountry] NVARCHAR(50),
	[IsPreviewSKU] BIT NOT NULL,
	[AssetId] UNIQUEIDENTIFIER NOT NULL,
	[Quantity] TINYINT NOT NULL,
	[CloudInstanceName] NVARCHAR(20) NOT NULL, -- "global", ...?
	[IsNewCustomer] BIT,
	[OrderStatus] NVARCAR(10), -- "Active, Canceled, Expired, Abandoned, Warning"
	[OrderCancelDate] DATETIME2,
	[CustomerCompanyName] NVARCHAR(50),
	[OrderPurchaseDate], /* MM/DD/YYYY */
	[OfferName],
	[IsPrivateOffer] BIT NOT NULL,
	[TermStartDate] DATE, /* MM/DD/YYYY */
	[TermEndDate] DATE, /* MM/DD/YYYY */
	[PurchaseRecordId] NVARCHAR(40), /* random string */
	[PurchaseRecordLineItemId], /* Guid or integer */
	[BilledRevenue], /* numeric or null */
	[Currency] NVARCAR(3),
	[HasTrial] BIT,
	[IsTrial] BIT,
	[TrialEndDate] DATETIME2,
	[OrderAction] NVARCHAR(10), /* Purchase, Renew, Cancel */
	[QuantityChanged],
	[EventTimestamp] DATETIME2,
	[CustomerId] NVARCAR(50) NOT NULL, /* <GUID>_<date> */
	[BillingAccountId] UNIQUEIDENTIFIER NOT NULL,
	[PlanId] NVARCAR(50) NOT NULL,
	[BillingTerm],
	[BillingPlan],
	[ReferenceId] UNIQUEIDENTIFIER NOT NULL,
	[AutoRenew] NVARCHAR(5), /* TRUE, FALSE, NULL */
	[OrderVersion] SMALLINT NOT NULL /* Int */
)
GO

