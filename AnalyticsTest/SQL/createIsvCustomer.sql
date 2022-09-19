USE [AzureMarketplace]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IsvCustomer]
(
	[MarketplaceSubscriptionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[DateAcquired] DATETIME2,
	[DateLost] DATETIME2,
	[IsActive] BIT,
	[ProviderName] NVARCHAR(50),
	[ProviderEmail] NVARCHAR(50),
	[FirstName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[Email] NVARCHAR(50),
	[CustomerCompanyName] NVARCHAR(50),
	[CustomerCity] NVARCHAR(50),
	[CustomerPostalCode] NVARCHAR(50),
	[CustomerCommunicationCulture] NVARCHAR(50),
	[CustomerCountryRegion] NVARCHAR(50),
	[AzureLicenseType] NVARCHAR(50),
	[PromotionalCustomers] NVARCHAR(50),
	[CustomerState] NVARCHAR(50),
	[CommerceRootCustomer] NVARCHAR(50),
	[CustomerId] UNIQUEIDENTIFIER NOT NULL,
	[BillingAccountId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerType] NVARCHAR(50),
	[OfferName] NVARCHAR(50),
	[PlanId] NVARCHAR(50),
	[SKU] NVARCHAR(50)
)
GO

