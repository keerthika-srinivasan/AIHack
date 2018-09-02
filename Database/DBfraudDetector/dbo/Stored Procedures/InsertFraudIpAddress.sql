CREATE PROCEDURE InsertFraudIpAddress
	@ipAddress varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	if exists(select * from FraudIpAddress where IpAddress=@ipAddress)
	BEGIN
		update FraudIpAddress
		set LastIdentifiedOn=GETDATE(),
		DetectedCount=DetectedCount+1;
	END
	else
	BEGIN
			insert into FraudIpAddress values(@ipAddress,GETDATE(),1);
	end
	END