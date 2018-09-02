create PROCEDURE UpdateFraudStatusFromUI
	(
 @transactionId numeric(18,0),	@status bit)
AS
BEGIN
	SET NOCOUNT ON;

	update Transactions 
	set isfalsePositive=@status, FalsePositiveChangeDT=GETDATE()
	where transactionid=@transactionid

  END