CREATE TABLE [dbo].[MerchantDetail] (
    [merchantId]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [MerchantName]    VARCHAR (100) NULL,
    [Mode]            BIT           NULL,
    [IPAddress]       VARCHAR (50)  NULL,
    [ThresholdAmount] DECIMAL (18)  NULL,
    [Location]        NUMERIC (10)  NULL,
    [GeoIp]           VARCHAR (100) NULL,
    [RiskScore]       INT           NULL,
    [CategoryId]      BIGINT        NULL,
    CONSTRAINT [PK_MerchantDetail] PRIMARY KEY CLUSTERED ([merchantId] ASC),
    CONSTRAINT [FK_MerchantDetail_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);

