CREATE PROCEDURE [dbo].[InsertTransaction]
	(@TransactionId numeric(18,0),
           @CardNo varchar(20),
           @IPAddress varchar(20),
           @Latitude varchar(20),
           @Longitude varchar(20),
           @TransactionAmount decimal(18,0),
		   @TransactionDt datetime)
AS
BEGIN
	SET NOCOUNT ON;

INSERT INTO [dbo].[Transactions]([TransactionId],[CardNo],[IPAddress],[Latitude]
           ,[Longitude],[TransactionDT],[TransactionAmount],[IsFradulant]
		   ,[IsFalsePositive],[FalsePositiveChangeDT],[FraudScore])
     VALUES
          (@TransactionId,
           @CardNo,
           @IPAddress,
           @Latitude,
           @Longitude, 
           @TransactionDt, 
           @TransactionAmount, 
           0, 0,null,-1)	--Default insert set default values

END



SELECT * FROM Transactions