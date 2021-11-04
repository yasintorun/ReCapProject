CREATE TABLE [dbo].[Brands] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL
);

CREATE TABLE [dbo].[Colors] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL
);

CREATE TABLE [dbo].[Cars] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [BrandId]      INT            NOT NULL,
    [ColorId]      INT            NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [Description]  NVARCHAR (MAX) NOT NULL,
    [FindexPuan]   INT            NOT NULL,
    [DailyPrice]   INT            NULL,
    [ModelYear]    INT            NULL,
    [Transmission] NVARCHAR (30)  NULL,
    [SeatCount]    INT            NULL,
    [Fuel]         NVARCHAR (30)  NULL
);

CREATE TABLE [dbo].[CarImages] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CarId]     INT            NOT NULL,
    [ImagePath] NVARCHAR (MAX) NOT NULL,
    [Date]      DATE           NULL
);

CREATE TABLE [dbo].[Users] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Firstname]    NVARCHAR (50)   NOT NULL,
    [Lastname]     NVARCHAR (50)   NOT NULL,
    [Email]        NVARCHAR (50)   NOT NULL,
    [Phone]        NVARCHAR (15)   NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL
);

CREATE TABLE [dbo].[Customers] (
    [UserId]      INT           NOT NULL,
    [CompanyName] NVARCHAR (50) NOT NULL
);

CREATE TABLE [dbo].[Rentals] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [CarId]      INT      NOT NULL,
    [CustomerId] INT      NOT NULL,
    [RentDate]   DATE     NULL,
    [ReturnDate] DATETIME NULL
);

CREATE TABLE [dbo].[Payments] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [RentalId]         INT           NOT NULL,
    [CreditCardNumber] NVARCHAR (16) NOT NULL,
    [Amount]           INT           NOT NULL,
    [Date]             DATETIME      NOT NULL
);

CREATE TABLE [dbo].[CreditCards] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [UserId]         INT            NOT NULL,
    [CardName]       NVARCHAR (100) NOT NULL,
    [CardNumber]     NVARCHAR (16)  NOT NULL,
    [ExpirationDate] NVARCHAR (10)  NOT NULL,
    [CVV]            NVARCHAR (4)   NOT NULL
);

CREATE TABLE [dbo].[OperationClaims] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (500) NOT NULL
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NOT NULL,
    [OperationClaimId] INT NOT NULL
);