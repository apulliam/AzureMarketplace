USE [AdventureWorksLT2012]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


IF OBJECT_ID ( 'dbo.GetNumberOfAccounts', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[GetNumberOfAccounts]
GO

CREATE PROCEDURE [dbo].[GetNumberOfAccounts]
AS
	select 
		count(*) 
	from
		[SalesLT].[Customer]
GO

IF OBJECT_ID ( 'dbo.GetAllAccounts', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[GetAllAccounts]
GO

CREATE PROCEDURE [dbo].[GetAllAccounts]
AS
	select 
		[Customer].[CustomerID],
		[CompanyName],
		[AddressLine1],
		[City],
		[StateProvince],
		[PostalCode],
		[CountryRegion],
		[SalesPerson],
		[Title],
		[FirstName],
		[MiddleName],
		[LastName],
		[Suffix],
		[Phone],
		[EmailAddress]
	from    
		[SalesLT].[Address] INNER JOIN
		[SalesLT].[CustomerAddress] ON [SalesLT].[Address].[AddressID] = [SalesLT].[CustomerAddress].[AddressID] RIGHT OUTER JOIN
		[SalesLT].[Customer] ON [SalesLT].[CustomerAddress].[CustomerID] = [SalesLT].[Customer].[CustomerID]  
	where 
		(([AddressType]='Main Office') or ([AddressType] is null))
	order by 
		[CompanyName] 
GO

IF OBJECT_ID ( 'dbo.GetNumberOfAccountsByOwner', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[GetNumberOfAccountsByOwner]
GO

CREATE PROCEDURE [dbo].[GetNumberOfAccountsByOwner]
	@SalesPerson nvarchar(256)
AS
	select 
		count(*) 
	from
		[SalesLT].[Customer]
	where
		[SalesPerson] = @SalesPerson 
GO

IF OBJECT_ID ( 'dbo.GetNumberOfAccountsByOwnerWithFilter', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[GetNumberOfAccountsByOwnerWithFilter]
GO

CREATE PROCEDURE [dbo].[GetNumberOfAccountsByOwnerWithFilter]
	@SalesPerson nvarchar(256),
	@Filter nvarchar(128)
AS
	select 
		count(*) 
	from
		[SalesLT].[Customer]
	where
		[SalesPerson] = @SalesPerson and [CompanyName] like '%' + @Filter + '%'
GO

IF OBJECT_ID ( 'dbo.GetAccountsByOwner', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[GetAccountsByOwner]
GO

CREATE PROCEDURE [dbo].[GetAccountsByOwner]
	@SalesPerson nvarchar(256)
AS
    select 
        [Customer].[CustomerID],
        [CompanyName],
        [AddressLine1],
        [City],
        [StateProvince],
        [PostalCode],
        [CountryRegion],
        [SalesPerson],
        [Title],
        [FirstName],
        [MiddleName],
        [LastName],
        [Suffix],
        [Phone],
        [EmailAddress]
    from    
		[SalesLT].[Address] INNER JOIN
        [SalesLT].[CustomerAddress] ON [SalesLT].[Address].[AddressID] = [SalesLT].[CustomerAddress].[AddressID] RIGHT OUTER JOIN
        [SalesLT].[Customer] ON [SalesLT].[CustomerAddress].[CustomerID] = [SalesLT].[Customer].[CustomerID]  
	where 
		((([AddressType]='Main Office') or ([AddressType] is null)) and ([SalesPerson] = @SalesPerson))
    order by 
		[CompanyName] 
	RETURN
GO

IF OBJECT_ID ( 'dbo.GetAccountsByOwnerWithFilter', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[GetAccountsByOwnerWithFilter]
GO

CREATE PROCEDURE [dbo].[GetAccountsByOwnerWithFilter]
	@SalesPerson nvarchar(256), 
    @Filter nvarchar(128)
AS
    select 
        [Customer].[CustomerID],
        [CompanyName],
        [AddressLine1],
        [City],
        [StateProvince],
        [PostalCode],
        [CountryRegion],
        [SalesPerson],
        [Title],
        [FirstName],
        [MiddleName],
        [LastName],
        [Suffix],
        [Phone],
        [EmailAddress]
     from    
		[SalesLT].[Address] INNER JOIN
        [SalesLT].[CustomerAddress] ON [SalesLT].[Address].[AddressID] = [SalesLT].[CustomerAddress].[AddressID] RIGHT OUTER JOIN
        [SalesLT].[Customer] ON [SalesLT].[CustomerAddress].[CustomerID] = [SalesLT].[Customer].[CustomerID]  
	where 
	(
		([AddressType]='Main Office') or ([AddressType] is null)
	)
	and 
	(
		([SalesPerson] = @SalesPerson) and [CompanyName] like '%' + @Filter + '%'
	)
    order by 
		[CompanyName] 
GO

IF OBJECT_ID ( 'dbo.GetAccountById', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[GetAccountById]
GO

CREATE PROCEDURE [dbo].[GetAccountById]
	@CustomerID int
AS
    select 
        [Customer].[CustomerID],
        [CompanyName],
        [AddressLine1],
        [City],
        [StateProvince],
        [PostalCode],
        [CountryRegion],
        [SalesPerson],
        [Title],
        [FirstName],
        [MiddleName],
        [LastName],
        [Suffix],
        [Phone],
        [EmailAddress]
    from
	    SalesLT.Address INNER JOIN
        SalesLT.CustomerAddress ON SalesLT.Address.AddressID = SalesLT.CustomerAddress.AddressID RIGHT OUTER JOIN
        SalesLT.Customer ON SalesLT.CustomerAddress.CustomerID = SalesLT.Customer.CustomerID  
	where
		(((AddressType='Main Office') or (AddressType is null)) and (SalesLT.Customer.CustomerID = @CustomerID)) 
GO

IF OBJECT_ID ( 'dbo.GetMainOfficeAddressId', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[GetMainOfficeAddressId]
GO

CREATE PROCEDURE [dbo].[GetMainOfficeAddressId]
	@CustomerID int
AS
    select 
        [CustomerAddress].[AddressID]
	from 
		[SalesLT].[Customer], [SalesLT].[CustomerAddress] 
	where
		[SalesLT].[Customer].[CustomerID] = [SalesLT].[CustomerAddress].[CustomerID] and 
		[SalesLT].[CustomerAddress].[AddressType] = 'Main Office' and 
		[SalesLT].[CustomerAddress].[CustomerID] = @CustomerID
GO

IF OBJECT_ID ( 'dbo.InsertAddress', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[InsertAddress]
GO

CREATE PROCEDURE [dbo].[InsertAddress]
	@AddressLine1 nvarchar(60), 
    @City nvarchar(30), 
    @StateProvince nvarchar(50), 
    @PostalCode nvarchar(15),
    @CountryRegion nvarchar(50)
AS
    insert [SalesLT].[Address]
	(
		[AddressLine1], 
		[City], 
		[StateProvince], 
		[PostalCode],
		[CountryRegion]
	)
	values 
    (
		@AddressLine1, 
        @City, 
        @StateProvince, 
        @PostalCode,
        @CountryRegion
 	)
	select SCOPE_IDENTITY()
GO

IF OBJECT_ID ( 'dbo.UpdateAddress', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[UpdateAddress]
GO

CREATE PROCEDURE [dbo].[UpdateAddress]
	@AddressID int,
	@AddressLine1 nvarchar(60), 
    @City nvarchar(30), 
    @StateProvince nvarchar(50), 
    @PostalCode nvarchar(15),
    @CountryRegion nvarchar(50)
AS
	update 
		[SalesLT].[Address]  
	set  
     	[AddressLine1] = @AddressLine1, 
		[City] = @City, 
		[StateProvince] = @StateProvince, 
		[PostalCode] = @PostalCode,
		[CountryRegion] = @CountryRegion
	where 
		[AddressID] = @AddressID
		
GO


IF OBJECT_ID ( 'dbo.DeleteAddress', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[DeleteAddress]
GO

CREATE PROCEDURE [dbo].[DeleteAddress]
	@AddressID int
AS
	
	delete from
		[SalesLT].[Address]  
	where  
        [AddressID] = @AddressID 

	
GO

IF OBJECT_ID ( 'dbo.DeleteAllAddresses', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[DeleteAllAddresses]
GO

CREATE PROCEDURE [dbo].[DeleteAllAddresses]
	@CustomerID int
AS

	DECLARE @DeletedAddress table(
    AddressID int NOT NULL);


	insert into @DeletedAddress
	select
		[AddressID]	
	from 
		[SalesLT].[CustomerAddress]
	where 
		[CustomerID] = @CustomerID
	
	delete from
		[SalesLT].[CustomerAddress]
	where
		[AddressID] in 
			(select * from @DeletedAddress)

	delete from
		[SalesLT].[Address]
	where
		[AddressID] in 
			(select * from @DeletedAddress)

GO


IF OBJECT_ID ( 'dbo.InsertCustomerAddress', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[InsertCustomerAddress]
GO

CREATE PROCEDURE [dbo].[InsertCustomerAddress]
	@CustomerID int,
    @AddressID int, 
    @AddressType nvarchar(50) 
AS
    insert [SalesLT].[CustomerAddress]
	(
		[CustomerID],
		[AddressID],
		[AddressType]
	)
    values 
    (
		@CustomerID,
        @AddressID, 
        @AddressType
	)
GO


IF OBJECT_ID ( 'dbo.UpdateCustomerAddress', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[UpdateCustomerAddress]
GO

CREATE PROCEDURE [dbo].[UpdateCustomerAddress]
	@CustomerID int,
    @AddressID int, 
    @AddressType nvarchar(50)
AS
	update 
		[SalesLT].[CustomerAddress]  
	set  
        [AddressType] = @AddressType
	where 
		[AddressID] = @AddressID and [CustomerID] = @CustomerID
GO

IF OBJECT_ID ( 'dbo.DeleteCustomerAddress', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[DeleteCustomerAddress]
GO

CREATE PROCEDURE [dbo].[DeleteCustomerAddress]
	@AddressID int,
	@CustomerID int
AS

	delete from
		[SalesLT].[CustomerAddress]  
	where  
        [AddressID] = @AddressID and [CustomerID] = @CustomerID

GO

IF OBJECT_ID ( 'dbo.InsertCustomer', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[InsertCustomer]
GO

CREATE PROCEDURE [dbo].[InsertCustomer]
	@SalesPerson nvarchar(256), 
    @CompanyName nvarchar(128),
    @Title nvarchar(8), 
    @FirstName nvarchar(50),
    @MiddleName nvarchar(50),
    @LastName nvarchar(50),
    @Suffix nvarchar(10),
	@EmailAddress nvarchar(50),
	@Phone nvarchar(25),
    @PasswordHash varchar(128),
    @PasswordSalt varchar(10)
AS
	insert [SalesLT].[Customer] 
	(
		[SalesPerson], 
        [CompanyName],
        [Title], 
        [FirstName], 
        [MiddleName], 
        [LastName], 
        [Suffix], 
		[EmailAddress],
		[Phone],
        [PasswordHash], 
        [PasswordSalt]
	)  
    values 
    (
		@SalesPerson, 
        @CompanyName,
        @Title, 
        @FirstName,
        @MiddleName,
        @LastName,
        @Suffix,
		@EmailAddress,
		@Phone,
        @PasswordHash,
        @PasswordSalt
        
	)
	select SCOPE_IDENTITY()
GO

IF OBJECT_ID ( 'dbo.UpdateCustomer', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[UpdateCustomer]
GO

CREATE PROCEDURE [dbo].[UpdateCustomer]
	@CustomerID int,
	@SalesPerson nvarchar(256), 
    @CompanyName nvarchar(128),
    @Title nvarchar(8), 
    @FirstName nvarchar(50),
    @MiddleName nvarchar(50),
    @LastName nvarchar(50),
    @Suffix nvarchar(10),
	@EmailAddress nvarchar(50),
	@Phone nvarchar(25),
    @PasswordHash varchar(128),
    @PasswordSalt varchar(10)
AS
	update 
		[SalesLT].[Customer]  
	set  
        [SalesPerson] = @SalesPerson, 
        [CompanyName] = @CompanyName,
        [Title] = @Title, 
        [FirstName] = @FirstName, 
        [MiddleName] = @MiddleName, 
        [LastName] = @LastName, 
        [Suffix] = @Suffix, 
		[EmailAddress] = @EmailAddress,
		[Phone] = @Phone,
        [PasswordHash] = @PasswordHash, 
        [PasswordSalt] = @PasswordSalt
	where 
		[CustomerID] = @CustomerID
GO

IF OBJECT_ID ( 'dbo.DeleteCustomer', 'P' ) IS NOT NULL 
    DROP PROCEDURE [dbo].[DeleteCustomer]
GO

CREATE PROCEDURE [dbo].[DeleteCustomer]
	@CustomerID int
AS
	delete from
		[SalesLT].[Customer]  
	where  
        [CustomerID] = @CustomerID

GO
