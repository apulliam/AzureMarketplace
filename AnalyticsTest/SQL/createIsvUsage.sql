USE [AzureMarketplace]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IsvUsage]
(			
	[MarketplaceSubscriptionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[MonthStartDate],
	[OfferType],
	[AzureLicenseType],
	[MarketplaceLicenseType],
	[SKU],
	[CustomerCountry],
	[IsPreviewSKU],
	[SKUBillingType],
	[VMSize],
	[CloudInstanceName],
	[OfferName],
	[IsPrivateOffer],
	[DeploymentMethod],
	[CustomerName],
	[CustomerCompanyName],
	[UsageDate] DATETIME2,
	[IsNewCustomer] BIT,
	[CoreSize],
	[TrialEndDate] DATETIME2,
	[CustomerCurrencyCC],
	[PriceCC],
	[PayoutCurrencyPC],
	[EstimatedPricePC],
	[UsageReference],
	[UsageUnit],
	[CustomerId] UNIQUEIDENTIFIER NOT NULL,
	[BillingAccountId] UNIQUEIDENTIFIER NOT NULL,
	[MeterDimension],
	[MeterId],
	[PartnerCenterDetectedAnomaly],
	[PublisherMarkedAnomaly],
	[NewReportedUsage],
	[ActionTakenAt],
	[ActionTakenBy],
	[PlanId],
	[ReferenceId] UNIQUEIDENTIFIER NOT NULL,
	/* availableMetrics */
	[NormalizedUsage],
	[MeteredUsage],
	[RawUsage],
	[EstimatedExtendedChargeCC],
	[EstimatedExtendedChargePC],
	[EstimatedFinancialImpactUSD]
)
GO
