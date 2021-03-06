
/****** Object:  Database [LQT]    Script Date: 03/07/2011 11:51:50 ******/
CREATE DATABASE [LQT]
go
use  [LQT]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ForecastSiteCategoryProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SiteCategoryID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ForecastID] [int] NOT NULL,
 CONSTRAINT [PK_ForecastSiteCategoryProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ForecastSiteTest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NOT NULL,
	[TestID] [int] NOT NULL,
	[ForecastID] [int] NOT NULL,
	[InstrumentID] [int] NOT NULL,
	[SiteReported] [bit] NOT NULL,
 CONSTRAINT [PK_ForecastSiteTest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ForecastSiteCategoryTest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SiteCategoryID] [int] NOT NULL,
	[TestID] [int] NOT NULL,
	[ForecastID] [int] NOT NULL,
	[InstrumentID] [int] NOT NULL,
	[SiteReported] [bit] NOT NULL,
 CONSTRAINT [PK_ForecastSiteCategoryTest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QCProtocol](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PerNumberOfTests] [int] NULL,
	[PerDay] [int] NULL,
	[PerWeek] [int] NULL,
	[PerMonth] [int] NULL,
	[TestID] [int] NULL,
	[InstrumentID] [int] NULL,
 CONSTRAINT [PK_QCProtocol] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SiteCategorySite](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SiteCategoryID] [int] NOT NULL,
	[SiteID] [int] NOT NULL,
 CONSTRAINT [PK_SiteCategorySite] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ListOfTests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [nvarchar](96) NOT NULL,
	[TGID] [int] NULL,
 CONSTRAINT [PK_ListOfTests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Methodology](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Consumption] [bit] NOT NULL,
	[ServiceStatstics] [bit] NOT NULL,
	[Demographic] [bit] NOT NULL,
	[LeanierRegression] [bit] NOT NULL,
	[MovingAvg] [bit] NOT NULL,
	[WeightedAvg] [bit] NOT NULL,
	[SimpleAvg] [bit] NOT NULL,
	[ApplyedPercentageIncrease] [bit] NOT NULL,
	[SpecifyPercentage] [int] NULL,
	[ForecastID] [int] NULL,
 CONSTRAINT [PK_Methodology] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Region](
	[RegionID] [int] IDENTITY(1,1) NOT NULL,
	[RegionName] [nvarchar](64) NOT NULL,
	[ShortName] [nvarchar](8) NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[RegionID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Instrument](
	[InstrumentID] [int] IDENTITY(1,1) NOT NULL,
	[InstrumentName] [nvarchar](64) NOT NULL,
	[MaxThroughPut] [int] NULL,
 CONSTRAINT [PK_Instrument] PRIMARY KEY CLUSTERED 
(
	[InstrumentID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ProductType](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](64) NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SiteCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](64) NOT NULL,
	[cStatus] [int] NULL,
 CONSTRAINT [PK_SiteCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SiteTestingCategoryTestProjectedVolume](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PReportStartDate] [datetime] NULL,
	[PReportStopDate] [datetime] NULL,
	[PDuration] [nvarchar](255) NULL,
	[VolumeProjected] [float] NULL,
	[LR] [int] NULL,
	[SemiAvg] [int] NULL,
	[Percentage] [int] NULL,
	[PUse] [bit] NOT NULL,
	[SiteCategoryID] [int] NULL,
	[TestID] [int] NULL,
	[ForecastID] [int] NULL,
	[InstrumentID] [int] NULL,
 CONSTRAINT [PK_SiteTestingCategoryTestProjectedVolume] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HistoricalTestingCategoryTestingVolume](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportStartDate] [datetime] NULL,
	[ReportStopDate] [datetime] NULL,
	[Duration] [nvarchar](255) NULL,
	[Volume] [float] NULL,
	[PUse] [bit] NOT NULL,
	[SiteCategoryID] [int] NULL,
	[TestID] [int] NULL,
	[ForecastID] [int] NULL,
	[InstrumentID] [int] NULL,
 CONSTRAINT [PK_HistoricalTestingCategoryTestingVolume] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ForecastInfo](
	[ForecastID] [int] IDENTITY(1,1) NOT NULL,
	[ForecastNo] [nvarchar](32) NOT NULL,
	[Methodology] [nvarchar](32) NOT NULL,
	[DataUsage] [nvarchar](16) NULL,
	[Status] [nvarchar](16) NOT NULL,
	[Period] [nvarchar](16) NULL,
	[ForecastDate] [datetime] NOT NULL,
	[Extension] [int] NULL,
	[ScopeOfTheForecast] [nvarchar](24) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Note] [nvarchar](256) NULL,
	[LastNo] [int] NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_ForecastInfo] PRIMARY KEY CLUSTERED 
(
	[ForecastID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SiteHistoricalProductConsumption](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CReportStartDate] [datetime] NULL,
	[CReportStopDate] [datetime] NULL,
	[AmountUsed] [float] NULL,
	[CDuration] [nvarchar](255) NULL,
	[WestageInPercent] [int] NULL,
	[Cuse] [bit] NOT NULL,
	[SiteID] [int] NULL,
	[ProductID] [int] NULL,
	[ForecastID] [int] NULL,
	[DatePKSP] [datetime] NULL,
 CONSTRAINT [PK_SiteHistoricalProductConsumption] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SiteProductProjected](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CReportStartDate] [datetime] NULL,
	[CReportStopDate] [datetime] NULL,
	[AmountUsed] [float] NULL,
	[LR] [float] NULL,
	[SemiAvg] [float] NULL,
	[Percentage] [float] NULL,
	[CDuration] [nvarchar](255) NULL,
	[WestageInPercent] [int] NULL,
	[Cuse] [bit] NOT NULL,
	[SiteID] [int] NULL,
	[ProductID] [int] NULL,
	[ForecastID] [int] NULL,
	[DatePKSP] [datetime] NULL,
 CONSTRAINT [PK_SiteProductProjected] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TestingProjectedVolume](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PReportStartDate] [datetime] NULL,
	[PReportStopDate] [datetime] NULL,
	[PDuration] [nvarchar](255) NULL,
	[VolumeProjected] [float] NULL,
	[LR] [int] NULL,
	[SemiAvg] [int] NULL,
	[Percentage] [int] NULL,
	[PUse] [bit] NOT NULL,
	[SiteID] [int] NULL,
	[TestID] [int] NULL,
	[ForecastID] [int] NULL,
	[InstrumentID] [int] NULL,
 CONSTRAINT [PK_TestingProjectedVolume] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HistoricalTestingVolume](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportStartDate] [datetime] NULL,
	[ReportStopDate] [datetime] NULL,
	[Duration] [nvarchar](255) NULL,
	[Volume] [float] NULL,
	[PUse] [bit] NOT NULL,
	[SiteID] [int] NULL,
	[TestID] [int] NULL,
	[ForecastID] [int] NULL,
	[InstrumentID] [int] NULL,
 CONSTRAINT [PK_HistoricalTestingVolume] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TestInstrument](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TestID] [int] NOT NULL,
	[InstrumentID] [int] NOT NULL,
 CONSTRAINT [PK_TestInstrument] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ProductUsagePerTest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[TestID] [int] NOT NULL,
	[InstrumentID] [int] NOT NULL,
	[QuantityNeededPerTest] [float] NULL,
	[QNeededPerQC] [int] NULL,
	[QNeededPerMonth] [int] NULL,
	[QNeededPerDay] [int] NULL,
	[QNeededPerShutdown] [int] NULL,
	[QNeededPerCleaning] [int] NULL,
 CONSTRAINT [PK_ProductUsagePerTest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SiteInstrument](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InstrumentID] [int] NOT NULL,
	[SiteID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_SiteInstrument] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TestingArea](
	[TestingAreaID] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_TestingArea] PRIMARY KEY CLUSTERED 
(
	[TestingAreaID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SiteCategoryHistoricalProductConsumption](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CReportStartDate] [datetime] NULL,
	[CReportStopDate] [datetime] NULL,
	[AmountUsed] [decimal](18, 2) NULL,
	[CDuration] [nvarchar](255) NULL,
	[WestageInPercent] [int] NULL,
	[Cuse] [bit] NOT NULL,
	[SiteCategoryID] [int] NULL,
	[ProductID] [int] NULL,
	[ForecastID] [int] NULL,
	[DatePKSP] [datetime] NULL,
 CONSTRAINT [PK_SiteCategoryHistoricalProductConsumption] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SiteCategoryProductProjected](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CReportStartDate] [datetime] NULL,
	[CReportStopDate] [datetime] NULL,
	[AmountUsed] [float] NULL,
	[LR] [float] NULL,
	[SemiAvg] [float] NULL,
	[Percentage] [float] NULL,
	[CDuration] [nvarchar](255) NULL,
	[WestageInPercent] [int] NULL,
	[Cuse] [bit] NOT NULL,
	[SiteCategoryID] [int] NULL,
	[ProductID] [int] NULL,
	[ForecastID] [int] NULL,
	[DatePKSP] [datetime] NULL,
 CONSTRAINT [PK_SiteCategoryProductProjected] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [FTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastId] [int] NOT NULL,
	[ForecastSiteId] [int] NULL,
	[SiteId] [int] NULL,
	[CategoryId] [int] NULL,
	[ProductId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[GroupTitle] [nvarchar](64) NULL,
 CONSTRAINT [PK_FTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ForecastSiteProduct](
	[ForecastSiteID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CDuration] [nvarchar](24) NULL,
	[AmountUsed] [decimal](18, 2) NULL,
	[Westage] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ForecastSiteProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ForecastCategoryProduct](
	[CategoryID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AmountUsed] [decimal](18, 4) NULL,
	[CDuration] [nvarchar](32) NULL,
	[Westage] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ForecastCategoryProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ForecastCategorySite](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[SiteID] [int] NOT NULL,
 CONSTRAINT [PK_ForecastCategorySite] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ForecastSite](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastInfoId] [int] NOT NULL,
	[SiteId] [int] NOT NULL,
 CONSTRAINT [PK_ForecastSite] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ForecastNRSite](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastSiteId] [int] NOT NULL,
	[NReportedSiteId] [int] NOT NULL,
 CONSTRAINT [PK_ForecastNRSite] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Test](
	[TestingAreaID] [int] NOT NULL,
	[TestingGroupID] [int] NOT NULL,
	[TestID] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[TestID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Site](
	[RegionID] [int] NOT NULL,
	[SiteID] [int] IDENTITY(1,1) NOT NULL,
	[SiteName] [nvarchar](64) NOT NULL,
	[CurrentlyOpen] [bit] NOT NULL,
	[OpeningDate] [datetime] NULL,
	[ClosingDate] [datetime] NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MasterProduct](
	[ProductTypeId] [int] NOT NULL,
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](64) NOT NULL,
	[SerialNo] [nvarchar](16) NULL,
	[Specification] [nvarchar](256) NULL,
	[BasicUnit] [nvarchar](16) NULL,
	[PackagingSize] [float] NULL,
	[Price] [decimal](18, 2) NULL,
	[ProductNote] [nvarchar](400) NULL,
 CONSTRAINT [PK_MasterProduct] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TestingGroup](
	[TestingAreaID] [int] NOT NULL,
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](64) NULL,
 CONSTRAINT [PK_TestingGroup] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [FTableRow](
	[FTableId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Instance] [int] NOT NULL,
	[Value] [decimal](18, 4) NULL,
	[Forecast] [decimal](18, 4) NULL,
	[Holdout] [bit] NULL,
	[Error] [decimal](18, 4) NULL,
	[AbsoluteError] [decimal](18, 4) NULL,
	[PercentError] [decimal](18, 4) NULL,
	[AbsolutePercentError] [decimal](18, 4) NULL,
	[Duration] [nvarchar](24) NULL,
 CONSTRAINT [PK_FTableRow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [FResult](
	[FTableId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Instance] [int] NOT NULL,
	[Forecast] [decimal](18, 4) NOT NULL,
	[Duration] [nvarchar](24) NULL,
	[Cost] [decimal](18, 4) NULL,
 CONSTRAINT [PK_FResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ForecastCategory](
	[ForecastId] [int] NOT NULL,
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_ForecastCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [FTable]  WITH CHECK ADD  CONSTRAINT [FK_FTable_MasterProduct] FOREIGN KEY([ProductId])
REFERENCES [MasterProduct] ([ProductID])
GO
ALTER TABLE [FTable] CHECK CONSTRAINT [FK_FTable_MasterProduct]
GO
ALTER TABLE [ForecastSiteProduct]  WITH CHECK ADD  CONSTRAINT [FK_ForecastSiteProduct_ForecastSite] FOREIGN KEY([ForecastSiteID])
REFERENCES [ForecastSite] ([Id])
GO
ALTER TABLE [ForecastSiteProduct] CHECK CONSTRAINT [FK_ForecastSiteProduct_ForecastSite]
GO
ALTER TABLE [ForecastSiteProduct]  WITH CHECK ADD  CONSTRAINT [FK_ForecastSiteProduct_MasterProduct] FOREIGN KEY([ProductID])
REFERENCES [MasterProduct] ([ProductID])
GO
ALTER TABLE [ForecastSiteProduct] CHECK CONSTRAINT [FK_ForecastSiteProduct_MasterProduct]
GO
ALTER TABLE [ForecastCategoryProduct]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategoryProduct_ForecastCategory] FOREIGN KEY([CategoryID])
REFERENCES [ForecastCategory] ([CategoryId])
GO
ALTER TABLE [ForecastCategoryProduct] CHECK CONSTRAINT [FK_ForecastCategoryProduct_ForecastCategory]
GO
ALTER TABLE [ForecastCategoryProduct]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategoryProduct_MasterProduct] FOREIGN KEY([ProductID])
REFERENCES [MasterProduct] ([ProductID])
GO
ALTER TABLE [ForecastCategoryProduct] CHECK CONSTRAINT [FK_ForecastCategoryProduct_MasterProduct]
GO
ALTER TABLE [ForecastCategorySite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategorySite_ForecastCategory] FOREIGN KEY([CategoryID])
REFERENCES [ForecastCategory] ([CategoryId])
GO
ALTER TABLE [ForecastCategorySite] CHECK CONSTRAINT [FK_ForecastCategorySite_ForecastCategory]
GO
ALTER TABLE [ForecastCategorySite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategorySite_Site] FOREIGN KEY([SiteID])
REFERENCES [Site] ([SiteID])
GO
ALTER TABLE [ForecastCategorySite] CHECK CONSTRAINT [FK_ForecastCategorySite_Site]
GO
ALTER TABLE [ForecastSite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastSite_ForecastInfo] FOREIGN KEY([ForecastInfoId])
REFERENCES [ForecastInfo] ([ForecastID])
GO
ALTER TABLE [ForecastSite] CHECK CONSTRAINT [FK_ForecastSite_ForecastInfo]
GO
ALTER TABLE [ForecastSite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastSite_Site] FOREIGN KEY([SiteId])
REFERENCES [Site] ([SiteID])
GO
ALTER TABLE [ForecastSite] CHECK CONSTRAINT [FK_ForecastSite_Site]
GO
ALTER TABLE [ForecastNRSite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastNRSite_ForecastSite] FOREIGN KEY([ForecastSiteId])
REFERENCES [ForecastSite] ([Id])
GO
ALTER TABLE [ForecastNRSite] CHECK CONSTRAINT [FK_ForecastNRSite_ForecastSite]
GO
ALTER TABLE [ForecastNRSite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastNRSite_Site] FOREIGN KEY([NReportedSiteId])
REFERENCES [Site] ([SiteID])
GO
ALTER TABLE [ForecastNRSite] CHECK CONSTRAINT [FK_ForecastNRSite_Site]
GO
ALTER TABLE [Test]  WITH CHECK ADD  CONSTRAINT [FK_Test_TestingGroup] FOREIGN KEY([TestingGroupID])
REFERENCES [TestingGroup] ([GroupID])
GO
ALTER TABLE [Test] CHECK CONSTRAINT [FK_Test_TestingGroup]
GO
ALTER TABLE [Site]  WITH CHECK ADD  CONSTRAINT [FK_Site_Region] FOREIGN KEY([RegionID])
REFERENCES [Region] ([RegionID])
GO
ALTER TABLE [Site] CHECK CONSTRAINT [FK_Site_Region]
GO
ALTER TABLE [MasterProduct]  WITH CHECK ADD  CONSTRAINT [FK_MasterProduct_ProductType] FOREIGN KEY([ProductTypeId])
REFERENCES [ProductType] ([TypeID])
GO
ALTER TABLE [MasterProduct] CHECK CONSTRAINT [FK_MasterProduct_ProductType]
GO
ALTER TABLE [TestingGroup]  WITH CHECK ADD  CONSTRAINT [FK_TestingGroup_TestingArea] FOREIGN KEY([TestingAreaID])
REFERENCES [TestingArea] ([TestingAreaID])
GO
ALTER TABLE [TestingGroup] CHECK CONSTRAINT [FK_TestingGroup_TestingArea]
GO
ALTER TABLE [FTableRow]  WITH CHECK ADD  CONSTRAINT [FK_FTableRow_FTable] FOREIGN KEY([FTableId])
REFERENCES [FTable] ([Id])
GO
ALTER TABLE [FTableRow] CHECK CONSTRAINT [FK_FTableRow_FTable]
GO
ALTER TABLE [FResult]  WITH CHECK ADD  CONSTRAINT [FK_FResult_FTable] FOREIGN KEY([FTableId])
REFERENCES [FTable] ([Id])
GO
ALTER TABLE [FResult] CHECK CONSTRAINT [FK_FResult_FTable]
GO
ALTER TABLE [ForecastCategory]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategory_ForecastInfo] FOREIGN KEY([ForecastId])
REFERENCES [ForecastInfo] ([ForecastID])
GO
ALTER TABLE [ForecastCategory] CHECK CONSTRAINT [FK_ForecastCategory_ForecastInfo]
