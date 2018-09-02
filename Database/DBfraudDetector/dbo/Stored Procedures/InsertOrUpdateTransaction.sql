create PROCEDURE InsertOrUpdateTransaction
	(
	@Id numeric(18, 0) null,
	@TransactionId numeric(18, 0),
	@CustomerId bigint null,
	@IPAddress varchar(20) NULL,
	@Latitude varchar(20) NULL,
	@Longitude varchar(20) NULL,
	@TransactionDT datetime NULL,
	@TransactionAmount decimal(18, 0) NULL,
	@IsFradulant bit NULL,
	@IsFalsePositive bit NULL,
	@FalsePositiveChangeDT datetime NULL,
	@FraudScore decimal(5, 2) NULL,
	@CategoryId bigint null,
	@MerchantId bigint null,
	@ZipCode numeric(18, 0) null,
	@Mode bit null
	)
AS
BEGIN
	if not exists(select 1 from [dbo].Transactions where Id=@Id)
	BEGIN
		INSERT INTO [dbo].[Transactions]
           ([TransactionId]
           ,[CustomerId]
           ,[IPAddress]
           ,[Latitude]
           ,[Longitude]
           ,[TransactionDT]
           ,[TransactionAmount]
           ,[IsFradulant]
           ,[IsFalsePositive]
           ,[FalsePositiveChangeDT]
           ,[FraudScore]
           ,[CategoryId]
           ,[MerchantId]
           ,[ZipCode]
           ,[Mode])
     VALUES
	 (
	 @TransactionId,
	@CustomerId,
	@IPAddress,
	@Latitude ,
	@Longitude ,
	@TransactionDT ,
	@TransactionAmount ,
	@IsFradulant ,
	@IsFalsePositive ,
	@FalsePositiveChangeDT ,
	@FraudScore ,
	@CategoryId ,
	@MerchantId ,
	@ZipCode,
	@Mode )
	END
	ELSE
	BEGIN
	update transactions
	set isfradulant=ISNULL(@IsFradulant,IsFradulant),
	 IsFalsePositive=ISNULL(@IsFalsePositive,IsFalsePositive),
	 FalsePositiveChangeDT=ISNULL(@FalsePositiveChangeDT,FalsePositiveChangeDT),
	 FraudScore=ISNULL(@FraudScore,FraudScore)
	 where  Id=@Id
	END

END