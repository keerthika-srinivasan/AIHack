CREATE TABLE [dbo].[Category] (
    [CategoryId]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

