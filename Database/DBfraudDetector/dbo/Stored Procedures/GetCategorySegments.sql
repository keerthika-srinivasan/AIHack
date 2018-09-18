
CREATE PROCEDURE [dbo].[GetCategorySegments]
@CategoryId int=0
AS
BEGIN
	SET NOCOUNT ON;

	select *
	 from 
	 [dbo].CategorySegment CG 
	 join [dbo].category C 
	 on C.categoryId=CG.categoryId
	 and CG.categoryid=@CategoryId or @CategoryId=0
	 order by C.CategoryId, CG.CategorySegementId
END