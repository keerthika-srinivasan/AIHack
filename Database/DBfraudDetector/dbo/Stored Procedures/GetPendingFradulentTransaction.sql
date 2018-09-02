CREATE PROCEDURE [dbo].[GetPendingFradulentTransaction]
@ID VARCHAR(18) =0
AS
BEGIN	
	SET NOCOUNT ON;
	select id,TransactionId,TransactionDT,CardNo from Transactions
	where id>@ID and
	 IsFradulant=1 and ISNULL(IsFalsePositive,0)!=1 and FalsePositiveChangeDT is null
	--order by id desc
END