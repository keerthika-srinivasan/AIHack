CREATE PROCEDURE FindFraudIpAddress
	@ipAddress varchar(50),
	@Count numeric(10,0) output
AS
BEGIN
	SET NOCOUNT ON;
	if exists(select * from FraudIpAddress where IpAddress=@ipAddress)
	begin
		select top 1 @Count=detectedCount from FraudIpAddress where IpAddress=@ipAddress
	end
	else
	BEGIN
	set @Count=0
	END

	END