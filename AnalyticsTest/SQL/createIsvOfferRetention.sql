USE [AzureMarketplace]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ISVOfferRetention]
(
	[OfferCategory],
	[OfferName],
	[ProductId],
	[Sku],
	[SkuBillingType],
	[CustomerId],
	[CustomerName],
	[CustomerCompanyName],
	[CustomerCountryName],
	[CustomerCountryCode],
	[CustomerCurrencyCode],
	[FirstUsageDate],
	[AzureLicenseType],
	[OfferType],
	[Offset]
	/* availableMetrics */
	[RevenueGenerated(USD)],
	[RevenueGeneratedPerDay(USD)]
)
GO
