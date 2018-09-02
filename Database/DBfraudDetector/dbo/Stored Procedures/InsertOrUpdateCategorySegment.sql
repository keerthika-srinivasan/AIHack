
CREATE PROCEDURE [dbo].[InsertOrUpdateCategorySegment]
(
@gender bit,
@minage bigint ,
@maxage bigint ,
@CategoryId int ,
@minamount decimal(18, 0) ,
@maxamount decimal(18, 0) ,
@CategorySegementId bigint=0)
AS
BEGIN
	SET NOCOUNT ON;

	if exists(select count(1) from [dbo].[CategorySegment] where [CategorySegementId]=@CategorySegementId)
	begin
	 UPDATE [dbo].[CategorySegment]
   SET 
      [CategoryId] = @CategoryId
      ,[gender] = @gender
      ,[minage] = @minage
      ,[maxage] = @maxage
      ,[minamount] = @minamount
      ,[maxamount] = @maxamount
 WHERE  CategorySegementId=@CategorySegementId
	END
	else
	BEGIN
	INSERT INTO [dbo].[CategorySegment]
           ([CategoryId]
           ,[gender]
           ,[minage]
           ,[maxage]
           ,[minamount]
           ,[maxamount])
     VALUES
           (
		   @CategoryId ,
@gender ,
@minage ,
@maxage ,
@minamount ,
@maxamount 		   )
	END


END