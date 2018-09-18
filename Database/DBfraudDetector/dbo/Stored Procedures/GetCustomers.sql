CREATE PROCEDURE [dbo].[GetCustomers]
	@CustomerId bigint=0
AS
BEGIN
	select * from dbo.Customer C where CustomerId=@customerid

	if(@CustomerId >0)
	begin
	declare @age bigint;
	set @age=(SELECT top 1 DATEDIFF(month, dob,CONVERT(date, getdate()))/12  from dbo.Customer C where CustomerId=@customerid)

select cc.*,C.Categoryname, CG.* from CustomerCategory CC join
[dbo].CategorySegment CG on CG.CategoryId=CC.CategoryId
join [dbo].[Category] C on c.CategoryId=CG.CategoryId
and @age  between minage and maxage
and CC.CustomerId=@CustomerId;


END
end