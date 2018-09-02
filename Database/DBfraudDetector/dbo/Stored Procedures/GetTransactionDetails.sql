
CREATE PROCEDURE [dbo].[GetTransactionDetails]
	@Transactionid bigint
AS
BEGIN
	
	SET NOCOUNT ON;
	IF @Transactionid>0
	BEGIN
		DECLARE  @TransactionDetails AS TABLE(
 [Id] [numeric](18, 0) ,
	[TransactionId] [numeric](18, 0) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	
	[TransactionAmount] [decimal](18, 0) NULL,
	
	[CategoryId] [bigint] NOT NULL,
	[MerchantId] [bigint] NOT NULL
	)  
	
	 
	 INSERT INTO @TransactionDetails
	SELECT [Id] ,[TransactionId],[CustomerId] ,[TransactionAmount],[CategoryId],[MerchantId]  FROM dbo.Transactions Where TransactionId=@Transactionid
	SELECT * FROM Transactions
	SELECT *  FROM dbo.Customer where dbo.Customer.CustomerId IN (Select CustomerId  from @TransactionDetails)
	SELECT * FROM dbo.CategorySegment where dbo.CategorySegment.CategoryId IN (Select CategoryId from @TransactionDetails)
	SELECT * FROM MerchantDetail where dbo.MerchantDetail.merchantId IN (Select merchantId from @TransactionDetails)

END
	
ELSE
BEGIN
       SELECT TOP 100 * FROM  Transactions Order by Id
	   END

END