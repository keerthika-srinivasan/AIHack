CREATE PROCEDURE  InsertOrUpdateCategory
	-- Add the parameters for the stored procedure here
	@categoryId bigint,
	@categoryname nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT 1   FROM   [dbo].[Category]    WHERE  [CategoryId] = @categoryId)
	UPDATE [dbo].[Category]
        SET   [CategoryName]=@categoryname
		WHERE  [CategoryId] = @categoryId
		ELSE
		INSERT INTO [dbo].[Category] ([CategoryName])
         VALUES (@categoryname)
END