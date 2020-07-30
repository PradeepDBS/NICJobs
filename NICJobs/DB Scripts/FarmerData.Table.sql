IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FarmerData]') AND type in (N'U'))
DROP TABLE [dbo].[FarmerData]
GO

CREATE TABLE [dbo].[FarmerData](
	[Unique_BenID] [varchar](500) NULL,
	[StateName] [varchar](500) NULL,
	[StateCode] [varchar](500) NULL,
	[DistrictName] [varchar](500) NULL,
	[DistrictCode] [varchar](500) NULL,
	[SubDistrictName] [varchar](500) NULL,
	[SubDistrictCode] [varchar](500) NULL,
	[VillageName] [varchar](500) NULL,
	[VillageCode] [varchar](500) NULL,
	[Farmer_Name] [varchar](500) NULL,
	[Father_Name] [varchar](500) NULL
) ON [PRIMARY]
GO


