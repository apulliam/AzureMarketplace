USE [AzureMarketplace]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ISVRevenue]
(
	[AssetId] UNIQUEIDENTIFIER NULL, /* GUID or null */
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

