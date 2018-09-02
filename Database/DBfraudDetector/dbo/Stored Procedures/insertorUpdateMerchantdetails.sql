-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE insertorUpdateMerchantdetails
	-- Add the parameters for the stored procedure here
	@merchantname varchar(max),
	@merchantid bigint,
	@mode bit,
	@IPAddress varchar(max),
	@Location numeric,
	@RiskScore int ,
	@ThresholdAmount decimal,
	@GeoIP varchar(max),
	@categoryid bigint

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT 1   FROM   [dbo].[MerchantDetail]    WHERE  [merchantId] = @merchantid)
	UPDATE [dbo].[MerchantDetail]
        SET   [MerchantName]=@merchantname,[Mode]=@mode,
			  [IPAddress]=@IPAddress,[ThresholdAmount]=@ThresholdAmount,
			  [Location]=@Location,[GeoIp]=@GeoIp,[RiskScore]=@RiskScore
		WHERE [merchantId]=@merchantid  
		ELSE
		INSERT INTO [dbo].[MerchantDetail] ([MerchantName],[Mode],[IPAddress],[ThresholdAmount],[Location],[GeoIp],[RiskScore],[CategoryId])
         VALUES (@merchantname,@mode,@IPAddress,@ThresholdAmount,@Location,@GeoIP,@RiskScore,@categoryid)
END