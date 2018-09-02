CREATE PROCEDURE InsertOrUpdateCustomer
@CustomerId bigint =0,
@gender bit NULL,
@DOB date NULL,
@Averagespending decimal(18, 0) NULL,
@LastSpentTransId int NULL,
@LastSpentCategory int NULL,
@LastFaudDetected bit NULL,
@LastFraudDetectedOn datetime NULL,
@ProfileWeightage int NULL,
@CategoryIds varchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	if exists(select 1 from Customer where CustomerId=@CustomerId)
	BEGIN
	UPDATE [dbo].[Customer]
   SET [gender] =isnull( @gender,[gender])
      ,[DOB] = isnull(@DOB,[DOB])
      ,[Averagespending] =ISNULL( @Averagespending,[Averagespending])
      ,[LastSpentTransId] =ISNULL( @LastSpentTransId,[LastSpentTransId])
      ,[LastSpentCategory] =ISNULL( @LastSpentCategory,[LastSpentCategory])
      ,[LastFaudDetected] =ISNULL( @LastFaudDetected,[LastFaudDetected])
      ,[LastFraudDetectedOn] =ISNULL( @LastFraudDetectedOn,[LastFraudDetectedOn])
      ,[ProfileWeightage] =ISNULL( @ProfileWeightage,[ProfileWeightage])
  where CustomerId=@CustomerId

  update CustomerCategory 
  set isactive=0
  where customerid=@customerid and categoryid not in
  (SELECT CAST(value as bigint) as categories FROM STRING_SPLIT(@CategoryIds, ',')); 

  insert into CustomerCategory(customerId,CategoryId,isactive)
  SELECT @customerid,CAST(value as bigint),1 as categories FROM STRING_SPLIT(@CategoryIds, ',');

	END
	ELSe
	BEGIN

	INSERT INTO [dbo].[Customer]
           ([gender]
           ,[DOB]
           ,[Averagespending]
           ,[LastSpentTransId]
           ,[LastSpentCategory]
           ,[LastFaudDetected]
           ,[LastFraudDetectedOn]
           ,[ProfileWeightage])
     VALUES
           (@gender,@DOB,@Averagespending,@LastSpentTransId,@LastSpentCategory,@LastFaudDetected
		   ,@LastFraudDetectedOn,@ProfileWeightage)

	END
	insert into CustomerCategory(customerId,CategoryId,isactive)
  SELECT @customerid,CAST(value as bigint),1 as categories FROM STRING_SPLIT(@CategoryIds, ',');


END