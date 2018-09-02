
CREATE PROCEDURE GetMerchantDetals
	@merchantid bigint=0,
	@mode bit=0,
	@riskscore int=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from [dbo].[MerchantDetail] where ([merchantId]=@merchantid OR @merchantid=0)
	          AND([RiskScore]=@riskscore OR [RiskScore]=@riskscore)
			  AND ([Mode]=@mode) 
END