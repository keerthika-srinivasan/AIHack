CREATE PROCEDURE [dbo].[GetCustomers]
	@CustomerId bigint=0
AS
BEGIN
	select * from dbo.Customer C where CustomerId=@customerid

	if(@CustomerId >0)
	begin
select cc.*,C.Categoryname, CG.* from CustomerCategory CC join
[dbo].CategorySegment CG on CG.CategoryId=CC.CategoryId
join [dbo].[Category] C on c.CategoryId=CG.CategoryId
and CC.CustomerId=@CustomerId
end
END