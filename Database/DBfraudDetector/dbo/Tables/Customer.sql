CREATE TABLE [dbo].[Customer] (
    [CustomerId]          BIGINT       IDENTITY (1, 1) NOT NULL,
    [gender]              BIT          NULL,
    [DOB]                 DATE         NULL,
    [Averagespending]     DECIMAL (18) NULL,
    [LastSpentTransId]    INT          NULL,
    [LastSpentCategory]   INT          NULL,
    [LastFaudDetected]    BIT          NULL,
    [LastFraudDetectedOn] DATETIME     NULL,
    [ProfileWeightage]    INT          NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

