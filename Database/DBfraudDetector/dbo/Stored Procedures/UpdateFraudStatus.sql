CREATE PROCEDURE UpdateFraudStatus
	(
 @transactionId numeric(18,0),	
 @score decimal(5,2),
 @isFrad bit)
AS
BEGIN
	SET NOCOUNT ON;

	update Transactions 
	set IsFradulant=@isFrad, FraudScore=@score
	where transactionid=@transactionid

  END