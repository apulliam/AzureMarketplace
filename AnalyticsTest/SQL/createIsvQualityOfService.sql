USE [AzureMarketplace]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
