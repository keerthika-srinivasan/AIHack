CREATE TABLE [dbo].[Transactions] (
    [Id]                    NUMERIC (18)   IDENTITY (1, 1) NOT NULL,
    [TransactionId]         NUMERIC (18)   NOT NULL,
    [CustomerId]            BIGINT         NOT NULL,
    [IPAddress]             VARCHAR (20)   NULL,
    [Latitude]              VARCHAR (20)   NULL,
    [Longitude]             VARCHAR (20)   NULL,
    [TransactionDT]         DATETIME       NULL,
    [TransactionAmount]     DECIMAL (18)   NULL,
    [IsFradulant]           BIT            NULL,
    [IsFalsePositive]       BIT            NULL,
    [FalsePositiveChangeDT] DATETIME       NULL,
    [FraudScore]            DECIMAL (5, 2) NULL,
    [CategoryId]            BIGINT         NOT NULL,
    [MerchantId]            BIGINT         NOT NULL,
    [ZipCode]               NUMERIC (18)   NOT NULL,
    [Mode]                  BIT            NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transactions_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId]),
    CONSTRAINT [FK_Transactions_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId]),
    CONSTRAINT [FK_Transactions_MerchantDetail] FOREIGN KEY ([MerchantId]) REFERENCES [dbo].[MerchantDetail] ([merchantId]),
    CONSTRAINT [FK_Transactions_Transactions] FOREIGN KEY ([Id]) REFERENCES [dbo].[Transactions] ([Id])
);

