USE [AzureMarketplace]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IsvOrder]
(
	[MarketplaceSubscriptionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[MonthStartDate] DATETIME2,
	[OfferType],
	[AzureLicenseType],
	[MarketplaceLicenseType],
	[SKU],
	[CustomerCountry],
	[IsPreviewSKU] BIT,
	[AssetId],
	[Quantity],
	[CloudInstanceName],
	[IsNewCustomer] BIT,
	[OrderStatus],
	[OrderCancelDate],
	[CustomerCompanyName],
	[OrderPurchaseDate],
	[OfferName],
	[IsPrivateOffer],
	[TermStartDate] DATETIME2,
	[TermEndDate] DATETIME2,
	[PurchaseRecordId],
	[PurchaseRecordLineItemId],
	[BilledRevenue],
	[Currency],
	[HasTrial] BIT,
	[IsTrial] BIT,
	[TrialEndDate] DATETIME2,
	[OrderAction],
	[QuantityChanged],
	[EventTimestamp] DATETIME2,
	[CustomerId] UNIQUEIDENTIFIER NOT NULL,
	[BillingAccountId] UNIQUEIDENTIFIER NOT NULL,
	[PlanId],
	[BillingTerm],
	[BillingPlan],
	[ReferenceId] UNIQUEIDENTIFIER NOT NULL,
	[AutoRenew],
	[OrderVersion]
)
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

CREATE TABLE [dbo].[ISVMarketplaceInsights]
(
    [Date] DATETIME2,
	[OfferName],
	[ReferralDomain],
	[CountryName],
	[PageVisits],
	[GetItNow],
	[ContactMe],
	[TestDrive],
	[FreeTrial],
	[ConsentGiven],
	[Site],
	[Campaign]
)
GO

CREATE TABLE [dbo].[ISVRevenue]
(
	[AssetId],
	[SalesChannel],
	[BillingAccountId],
	[CustomerCity],
	[CustomerCompanyName],
	[CustomerCountry],
	[CustomerEmail],
	[CustomerId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerName],
	[CustomerState],
	[EarningAmountCC],
	[EarningAmountPC],
	[EarningAmountUSD],
	[EarningCurrencyCode],
	[EarningExchangeRatePC],
	[EstimatedPayoutMonth],
	[Revenue],
	[EstimatedRevenuePC] MONEY,
	[EstimatedRevenueUSD] MONEY,
	[ExchangeRateDate],
	[ExchangeRatePC],
	[ExchangeRateUSD],
	[PayoutStatus],
	[IncentiveRate],
	[TrialDeployment],
	[LineItemId],
	[MonthStartDate],
	[OfferName],
	[OfferType],
	[PaymentInstrumentType],
	[PaymentSentDate],
	[PurchaseRecordId],
	[Quantity],
	[SKU],
	[TermEndDate] DATETIME2,
	[TermStartDate] DATETIME2,
	[TransactionAmountCC] MONEY,
	[TransactionAmountPC] MONEY,
	[TransactionAmountUSD] MONEY,
	[BillingModel],
	[Units],
	[PlanId],
	[IsPrivateOffer] BIT
)
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

CREATE TABLE [dbo].[ISVQualityOfService]
(
	[OfferId],
	[Sku],
	[DeploymentStatus],
	[DeploymentCorrelationId] UNIQUEIDENTIFIER NOT NULL,
	[SubscriptionId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerTenantId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerName],
	[TemplateType],
	[StartTime],
	[EndTime],
	[DeploymentDurationInMilliSeconds],
	[DeploymentRegion],
	[ResourceProvider],
	[ResourceUri],
	[ResourceGroup],
	[ResourceType],
	[ResourceName],
	[ErrorCode],
	[ErrorName],
	[ErrorMessage],
	[DeepErrorCode],
	[DeepErrorMessage]
)
GO
