CREATE TABLE [dbo].[CardDetails] (
    [CardNumber]           NUMERIC (16) IDENTITY (1, 1) NOT NULL,
    [IsActive]             BIT          NOT NULL,
    [LastTransactionid]    NUMERIC (18) NULL,
    [AllowedDistanceLimit] DECIMAL (18) NULL
);

