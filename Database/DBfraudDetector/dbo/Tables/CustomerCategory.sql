CREATE TABLE [dbo].[CustomerCategory] (
    [CustomerId] INT    NOT NULL,
    [CategoryId] BIGINT NOT NULL,
    [IsActive]   BIT    NULL,
    CONSTRAINT [FK_CustomerCategory_Customer] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);

