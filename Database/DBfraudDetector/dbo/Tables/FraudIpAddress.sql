CREATE TABLE [dbo].[FraudIpAddress] (
    [IpAddress]        VARCHAR (50) NOT NULL,
    [LastIdentifiedOn] DATETIME     NOT NULL,
    [DetectedCount]    NUMERIC (10) NOT NULL
);

