CREATE PROCEDURE SearchTransactionOnFraud
	(
 @cardNo varchar(20)=1254,
@transactionId numeric(18,0)=12456,
@TransDateFilterFrom datetime='2018-05-26 15:59:23.147',
@IpAddress varchar(20)='10.12.15.2')
AS
BEGIN
	SET NOCOUNT ON;

--Get Min & Max Transaction Amount Except Current Transaction for same Card No
select AVG(transactionAmount) Avg, max(transactionAmount) max from Transactions where cardno=@cardNo
and TransactionId!=@transactionId;

 --Check Records count on time difference
  select count(*) cnt from Transactions where CardNo=@cardNo and TransactionDT>=@TransDateFilterFrom
  
  --Check record count on IP for same time period
  select IPAddress,count(*) cnt
  from Transactions
  where TransactionDT>=@TransDateFilterFrom
  and IPAddress=@IpAddress
  group by IPAddress


  --Check Record count on Fraud Transactions on same IP earlier & also confirmed as fraud
  select * from Transactions where IPAddress=@IpAddress and IsFradulant=1

  END