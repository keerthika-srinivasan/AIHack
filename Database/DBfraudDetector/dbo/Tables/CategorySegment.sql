CREATE TABLE [dbo].[CategorySegment] (
    [CategorySegementId] BIGINT       IDENTITY (1, 1) NOT NULL,
    [CategoryId]         BIGINT       NOT NULL,
    [gender]             BIT          NOT NULL,
    [minage]             BIGINT       NOT NULL,
    [maxage]             BIGINT       NOT NULL,
    [minamount]          DECIMAL (18) NOT NULL,
    [maxamount]          DECIMAL (18) NOT NULL,
    CONSTRAINT [PK_CategorySegment] PRIMARY KEY CLUSTERED ([CategorySegementId] ASC),
    CONSTRAINT [FK_CategorySegment_CategorySegment] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);

