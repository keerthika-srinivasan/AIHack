CREATE PROCEDURE GetCategories 
	@categoryname varchar(max)=null,
	@categoryid bigint=0
AS
BEGIN
		SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from [dbo].[Category] where (CategoryId=@categoryid OR @categoryid=0) AND (CategoryName=@categoryname OR @categoryname=null)
END