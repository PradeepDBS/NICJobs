DROP PROCEDURE IF EXISTS [dbo].[uasp_FarmerData]
GO

CREATE PROC [dbo].[uasp_FarmerData]
@Unique_BenID varchar (500),
@StateName varchar(500),	
@StateCode varchar(500),
@DistrictName varchar(500),
@DistrictCode varchar(500),
@SubDistrictName varchar(500),
@SubDistrictCode varchar(500),
@VillageName varchar(500),
@VillageCode varchar(500),
@Farmer_Name varchar(500),
@Father_Name varchar(500)

AS BEGIN 

	Insert into FarmerData
				values (@Unique_BenID,@StateName,@StateCode,@DistrictName,@DistrictCode,@SubDistrictName,
				@SubDistrictCode,@VillageName,@VillageCode,@Farmer_Name,@Father_Name )

END
GO


