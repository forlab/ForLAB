SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingArea](
	[TestingAreaID] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [nvarchar](64) NOT NULL,
	[UseInDemography] [bit] NULL,
	[Category] [nvarchar](50) NULL,
 CONSTRAINT [PK_TestingArea] PRIMARY KEY CLUSTERED 
(
	[TestingAreaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForecastInfo](
	[ForecastID] [int] IDENTITY(1,1) NOT NULL,
	[ForecastNo] [nvarchar](32) NOT NULL,
	[Methodology] [nvarchar](32) NOT NULL,
	[DataUsage] [nvarchar](16) NOT NULL,
	[Status] [nvarchar](16) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[Period] [nvarchar](16) NOT NULL,
	[MonthInPeriod] [int] NULL,
	[Extension] [int] NOT NULL,
	[ScopeOfTheForecast] [nvarchar](24) NULL,
	[Note] [nvarchar](256) NULL,
	[ActualCount] [int] NULL,
	[LastUpdated] [datetime] NULL,
	[ForecastDate] [datetime] NULL,
	[Method] [nvarchar](16) NULL,
	[Westage] [decimal](18, 2) NULL,
	[Scaleup] [decimal](18, 2) NULL,
	[ROrder] [int] NULL,
	[SlowMovingPeriod] [nvarchar](16) NULL,
 CONSTRAINT [PK_ForecastInfo] PRIMARY KEY CLUSTERED 
(
	[ForecastID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetMaxForecastDate] 
(
	@ForecastPeriod varchar(200),
	@ForecastStartDate datetime,
	@Extension int
)
RETURNS Datetime
AS
BEGIN
	DECLARE @EndDate datetime
	DECLARE @MonthAdded int
	set @MonthAdded=@Extension
	
	IF(@ForecastPeriod='Bimonthly')--BY_MONTHLY
		SET @MonthAdded=@Extension*2
	IF(@ForecastPeriod='Quarterly')--QUARTERLY
		SET @MonthAdded=@Extension*3
	IF(@ForecastPeriod='Yearly')--YEARLY
		SET @MonthAdded=@Extension*12
	
	SET @EndDate=dateadd(month,@MonthAdded,@ForecastStartDate)
	
	RETURN @EndDate
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChemandOtherNumberofTest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastId] [int] NULL,
	[Platform] [int] NULL,
	[SiteId] [int] NULL,
	[TestId] [int] NULL,
	[TestBasedOnProtocols] [float] NULL,
	[SymptomDirectedTests] [float] NULL,
	[RepeatedDuetoClinicalReq] [float] NULL,
	[InvalidTestandWastage] [float] NULL,
	[BufferStock] [float] NULL,
	[ReagentstoRunControls] [float] NULL,
	[TestName] [nvarchar](32) NULL,
 CONSTRAINT [PK_ChemandHemaNumberofTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CD4TestNumber](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastId] [int] NULL,
	[SiteId] [int] NULL,
	[ExistingPIT] [float] NULL,
	[ExistingPIPreART] [float] NULL,
	[CD4BaseLineTest] [float] NULL,
	[NewPatienttoTreatment] [float] NULL,
	[NewPatientstoPreART] [float] NULL,
	[SymptomDirectedTest] [float] NULL,
	[RepeatsdutoClinicalRequest] [float] NULL,
	[Wastage] [float] NULL,
	[ReagentstoRunControls] [float] NULL,
	[BufferStockandControls] [float] NULL,
 CONSTRAINT [PK_CD4TestNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--		  CD4 = 1,
 --       Chemistry = 2,
 --       Hematology = 3,
 --       ViralLoad = 4,
 --       Other = 5
CREATE FUNCTION [dbo].[fnGetPlatform]
(
	@platformId INT
)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @platform varchar(50)
	
	if(@platformId=1) 
		set @platform='CD4'
	if(@platformId=2) 
		set @platform='Chemistry'
	if(@platformId=3) 
		set @platform='Hematology'
	if(@platformId=4) 
		set @platform='ViralLoad'
	if(@platformId=5) 
		set @platform='Other'
	if(@platformId=6)
		set @platform='HIV-Rapid Test'
	
	RETURN @platform
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetNumberOfPakage] 
(
	@PackagingSize INT,
	@NoProduct DECIMAL(18,2)
)
RETURNS INT
AS
BEGIN
	DECLARE @Nopack INT
	DECLARE @Result decimal(18,9)
	IF @PackagingSize=0
		SET @Result = @NoProduct
	ELSE
		SET @Result = @NoProduct / @PackagingSize
		
	SET @Nopack = CAST(ROUND(@Result, 0) AS INT)
	
	IF(@Nopack<@Result)
		SET @Nopack = @Nopack + 1
	IF(@Nopack = 0)
		SET @Nopack = 1
	
	RETURN @Nopack
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnWorkPeriodToDays]
(
	@WorkPeriod decimal(18,2),
	@workingperiod varchar(100)
)
RETURNS int
AS
BEGIN
	DECLARE @workingDay int
	if (@workingperiod = 'Monthly')--MONTHLY
        set @workingDay = CAST(@WorkPeriod AS INTEGER);
    if (@workingperiod = 'Bimonthly')--BiMonthly
        set @workingDay = CAST(@WorkPeriod AS INTEGER) * 2;
    if (@workingperiod = 'Quarterly')--QUARTERLY
        set @workingDay = CAST(@WorkPeriod AS INTEGER) * 3;
    if (@workingperiod = 'Yearly')--YEARLY
        set @workingDay = CAST(@WorkPeriod AS INTEGER) * 12;
	
	
	RETURN @workingDay
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MorbiditySupplyProcurement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MForecastId] [int] NULL,
	[Platform] [int] NULL,
	[QuantityNeeded] [float] NULL,
	[QuantityInStock] [float] NULL,
	[ProductId] [int] NULL,
	[UnitCost] [money] NULL,
	[PackSize] [int] NULL,
 CONSTRAINT [PK_MorbiditySupplyProcurement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MorbiditySupplyForecast](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MForecastId] [int] NULL,
	[SiteId] [int] NULL,
	[Platform] [int] NULL,
	[ProductId] [int] NULL,
	[QuantityNeeded] [float] NULL,
	[FinalQuantity] [float] NULL,
	[UnitCost] [money] NULL,
	[PackSize] [int] NULL,
	[Unit] [nvarchar](32) NULL,
 CONSTRAINT [PK_MSuppliedForecasted] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MorbidityForecast](
	[ForecastId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[DateOfQuantification] [datetime] NOT NULL,
	[Descritpion] [nvarchar](1024) NULL,
	[SatartDate] [datetime] NOT NULL,
	[Status] [nvarchar](16) NULL,
	[StartBudgetPeriod] [int] NOT NULL,
	[EndBudgetPeriod] [int] NOT NULL,
	[OptInitialPatientData] [int] NULL,
	[OptPatientTreatmentTarget] [int] NULL,
	[OptEverStartedPatientTarget] [int] NULL,
	[OptArtPatinetTarget] [int] NULL,
	[OptPreTreatmentPatinetTarget] [int] NULL,
	[TimeZeroPatientOnTreatment] [float] NULL,
	[TimeZeroPatientOnPreTreatment] [float] NULL,
	[EverSTimeZeroPatientOnTreatment] [float] NULL,
	[EverSTimeZeroPatientOnPreTreatment] [float] NULL,
	[NoofEverStartedPatientOnTreatment] [int] NULL,
	[NoofEverStartedPatientOnPreTreatment] [int] NULL,
	[TypeofAlgorithm] [nvarchar](16) NULL,
	[DateModified] [datetime] NULL,
	[UseRegionAsCat] [bit] NULL,
	[NTPT_RecentMonth] [float] NULL,
	[NTPT_January] [float] NULL,
	[NTPT_February] [float] NULL,
	[NTPT_March] [float] NULL,
	[NTPT_April] [float] NULL,
	[NTPT_May] [float] NULL,
	[NTPT_June] [float] NULL,
	[NTPT_July] [float] NULL,
	[NTPT_August] [float] NULL,
	[NTPT_September] [float] NULL,
	[NTPT_October] [float] NULL,
	[NTPT_November] [float] NULL,
	[NTPT_December] [float] NULL,
	[NTPT_PercentOfChildren] [float] NULL,
	[NTT_RecentMonth] [float] NULL,
	[NTT_January] [float] NULL,
	[NTT_February] [float] NULL,
	[NTT_March] [float] NULL,
	[NTT_April] [float] NULL,
	[NTT_May] [float] NULL,
	[NTT_June] [float] NULL,
	[NTT_July] [float] NULL,
	[NTT_August] [float] NULL,
	[NTT_September] [float] NULL,
	[NTT_October] [float] NULL,
	[NTT_November] [float] NULL,
	[NTT_December] [float] NULL,
	[NTT_PercentOfChildren] [float] NULL,
	[AdultTestingPopulation] [float] NULL,
	[PediatricTestingPopulation] [float] NULL,
	[AdultDepartWoutFollowup] [float] NULL,
	[PediatricDepartWoutFollowup] [float] NULL,
	[DiagnosesReceiveCD4] [float] NULL,
	[AIT_AnnualPatientAttrition] [float] NULL,
	[AIT_ExistingPatientBloodDraws] [float] NULL,
	[AIT_NewPatientBloodDraws] [float] NULL,
	[AIP_AnualPatientAttrition] [float] NULL,
	[AIP_AnnualMigration] [float] NULL,
	[AIP_ExistingPatientBloodDraws] [float] NULL,
	[AIP_NewPatientBloodDraws] [float] NULL,
	[PIT_AnnualPatientAttrition] [float] NULL,
	[PIT_ExistingPatientBloodDraws] [float] NULL,
	[PIT_NewPatientBloodDraws] [float] NULL,
	[PIP_AnualPatientAttrition] [float] NULL,
	[PIP_AnnualMigration] [float] NULL,
	[PIP_ExistingPatientBloodDraws] [float] NULL,
	[PIP_NewPatientBloodDraws] [float] NULL,
	[AdultTestingEfficiency] [float] NULL,
	[PediatricTestingEfficiency] [float] NULL,
	[PediatricsPreExistingPatients] [float] NULL,
 CONSTRAINT [PK_MorbidityForecast] PRIMARY KEY CLUSTERED 
(
	[ForecastId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientsNoofTest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastId] [int] NULL,
	[SiteId] [int] NULL,
	[PITMonth1] [float] NULL,
	[PITMonth2] [float] NULL,
	[PITMonth3] [float] NULL,
	[PITMonth4] [float] NULL,
	[PITMonth5] [float] NULL,
	[PITMonth6] [float] NULL,
	[PITMonth7] [float] NULL,
	[PITMonth8] [float] NULL,
	[PITMonth9] [float] NULL,
	[PITMonth10] [float] NULL,
	[PITMonth11] [float] NULL,
	[PITMonth12] [float] NULL,
	[PPARTMonth1] [float] NULL,
	[PPARTMonth2] [float] NULL,
	[PPARTMonth3] [float] NULL,
	[PPARTMonth4] [float] NULL,
	[PPARTMonth5] [float] NULL,
	[PPARTMonth6] [float] NULL,
	[PPARTMonth7] [float] NULL,
	[PPARTMonth8] [float] NULL,
	[PPARTMonth9] [float] NULL,
	[PPARTMonth10] [float] NULL,
	[PPARTMonth11] [float] NULL,
	[PPARTMonth12] [float] NULL,
 CONSTRAINT [PK_PatientsNoofTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Protocol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProtocolType] [int] NULL,
	[TestReapeated] [float] NULL,
	[SymptomDirectedAmt] [float] NULL,
	[Descritpion] [nvarchar](500) NULL,
 CONSTRAINT [PK_Protocol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[RegionID] [int] IDENTITY(1,1) NOT NULL,
	[RegionName] [nvarchar](64) NOT NULL,
	[ShortName] [nvarchar](8) NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[RegionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_SiteCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InitialPatinetData](
	[CategorySiteId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Treatment] [int] NULL,
	[PreTreatment] [int] NULL,
	[NewTargetTreatment] [int] NULL,
	[NewTargetPreTreatment] [int] NULL,
 CONSTRAINT [PK_InitialPatinetData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HIVRapidNumberofTest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastId] [int] NULL,
	[SiteId] [int] NULL,
	[Screening] [float] NULL,
	[Confirmatory] [float] NULL,
	[TieBreaker] [float] NULL,
 CONSTRAINT [PK_HIVRapidNumberofTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HemaandViralNumberofTest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Platform] [int] NULL,
	[ForecastId] [int] NULL,
	[SiteId] [int] NULL,
	[TestBasedOnProtocols] [float] NULL,
	[SymptomDirectedTests] [float] NULL,
	[RepeatedDuetoClinicalReq] [float] NULL,
	[InvalidTestandWastage] [float] NULL,
	[BufferStockandControls] [float] NULL,
	[ReagentstoRunControls] [float] NULL,
 CONSTRAINT [PK_HemaandViralNumberofTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForlabParameters](
	[ParmName] [nvarchar](64) NOT NULL,
	[ParmValue] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_ForlabParameters] PRIMARY KEY CLUSTERED 
(
	[ParmName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForecastSummary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastedResultId] [int] NULL,
	[SiteId] [int] NULL,
	[CategoryId] [int] NULL,
	[ProductTypeId] [int] NULL,
	[TesingAreaId] [int] NULL,
	[DurationDateTime] [datetime] NULL,
	[Duration] [nvarchar](64) NULL,
	[ForecastAmount] [decimal](18, 2) NULL,
	[ForecastPrice] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ForecastSummary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](64) NOT NULL,
	[Description] [nvarchar](256) NULL,
	[UseInDemography] [bit] NULL,
	[ClassOfTest] [nvarchar](32) NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EverStartedInitialPatinetData](
	[CategorySiteId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Treatment] [int] NULL,
	[PreTreatment] [int] NULL,
	[NewTargetTreatment] [int] NULL,
	[NewTargetPreTreatment] [int] NULL,
 CONSTRAINT [PK_EverStartedInitialPatinetData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteMorbidityForecast]
	@forecastID int
AS
BEGIN
	SET NOCOUNT ON;
   DELETE FROM dbo.CD4TestNumber where ForecastId=@forecastID
DELETE FROM dbo.ChemandOtherNumberofTest where ForecastId=@forecastID
DELETE FROM dbo.HemaandViralNumberofTest where ForecastId=@forecastID
DELETE FROM dbo.HIVRapidNumberofTest where ForecastId=@forecastID
DELETE FROM dbo.PatientsNoofTest where ForecastId=@forecastID
DELETE FROM dbo.MorbiditySupplyForecast where MForecastId=@forecastID
DELETE FROM dbo.MorbiditySupplyProcurement where MForecastId=@forecastID
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[RegionID] [int] NOT NULL,
	[SiteID] [int] IDENTITY(1,1) NOT NULL,
	[SiteName] [nvarchar](64) NOT NULL,
	[CategoryID] [int] NULL,
	[CD4TestingDaysPerMonth] [int] NULL,
	[ChemistryTestingDaysPerMonth] [int] NULL,
	[HematologyTestingDaysPerMonth] [int] NULL,
	[ViralLoadTestingDaysPerMonth] [int] NULL,
	[OtherTestingDaysPerMonth] [int] NULL,
	[CD4RefSite] [int] NULL,
	[ChemistryRefSite] [int] NULL,
	[HematologyRefSite] [int] NULL,
	[ViralLoadRefSite] [int] NULL,
	[OtherRefSite] [int] NULL,
	[WorkingDays] [int] NULL,
	[SiteLevel] [nvarchar](64) NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MorbidityCategory](
	[ForecastId] [int] NOT NULL,
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](64) NOT NULL,
	[RegionId] [int] NULL,
 CONSTRAINT [PK_MorbidityCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterProduct](
	[ProductTypeId] [int] NOT NULL,
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](150) NOT NULL,
	[SerialNo] [nvarchar](16) NULL,
	[Specification] [nvarchar](256) NULL,
	[BasicUnit] [nvarchar](16) NULL,
	[ProductNote] [nvarchar](400) NULL,
	[MinimumPackPerSite] [int] NULL,
	[RapidTestGroup] [nvarchar](32) NULL,
	[SlowMoving] [bit] NULL,
 CONSTRAINT [PK_MasterProduct] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryAssumptions](
	[ForecastId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RapidTestScreening] [float] NULL,
	[RapidTestConfirmatery] [float] NULL,
	[RapidTestTibreaker] [float] NULL,
	[CD4] [float] NULL,
	[Chemistry] [float] NULL,
	[Himatology] [float] NULL,
	[ViralLoad] [float] NULL,
	[OtherTests] [float] NULL,
	[SecurityStock] [int] NULL,
 CONSTRAINT [PK_InventoryAssumptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instrument](
	[TestingAreaID] [int] NOT NULL,
	[InstrumentID] [int] IDENTITY(1,1) NOT NULL,
	[InstrumentName] [nvarchar](64) NOT NULL,
	[MaxThroughPut] [int] NULL,
	[MonthMaxTPut] [int] NULL,
	[DailyCtrlTest] [int] NULL,
	[MaxTestBeforeCtrlTest] [int] NULL,
	[WeeklyCtrlTest] [int] NULL,
	[MonthlyCtrlTest] [int] NULL,
	[QuarterlyCtrlTest] [int] NULL,
 CONSTRAINT [PK_Instrument] PRIMARY KEY CLUSTERED 
(
	[InstrumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForecastCategory](
	[ForecastId] [int] NOT NULL,
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_ForecastCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fnGetProductType]
(
	@productTId INT
)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @productTName varchar(50)
	select @productTName=TypeName from ProductType where TypeID=@productTId
	
	RETURN @productTName
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spForecastInfo]
@fid int
as
begin
	SELECT   
	
ForecastInfo.* from ForecastInfo
WHERE                
		 ForecastID = @fid
		
				
				end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProtocolPanel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProtocolId] [int] NULL,
	[PanelName] [nvarchar](100) NULL,
	[AITNewPatient] [float] NULL,
	[AITPreExisting] [float] NULL,
	[AITTestperYear] [float] NULL,
	[AITMonth1] [int] NULL,
	[AITMonth2] [int] NULL,
	[AITMonth3] [int] NULL,
	[AITMonth4] [int] NULL,
	[AITMonth5] [int] NULL,
	[AITMonth6] [int] NULL,
	[AITMonth7] [int] NULL,
	[AITMonth8] [int] NULL,
	[AITMonth9] [int] NULL,
	[AITMonth10] [int] NULL,
	[AITMonth11] [int] NULL,
	[AITMonth12] [int] NULL,
	[PITNewPatient] [float] NULL,
	[PITPreExisting] [float] NULL,
	[PITTestperYear] [float] NULL,
	[PITMonth1] [int] NULL,
	[PITMonth2] [int] NULL,
	[PITMonth3] [int] NULL,
	[PITMonth4] [int] NULL,
	[PITMonth5] [int] NULL,
	[PITMonth6] [int] NULL,
	[PITMonth7] [int] NULL,
	[PITMonth8] [int] NULL,
	[PITMonth9] [int] NULL,
	[PITMonth10] [int] NULL,
	[PITMonth11] [int] NULL,
	[PITMonth12] [int] NULL,
	[APARTNewPatient] [float] NULL,
	[APARTPreExisting] [float] NULL,
	[APARTestperYear] [float] NULL,
	[APARTMonth1] [int] NULL,
	[APARTMonth2] [int] NULL,
	[APARTMonth3] [int] NULL,
	[APARTMonth4] [int] NULL,
	[APARTMonth5] [int] NULL,
	[APARTMonth6] [int] NULL,
	[APARTMonth7] [int] NULL,
	[APARTMonth8] [int] NULL,
	[APARTMonth9] [int] NULL,
	[APARTMonth10] [int] NULL,
	[APARTMonth11] [int] NULL,
	[APARTMonth12] [int] NULL,
	[PPARTNewPatient] [float] NULL,
	[PPARTPreExisting] [float] NULL,
	[PPARTTestperYear] [float] NULL,
	[PPARTMonth1] [int] NULL,
	[PPARTMonth2] [int] NULL,
	[PPARTMonth3] [int] NULL,
	[PPARTMonth4] [int] NULL,
	[PPARTMonth5] [int] NULL,
	[PPARTMonth6] [int] NULL,
	[PPARTMonth7] [int] NULL,
	[PPARTMonth8] [int] NULL,
	[PPARTMonth9] [int] NULL,
	[PPARTMonth10] [int] NULL,
	[PPARTMonth11] [int] NULL,
	[PPARTMonth12] [int] NULL,
 CONSTRAINT [PK_ProtocolPanel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingGroup](
	[TestingAreaID] [int] NOT NULL,
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](64) NULL,
 CONSTRAINT [PK_TestingGroup] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingAreaProtocol](
	[Id] [nvarchar](16) NOT NULL,
	[PanelName] [nvarchar](64) NULL,
	[TestingAreaId] [int] NULL,
	[TestReapeated] [decimal](18, 2) NULL,
 CONSTRAINT [PK_TestingAreaProtocol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSiteList]
	
	@category int=0,
	@region int=0--,
	--@status varchar(20)=''
AS
BEGIN
	
	SET NOCOUNT ON;
SELECT     dbo.Site.*, dbo.Region.RegionName, dbo.Region.ShortName, dbo.SiteCategory.CategoryName
FROM         dbo.Site INNER JOIN
                      dbo.Region ON dbo.Site.RegionID = dbo.Region.RegionID INNER JOIN
                      dbo.SiteCategory ON dbo.Site.CategoryID = dbo.SiteCategory.CategoryID
WHERE
1=case when @category=0 then 1 when @category=Site.CategoryID then 1 end and
1=case when @region=0 then 1 when @region=Site.RegionID then 1 end 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRegionList]
	@noofsite int=0,
	@logic varchar(10)=''
AS
If @logic=''
BEGIN
SELECT ShortName,RegionName,COUNT(dbo.Site.SiteID) AS NoofSites
FROM         dbo.Region LEFT OUTER JOIN dbo.Site ON dbo.Site.RegionID = dbo.Region.RegionID
GROUP BY dbo.Region.RegionName, dbo.Region.ShortName
END
If @logic='>'
BEGIN
SELECT ShortName,RegionName,COUNT(dbo.Site.SiteID) AS NoofSites
FROM         dbo.Region LEFT OUTER JOIN dbo.Site ON dbo.Site.RegionID = dbo.Region.RegionID
GROUP BY dbo.Region.RegionName, dbo.Region.ShortName
HAVING      (COUNT(dbo.Site.RegionID) > @noofsite)
END
If @logic='<'
BEGIN
SELECT ShortName,RegionName,COUNT(dbo.Site.SiteID) AS NoofSites
FROM         dbo.Region LEFT OUTER JOIN dbo.Site ON dbo.Site.RegionID = dbo.Region.RegionID
GROUP BY dbo.Region.RegionName, dbo.Region.ShortName
HAVING      (COUNT(dbo.Site.RegionID) < @noofsite)
END
If @logic='='
BEGIN
SELECT ShortName,RegionName,COUNT(dbo.Site.SiteID) AS NoofSites
FROM         dbo.Region LEFT OUTER JOIN dbo.Site ON dbo.Site.RegionID = dbo.Region.RegionID
GROUP BY dbo.Region.RegionName, dbo.Region.ShortName
HAVING      (COUNT(dbo.Site.RegionID) = @noofsite)
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spProductList]
	@producttype int=0
AS
BEGIN
	SET NOCOUNT ON;
SELECT     dbo.ProductType.TypeName, dbo.MasterProduct.*
FROM         dbo.ProductType INNER JOIN
                      dbo.MasterProduct ON dbo.ProductType.TypeID = dbo.MasterProduct.ProductTypeId
WHERE
1=case when @producttype=0 then 1 when @producttype=dbo.MasterProduct.ProductTypeId then 1 end
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteStatus](
	[SiteId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OpenedFrom] [datetime] NOT NULL,
	[ClosedOn] [datetime] NULL,
 CONSTRAINT [PK_SiteStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteInstrument](
	[InstrumentID] [int] NOT NULL,
	[SiteID] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[TestRunPercentage] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SiteInstrument] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MordidityCategorySite](
	[SiteId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastVCT] [bit] NOT NULL,
	[ForecastCD4] [bit] NOT NULL,
	[ForecastChemistry] [bit] NOT NULL,
	[ForecastHematology] [bit] NOT NULL,
	[ForecastViralLoad] [bit] NOT NULL,
	[ForecastOtherTest] [bit] NOT NULL,
	[ForecastConsumable] [bit] NOT NULL,
	[TimeZeroPatientOnTreatment] [float] NULL,
	[TimeZeroPatientOnPreTreatment] [float] NULL,
	[OldDataPatientOnTreatment] [float] NULL,
	[OldDataPatientOnPreTreatment] [float] NULL,
	[OldDataPatientOnTreatmentPercent] [float] NULL,
	[OldDataPatientOnPreTreatmentPercent] [float] NULL,
	[EverSTimeZeroPatientOnTreatment] [float] NULL,
	[EverSTimeZeroPatientOnPreTreatment] [float] NULL,
	[EverSPatientOnTreatment] [float] NULL,
	[EverSPatientOnTreatmentPercent] [float] NULL,
	[EverSPatientOnPreTreatment] [float] NULL,
	[EverSPatientOnPreTreatmentPercent] [float] NULL,
	[NTPT_RecentMonth] [float] NULL,
	[NTPT_January] [float] NULL,
	[NTPT_February] [float] NULL,
	[NTPT_March] [float] NULL,
	[NTPT_April] [float] NULL,
	[NTPT_May] [float] NULL,
	[NTPT_June] [float] NULL,
	[NTPT_July] [float] NULL,
	[NTPT_August] [float] NULL,
	[NTPT_September] [float] NULL,
	[NTPT_October] [float] NULL,
	[NTPT_November] [float] NULL,
	[NTPT_December] [float] NULL,
	[NTPT_PercentOfChildren] [float] NULL,
	[NTPT_GrowthTarget] [float] NULL,
	[NTPT_ApplyLinerGrowth] [bit] NULL,
	[NTT_RecentMonth] [float] NULL,
	[NTT_January] [float] NULL,
	[NTT_February] [float] NULL,
	[NTT_March] [float] NULL,
	[NTT_April] [float] NULL,
	[NTT_May] [float] NULL,
	[NTT_June] [float] NULL,
	[NTT_July] [float] NULL,
	[NTT_August] [float] NULL,
	[NTT_September] [float] NULL,
	[NTT_October] [float] NULL,
	[NTT_November] [float] NULL,
	[NTT_December] [float] NULL,
	[NTT_PercentOfChildren] [float] NULL,
	[NTT_GrowthTarget] [float] NULL,
	[NTT_ApplyLinerGrowth] [bit] NULL,
	[AdultTestingPopulation] [float] NULL,
	[PediatricTestingPopulation] [float] NULL,
	[AdultDepartWoutFollowup] [float] NULL,
	[PediatricDepartWoutFollowup] [float] NULL,
	[DiagnosesReceiveCD4] [float] NULL,
	[AIT_AnnualPatientAttrition] [float] NULL,
	[AIT_ExistingPatientBloodDraws] [float] NULL,
	[AIT_NewPatientBloodDraws] [float] NULL,
	[AIP_AnualPatientAttrition] [float] NULL,
	[AIP_AnnualMigration] [float] NULL,
	[AIP_ExistingPatientBloodDraws] [float] NULL,
	[AIP_NewPatientBloodDraws] [float] NULL,
	[PIT_AnnualPatientAttrition] [float] NULL,
	[PIT_ExistingPatientBloodDraws] [float] NULL,
	[PIT_NewPatientBloodDraws] [float] NULL,
	[PIP_AnualPatientAttrition] [float] NULL,
	[PIP_AnnualMigration] [float] NULL,
	[PIP_ExistingPatientBloodDraws] [float] NULL,
	[PIP_NewPatientBloodDraws] [float] NULL,
	[AdultTestingEfficiency] [float] NULL,
	[PediatricTestingEfficiency] [float] NULL,
	[PediatricsPreExistingPatients] [float] NULL,
	[ScrTest1Percent] [float] NULL,
	[ScrTest1] [int] NULL,
	[ScrTest2Percent] [float] NULL,
	[ScrTest2] [int] NULL,
	[ScrTest3Percent] [float] NULL,
	[ScrTest3] [int] NULL,
	[ConTest1Percent] [float] NULL,
	[ConTest1] [int] NULL,
	[ConTest2Percent] [float] NULL,
	[ConTest2] [int] NULL,
	[ConTest3Percent] [float] NULL,
	[ConTest3] [int] NULL,
	[TieTest1Percent] [float] NULL,
	[TieTest1] [int] NULL,
	[TieTest2Percent] [float] NULL,
	[TieTest2] [int] NULL,
	[TieTest3Percent] [float] NULL,
	[TieTest3] [int] NULL,
 CONSTRAINT [PK_MordidityCategorySite] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MorbidityTest](
	[InstrumentId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassOfTest] [nvarchar](16) NOT NULL,
	[TestName] [nvarchar](156) NOT NULL,
	[TestSpecificationGroup] [nvarchar](16) NULL,
 CONSTRAINT [PK_MorbidityTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spInstrumentList]
	
	
	@testingarea int=0
AS
BEGIN
	
	SET NOCOUNT ON;
SELECT     dbo.TestingArea.AreaName, dbo.Instrument.*
FROM         dbo.Instrument INNER JOIN
                      dbo.TestingArea ON dbo.Instrument.TestingAreaID = dbo.TestingArea.TestingAreaID
WHERE
1=case when @testingarea=0 then 1 when @testingarea=dbo.Instrument.TestingAreaID then 1 end
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[TestingAreaID] [int] NOT NULL,
	[TestingGroupID] [int] NOT NULL,
	[TestID] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [nvarchar](128) NOT NULL,
	[TestType] [nvarchar](50) NULL,
	[TestingDuration] [nvarchar](50) NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[TestID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Test] UNIQUE NONCLUSTERED 
(
	[TestingGroupID] ASC,
	[TestName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetProductName]
(
	@productId INT
)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @productName varchar(50)
	select @productName=ProductName from dbo.MasterProduct where ProductID=@productId
	
	RETURN @productName
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetProductMUnit]
(
	@productId INT
)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @Unit varchar(50)
	select @Unit=BasicUnit from dbo.MasterProduct where ProductID=@productId
	
	RETURN @Unit
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--		  CD4 = 1,
 --       Chemistry = 2,
 --       Hematology = 3,
 --       ViralLoad = 4,
 --       Other = 5
CREATE FUNCTION [dbo].[fnGetPlatformWorkingDays]
(
	@Peroid INT,
	@TestingArea varchar(200),
	@periodType varchar(100),
	@SiteId int
)
RETURNS int
AS
BEGIN
	DECLARE @workingday int
	--Declare @TestingArea varchar(200)
	
	if(@TestingArea='CD4' or @TestingArea='Flow Cytometry') 
	begin
	if (@periodType = 'Monthly')
        set @workingDay = (Select CD4TestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid;
    if (@periodType = 'Bimonthly')
        set @workingDay = (Select CD4TestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 2;
    if (@periodType = 'Quarterly')
        set @workingDay = (Select CD4TestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 3;
    if (@periodType = 'Yearly')
        set @workingDay = (Select CD4TestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 12;
	end
	
	else if(@TestingArea='Chemistry') 
	begin
	if (@periodType = 'Monthly')
        set @workingDay = (Select ChemistryTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid;
    if (@periodType = 'Bimonthly')
        set @workingDay = (Select ChemistryTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 2;
    if (@periodType = 'Quarterly')
        set @workingDay = (Select ChemistryTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 3;
    if (@periodType = 'Yearly')
        set @workingDay = (Select ChemistryTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 12;
	end
	
	else if(@TestingArea='Hematology') 
	begin
	if (@periodType = 'Monthly')
        set @workingDay = (Select HematologyTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid;
    if (@periodType = 'Bimonthly')
        set @workingDay = (Select HematologyTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 2;
    if (@periodType = 'Quarterly')
        set @workingDay = (Select HematologyTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 3;
    if (@periodType = 'Yearly')
        set @workingDay = (Select HematologyTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 12;
	end
	
	else if(@TestingArea='ViralLoad') 
	begin
	if (@periodType = 'Monthly')
        set @workingDay = (Select ViralLoadTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid;
    if (@periodType = 'Bimonthly')
        set @workingDay = (Select ViralLoadTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 2;
    if (@periodType = 'Quarterly')
        set @workingDay = (Select ViralLoadTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 3;
    if (@periodType = 'Yearly')
        set @workingDay = (Select ViralLoadTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 12;
	end
	
	else if(@TestingArea='Other') 
	begin
	if (@periodType = 'Monthly')
        set @workingDay = (Select OtherTestingDaysPerMonth  from dbo.Site where SiteId=@SiteId)*@Peroid;
    if (@periodType = 'Bimonthly')
        set @workingDay = (Select OtherTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 2;
    if (@periodType = 'Quarterly')
        set @workingDay = (Select OtherTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 3;
    if (@periodType = 'Yearly')
        set @workingDay = (Select OtherTestingDaysPerMonth from dbo.Site where SiteId=@SiteId)*@Peroid * 12;
	end
	else
	begin
    if (@periodType = 'Monthly')
        set @workingDay = 22*@Peroid;
    if (@periodType = 'Bimonthly')
        set @workingDay = 22*@Peroid * 2;
    if (@periodType = 'Quarterly')
        set @workingDay = 22*@Peroid * 3;
    if (@periodType = 'Yearly')
        set @workingDay = 22*@Peroid * 12;
	end
	RETURN @workingday
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetRegionBySite]
(
	@siteId INT
)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @RegionName varchar(50)
	DECLARE @RegionId int
	select @RegionId=RegionID from dbo.Site where SiteID=@siteId
	select @RegionName=RegionName from dbo.Region where RegionID=@RegionId
	
	RETURN @RegionName
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fnGetProductTypeByProductId]
(
	@productTId INT
)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @productTName varchar(50)
	select @productTName=TypeName from ProductType where TypeID=(select top 1 dbo.MasterProduct.ProductTypeId from dbo.MasterProduct where dbo.MasterProduct.ProductID=@productTId)
	
	RETURN @productTName
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetSiteName]
(
	@siteId INT
)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @SiteName varchar(50)
	select @SiteName=SiteName from dbo.Site where SiteID=@siteId
	
	RETURN @SiteName
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetSiteCount]
(
	@regionId INT
)
RETURNS int
AS
BEGIN
	DECLARE @SiteCount int
	select @SiteCount=Count(SiteID) from dbo.Site where RegionID=@regionId
	
	RETURN @SiteCount
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RapidTestSpec](
	[ProductId] [int] NULL,
	[RapidTestId] [int] IDENTITY(1,1) NOT NULL,
	[TestGroup] [nvarchar](16) NOT NULL,
	[UsageRate] [float] NOT NULL,
	[ProductOrder] [int] NULL,
	[SerialTestSensitivity] [float] NULL,
	[SerialTestSpecificity] [float] NULL,
	[ParallelTestSensitivity] [float] NULL,
	[ParallelTestSpecificity] [float] NULL,
 CONSTRAINT [PK_RapidTestSpec] PRIMARY KEY CLUSTERED 
(
	[RapidTestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForecastCategorySite](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[SiteID] [int] NOT NULL,
 CONSTRAINT [PK_ForecastCategorySite] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForecastCategoryProduct](
	[CategoryID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AmountUsed] [decimal](18, 4) NULL,
	[CDuration] [nvarchar](32) NULL,
	[StockOut] [int] NULL,
	[Adjusted] [decimal](18, 2) NULL,
	[DurationDateTime] [datetime] NULL,
	[InstrumentDowntime] [int] NULL,
 CONSTRAINT [PK_ForecastCategoryProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForecastSite](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastInfoId] [int] NOT NULL,
	[SiteId] [int] NOT NULL,
	[ReportedSiteId] [int] NULL,
 CONSTRAINT [PK_ForecastSite] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPrice](
	[ProductId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [money] NOT NULL,
	[PackSize] [int] NOT NULL,
	[FromDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductPrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForecastSiteTest](
	[ForecastSiteID] [int] NOT NULL,
	[TestID] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CDuration] [nvarchar](24) NULL,
	[AmountUsed] [decimal](18, 2) NULL,
	[StockOut] [int] NULL,
	[Adjusted] [decimal](18, 2) NULL,
	[DurationDateTime] [datetime] NULL,
	[InstrumentDowntime] [int] NULL,
 CONSTRAINT [PK_ForecastSiteTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForecastSiteProduct](
	[ForecastSiteID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CDuration] [nvarchar](24) NULL,
	[AmountUsed] [decimal](18, 2) NULL,
	[StockOut] [int] NULL,
	[Adjusted] [decimal](18, 2) NULL,
	[DurationDateTime] [datetime] NULL,
	[InstrumentDowntime] [int] NULL,
 CONSTRAINT [PK_ForecastSiteProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForecastNRSite](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastSiteId] [int] NOT NULL,
	[NReportedSiteId] [int] NOT NULL,
 CONSTRAINT [PK_ForecastNRSite] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetForecastNoofPatientSummary]
(	
	@ForecastId INT
)
RETURNS @ForecastNoofPatient TABLE 
(
Title varchar(100),DateOfQuantification datetime,Descritpion varchar(500),SatartDate datetime,
StartBudgetPeriod int,EndBudgetPeriod int,Region varchar(100),SiteName varchar(100),
MonthN varchar(100),fvalue int,PatientType varchar(100)
)
AS
BEGIN
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month1',PITMonth1,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId    
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month2',PITMonth2,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month3',PITMonth3,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month4',PITMonth4,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month5',PITMonth5,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month6',PITMonth6,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month7',PITMonth7,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month8',PITMonth8,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month9',PITMonth9,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month10',PITMonth10,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month11',PITMonth11,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month12',PITMonth12,'Patient In Treatment'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month1',PPARTMonth1,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId  
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month2',PPARTMonth2,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId 
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month3',PPARTMonth3,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId 
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month4',PPARTMonth4,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId 
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month5',PPARTMonth5,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId 
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month6',PPARTMonth6,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId 
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month7',PPARTMonth7,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId 
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month8',PPARTMonth8,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId 
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month9',PPARTMonth9,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId 
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month10',PPARTMonth10,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId 
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month11',PPARTMonth11,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId 
--
INSERT INTO @ForecastNoofPatient(Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,
Region,SiteName,MonthN,fvalue,PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,'Month12',PPARTMonth12,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId 
               
RETURN
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetForecastNoofPatientInfo]
(	
	@ForecastId INT
)
RETURNS @ForecastNoofPatient TABLE 
(
Title varchar(100),DateOfQuantification datetime,Descritpion varchar(500),SatartDate datetime,
StartBudgetPeriod int,EndBudgetPeriod int,Region varchar(100),SiteName varchar(100),
Month1 int ,Month2 int,Month3 int,Month4 int,Month5 int,Month6 int,
Month7 int,Month8 int,Month9 int,Month10 int,Month11 int,Month12 int,
PatientType varchar(100)
)
AS
BEGIN
INSERT INTO @ForecastNoofPatient(
Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,Region,SiteName,
Month1,Month2,Month3,Month4,Month5,Month6,
Month7,Month8,Month9,Month10,Month11,Month12,
PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,
PITMonth1, PITMonth2, PITMonth3,  PITMonth4, 
PITMonth5, PITMonth6, PITMonth7, PITMonth8, PITMonth9, PITMonth10, 
PITMonth11,PITMonth12, 'Patient In Treatment'
--PPARTMonth1, PPARTMonth2, PPARTMonth3, PPARTMonth4, PPARTMonth5, PPARTMonth6,
--PPARTMonth7, PPARTMonth8, PPARTMonth9, PPARTMonth10,PPARTMonth11, PPARTMonth12,"Pre-ART Patient"
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId    
INSERT INTO @ForecastNoofPatient(
Title,DateOfQuantification,Descritpion,SatartDate,StartBudgetPeriod,EndBudgetPeriod,Region,SiteName,
Month1,Month2,Month3,Month4,Month5,Month6,
Month7,Month8,Month9,Month10,Month11,Month12,
PatientType	)
SELECT 
dbo.MorbidityForecast.Title,dbo.MorbidityForecast.DateOfQuantification,dbo.MorbidityForecast.Descritpion,
dbo.MorbidityForecast.SatartDate,dbo.MorbidityForecast.StartBudgetPeriod,dbo.MorbidityForecast.EndBudgetPeriod,
dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,
PPARTMonth1, PPARTMonth2, PPARTMonth3, PPARTMonth4, PPARTMonth5, PPARTMonth6,
PPARTMonth7, PPARTMonth8, PPARTMonth9, PPARTMonth10,PPARTMonth11, PPARTMonth12,'Pre-ART Patient'
FROM   dbo.MorbidityForecast INNER JOIN   dbo.PatientsNoofTest ON dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId               
RETURN
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductUsage](
	[TestId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rate] [decimal](18, 10) NOT NULL,
	[ProductUsedIn] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductUsage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PanelTest](
	[PanelId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NULL,
	[ChemTestName] [nvarchar](32) NULL,
	[OtherTestName] [nvarchar](32) NULL,
 CONSTRAINT [PK_PanelTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuantifyMenu](
	[MorbidityTetsId] [int] NULL,
	[InstrumentId] [int] NULL,
	[ProductId] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassOfTest] [nvarchar](16) NOT NULL,
	[Title] [nvarchar](156) NOT NULL,
	[TestType] [nvarchar](32) NULL,
	[Duration] [nvarchar](16) NULL,
	[ChemTestName] [nvarchar](32) NULL,
 CONSTRAINT [PK_QuantifyMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetWorkingDays]
(
	@ForecastSiteId INT,
	@type int
)
RETURNS int
AS
BEGIN
	DECLARE @workingDay int
	Declare @sitegeneralworkingday int
	Declare @workingperiod varchar(50)
	
	set @workingDay=22
	if(@type=0)
	begin
	select @sitegeneralworkingday=WorkingDays from Site 
	where siteid=(select SiteId from forecastSite where Id=@ForecastSiteId)
	
	select @workingperiod=Period from ForecastInfo
	where ForecastID=(select ForecastInfoId from forecastSite where Id=@ForecastSiteId)
	
	if (@workingperiod = 'Monthly')
        set @workingDay = @sitegeneralworkingday;
    if (@workingperiod = 'Bimonthly')
        set @workingDay = @sitegeneralworkingday * 2;
    if (@workingperiod = 'Quarterly')
        set @workingDay = @sitegeneralworkingday * 3;
    if (@workingperiod = 'Yearly')
        set @workingDay = @sitegeneralworkingday * 12;
	end
	
	RETURN @workingDay
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetTestName]
(
	@testId INT
)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @TestName varchar(50)
	select @TestName=TestName from dbo.Test where TestID=@testId
	
	RETURN @TestName
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetTestAreaName]
(
	@testaId INT
)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @TestaName varchar(50)
	select @TestaName=AreaName from dbo.TestingArea where TestingAreaID=(select top 1 dbo.Test.TestingAreaId from dbo.Test where dbo.Test.TestID=@testaId)
	
	RETURN @TestaName
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForecastedResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForecastId] [int] NOT NULL,
	[ProductId] [int] NULL,
	[TestId] [int] NULL,
	[DurationDateTime] [datetime] NOT NULL,
	[ForecastValue] [decimal](18, 2) NOT NULL,
	[TotalValue] [decimal](18, 2) NULL,
	[SiteId] [int] NULL,
	[CategoryId] [int] NULL,
	[Duration] [nvarchar](64) NULL,
	[IsHistory] [bit] NULL,
	[HistoricalValue] [decimal](18, 2) NULL,
	[PackQty] [int] NULL,
	[PackPrice] [decimal](18, 2) NULL,
	[ProductTypeId] [int] NULL,
	[ProductType] [nvarchar](64) NULL,
	[ServiceConverted] [bit] NULL,
	[TestingArea] [nvarchar](100) NULL,
 CONSTRAINT [PK_ForecastedResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForecastCategoryTest](
	[CategoryID] [int] NOT NULL,
	[TestID] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CDuration] [nvarchar](24) NOT NULL,
	[AmountUsed] [decimal](18, 2) NULL,
	[StockOut] [int] NULL,
	[Adjusted] [decimal](18, 2) NULL,
	[DurationDateTime] [datetime] NULL,
	[InstrumentDowntime] [int] NULL,
 CONSTRAINT [PK_ForecastSiteCategoryTest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetProductPrice]
(
	@ProductId INT,
	@FromDate DateTime	
)
RETURNS INT
AS
BEGIN
	DECLARE @price Int
	SELECT @price = p1.Price 
	FROM ProductPrice p1 WHERE p1.FromDate =
	(SELECT MAX(p2.FromDate) 
		FROM ProductPrice p2 
		WHERE 
			p2.ProductId = p1.ProductId 
			AND 
			p2.FromDate <= @FromDate 
			AND 
			p2.ProductId = @ProductId
	)
	
	RETURN @price
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[fnGetProductPacksizeandPrice]
(	
	@ProductId INT,
	@FromDate DateTime	
)
RETURNS @ProductPacksizeandPrice TABLE 
(
PackSize int,
ProductPrice int
)
AS
BEGIN
Insert into @ProductPacksizeandPrice(PackSize,ProductPrice)
Select p1.PackSize,p1.Price
	FROM ProductPrice p1 WHERE p1.FromDate =
	(SELECT MAX(p2.FromDate) FROM ProductPrice p2 WHERE 
		p2.ProductId = p1.ProductId AND p2.FromDate <= @FromDate AND p2.ProductId = @ProductId	)
Return
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetProductPacksize]
(
	@ProductId INT,
	@FromDate DateTime	
)
RETURNS int
AS
BEGIN
	DECLARE @pack Int
	SELECT @pack = p1.PackSize
	FROM ProductPrice p1 WHERE p1.FromDate =
	(SELECT MAX(p2.FromDate) 
		FROM ProductPrice p2 
		WHERE 
			p2.ProductId = p1.ProductId 
			AND 
			p2.FromDate <= @FromDate 
			AND 
			p2.ProductId = @ProductId
	)
	
	RETURN @pack
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetMorbidityForecastSummary]
(	
	@ForecastId int
)
RETURNS @ForecastSummary TABLE 
(
Methodology nvarchar(64),
ProductType nvarchar(64),
Fyear int, 
Quantity DECIMAL(18,9), 
TotalPrice DECIMAL(18,9),
Duration nvarchar(100),
DurationDateTime datetime
)
AS
BEGIN
INSERT INTO @ForecastSummary 
SELECT    
'Morbidity',
dbo.fnGetProductTypeByProductId(dbo.MorbiditySupplyProcurement.ProductId) as ProductType,
         --dbo.fnGetProductName(dbo.MorbiditySupplyProcurement.ProductId) as ProductName,
         --'asdf',
         Year(dbo.MorbidityForecast.SatartDate), 
         sum((dbo.MorbiditySupplyProcurement.QuantityNeeded-dbo.MorbiditySupplyProcurement.QuantityInStock)) as QuantityToPurchase,
         -- sum(dbo.MorbiditySupplyProcurement.UnitCost), 
         sum((dbo.MorbiditySupplyProcurement.QuantityNeeded-dbo.MorbiditySupplyProcurement.QuantityInStock)*dbo.MorbiditySupplyProcurement.UnitCost) as TotalCost
         ,'',''
FROM         dbo.MorbidityForecast INNER JOIN
                      dbo.MorbiditySupplyProcurement ON dbo.MorbidityForecast.ForecastId = dbo.MorbiditySupplyProcurement.MForecastId
 where
 dbo.MorbiditySupplyProcurement.MForecastId=@ForecastId
 group by dbo.fnGetProductTypeByProductId(dbo.MorbiditySupplyProcurement.ProductId),Year(dbo.MorbidityForecast.SatartDate)
    
RETURN
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetMaxThroughPutOfSite]
(
	@SiteId INT,
	@TestAreaId INT
)
RETURNS INT
AS
BEGIN
	DECLARE @MonthMtp INT
	SELECT 
		@MonthMtp = Sum(I.MonthMaxTPut * S.Quantity)
	FROM Instrument AS I 
			INNER JOIN SiteInstrument AS S ON I.InstrumentID = S.InstrumentID 
	WHERE  S.SiteId = @SiteId and I.TestingAreaID = @TestAreaId
	
	RETURN @MonthMtp
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spTestList]
	@testingarea int=0
AS
BEGIN
	SET NOCOUNT ON;
SELECT     dbo.TestingArea.AreaName, dbo.Test.TestName, dbo.Test.TestType
FROM         dbo.Test INNER JOIN
                      dbo.TestingArea ON dbo.Test.TestingAreaID = dbo.TestingArea.TestingAreaID
WHERE
1=case when @testingarea=0 then 1 when @testingarea=dbo.Test.TestingAreaID then 1 end
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSymptomDirectedTest](
	[ProtocolId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NULL,
	[ChemTestName] [nvarchar](32) NULL,
	[OtherTestName] [nvarchar](32) NULL,
	[AdultInTreatmeant] [float] NULL,
	[PediatricInTreatmeant] [float] NULL,
	[AdultPreART] [float] NULL,
	[PediatricPreART] [float] NULL,
 CONSTRAINT [PK_Symptom-DirectedTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--dbo.fnGetAdjustedValueP(ForecastSiteID,ProductID,AmountUsed,StockOut,InstrumentDowntime)
create FUNCTION [dbo].[fnGetAdjustedValueCP] 
(
	@categoryId int,
	@ProductId int,
	@amountused decimal,
	@stockout int,
	@instrumentdowntime int
	
)
RETURNS decimal(18,2)
AS
BEGIN
	DECLARE @count int
	DECLARE @totalsum decimal
	Declare @adjusted decimal(18,2)
	declare @workingDay int
	
	set @adjusted=@amountused
	set @workingDay=22
	
	IF(@amountused=0)
	begin
		select @count=count(Id) from ForecastCategoryProduct 
		where CategoryID=@categoryId and ProductID=@ProductId
		
		select @totalsum= sum(AmountUsed) from ForecastCategoryProduct 
		where CategoryID=@categoryId and ProductID=@ProductId
	
		If @count>0
			Set @adjusted=@totalsum/@count
	end
	IF(@stockout>0 or @instrumentdowntime>0)
	begin
	set @workingDay=22
		set @adjusted=(@amountused*@workingDay)/(@workingDay-(@stockout+@instrumentdowntime))
	end
	
	RETURN @adjusted
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spforecastsitebytire]
@forecastid int =0
as
begin
SELECT COUNT(DISTINCT dbo.ForecastSite.SiteId)as numberoftire, dbo.Site.SiteLevel--, dbo.SiteCategory.CategoryName, 
FROM         dbo.ForecastSite INNER JOIN
                      dbo.Site ON dbo.ForecastSite.SiteId = dbo.Site.SiteID INNER JOIN
                      dbo.SiteCategory ON dbo.Site.CategoryID = dbo.SiteCategory.CategoryID INNER JOIN
                      dbo.ForecastInfo ON dbo.ForecastSite.ForecastInfoId = dbo.ForecastInfo.ForecastID
                      
                      where 
                    1= case when @forecastid=0 then 1 when @forecastid=ForecastSite.ForecastInfoId then 1 end 
                      
	
                      group by    dbo.Site.SiteLevel
								
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spCD4TestNumberForecast]
@ForecastId int
as
 
SELECT     dbo.MorbidityForecast.Title, dbo.MorbidityForecast.DateOfQuantification, 
		   dbo.MorbidityForecast.Descritpion, dbo.MorbidityForecast.SatartDate, 
           dbo.MorbidityForecast.StartBudgetPeriod, dbo.MorbidityForecast.EndBudgetPeriod,
Id, dbo.CD4TestNumber.ForecastId, SiteId, ExistingPIT, ExistingPIPreART, CD4BaseLineTest, 
			NewPatienttoTreatment, NewPatientstoPreART, SymptomDirectedTest, 
            RepeatsdutoClinicalRequest, Wastage, ReagentstoRunControls,BufferStockandControls,
            dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN
FROM   dbo.MorbidityForecast INNER JOIN
       dbo.CD4TestNumber ON 
       dbo.MorbidityForecast.ForecastId = dbo.CD4TestNumber.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spInstrumentDistribution]
@regionId int=0
as
begin
if(@regionId=0)
begin
SELECT     dbo.TestingArea.AreaName, dbo.Instrument.InstrumentName, SUM(dbo.SiteInstrument.Quantity) AS Qty
FROM         dbo.Instrument INNER JOIN
                      dbo.SiteInstrument ON dbo.Instrument.InstrumentID = dbo.SiteInstrument.InstrumentID INNER JOIN
                      dbo.TestingArea ON dbo.Instrument.TestingAreaID = dbo.TestingArea.TestingAreaID INNER JOIN
                      dbo.Site ON dbo.SiteInstrument.SiteID = dbo.Site.SiteID
GROUP BY  dbo.TestingArea.AreaName, dbo.Instrument.InstrumentName
end 
else
SELECT     dbo.TestingArea.AreaName, dbo.Instrument.InstrumentName, SUM(dbo.SiteInstrument.Quantity) AS Qty, dbo.Site.RegionID
FROM         dbo.Instrument INNER JOIN
                      dbo.SiteInstrument ON dbo.Instrument.InstrumentID = dbo.SiteInstrument.InstrumentID INNER JOIN
                      dbo.TestingArea ON dbo.Instrument.TestingAreaID = dbo.TestingArea.TestingAreaID INNER JOIN
                      dbo.Site ON dbo.SiteInstrument.SiteID = dbo.Site.SiteID
                      where dbo.Site.RegionId=@regionId
GROUP BY dbo.Site.RegionID, dbo.TestingArea.AreaName, dbo.Instrument.InstrumentName

end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spHIVRapidTestNumberForecast]
@ForecastId int
as
 
SELECT     dbo.MorbidityForecast.Title, dbo.MorbidityForecast.DateOfQuantification, 
		   dbo.MorbidityForecast.Descritpion, dbo.MorbidityForecast.SatartDate, 
           dbo.MorbidityForecast.StartBudgetPeriod, dbo.MorbidityForecast.EndBudgetPeriod,
Id, dbo.HIVRapidNumberofTest.ForecastId, SiteId, Screening, Confirmatory, TieBreaker,
            dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN
FROM   dbo.MorbidityForecast INNER JOIN
       dbo.HIVRapidNumberofTest ON 
       dbo.MorbidityForecast.ForecastId = dbo.HIVRapidNumberofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spHemaandViralNumberofTest]
@ForecastId int
as
 
SELECT     dbo.MorbidityForecast.Title, dbo.MorbidityForecast.DateOfQuantification, 
		   dbo.MorbidityForecast.Descritpion, dbo.MorbidityForecast.SatartDate, 
           dbo.MorbidityForecast.StartBudgetPeriod, dbo.MorbidityForecast.EndBudgetPeriod,
Id, dbo.HemaandViralNumberofTest.ForecastId, SiteId, TestBasedOnProtocols, SymptomDirectedTests,
RepeatedDuetoClinicalReq,InvalidTestandWastage,BufferStockandControls,ReagentstoRunControls,
            dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,Platform
FROM   dbo.MorbidityForecast INNER JOIN
       dbo.HemaandViralNumberofTest ON 
       dbo.MorbidityForecast.ForecastId = dbo.HemaandViralNumberofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spProductPriceList]
	@producttype int=0
AS
BEGIN
	SET NOCOUNT ON;
SELECT     dbo.ProductType.TypeName, dbo.MasterProduct.*, dbo.ProductPrice.Price, dbo.ProductPrice.PackSize, dbo.ProductPrice.FromDate
FROM         dbo.ProductType INNER JOIN
                      dbo.MasterProduct ON dbo.ProductType.TypeID = dbo.MasterProduct.ProductTypeId RIGHT OUTER JOIN
                      dbo.ProductPrice ON dbo.MasterProduct.ProductID = dbo.ProductPrice.ProductId
WHERE
1=case when @producttype=0 then 1 when @producttype=dbo.MasterProduct.ProductTypeId then 1 end
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwSiteInstrument]
AS
SELECT     dbo.SiteInstrument.SiteID, dbo.Instrument.InstrumentID, dbo.TestingArea.AreaName, dbo.Instrument.InstrumentName, dbo.SiteInstrument.Quantity, 
                      dbo.Instrument.MaxThroughPut, dbo.SiteInstrument.TestRunPercentage, dbo.SiteInstrument.Quantity * dbo.Instrument.MaxThroughPut AS TotalThroughPut
FROM         dbo.Instrument INNER JOIN
                      dbo.SiteInstrument ON dbo.Instrument.InstrumentID = dbo.SiteInstrument.InstrumentID INNER JOIN
                      dbo.TestingArea ON dbo.Instrument.TestingAreaID = dbo.TestingArea.TestingAreaID
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spPatientNumberofTestforecast]
@ForecastId int
as
SELECT     
dbo.MorbidityForecast.Title, dbo.MorbidityForecast.DateOfQuantification, 
		   dbo.MorbidityForecast.Descritpion, dbo.MorbidityForecast.SatartDate, 
           dbo.MorbidityForecast.StartBudgetPeriod, dbo.MorbidityForecast.EndBudgetPeriod,
Id, dbo.PatientsNoofTest.ForecastId, PITMonth1, PITMonth2, PITMonth3, PITMonth4, PITMonth5, PITMonth6, PITMonth7, PITMonth8, PITMonth9, PITMonth10, PITMonth11, PITMonth12, 
                      PPARTMonth1, PPARTMonth2, PPARTMonth3, PPARTMonth4, PPARTMonth5, PPARTMonth6, PPARTMonth7, PPARTMonth8, PPARTMonth9, PPARTMonth10, 
                      PPARTMonth11, PPARTMonth12,SiteId,
                      dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN
 
FROM   dbo.MorbidityForecast INNER JOIN
       dbo.PatientsNoofTest ON 
       dbo.MorbidityForecast.ForecastId = dbo.PatientsNoofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spMorbiditySupplyProcuremnetForecast]
@ForecastId int
as
SELECT     dbo.MorbidityForecast.Title, dbo.MorbidityForecast.DateOfQuantification, 
		dbo.MorbidityForecast.Descritpion, dbo.MorbidityForecast.SatartDate, 
        dbo.MorbidityForecast.StartBudgetPeriod, dbo.MorbidityForecast.EndBudgetPeriod, 
        dbo.MorbiditySupplyProcurement.Id, 
        dbo.MorbiditySupplyProcurement.MForecastId, 
        dbo.MorbiditySupplyProcurement.Platform, dbo.MorbiditySupplyProcurement.QuantityNeeded, 
        dbo.MorbiditySupplyProcurement.QuantityInStock, dbo.MorbiditySupplyProcurement.ProductId,
         dbo.MorbiditySupplyProcurement.UnitCost, 
         dbo.MorbiditySupplyProcurement.PackSize,
         dbo.fnGetProductName(dbo.MorbiditySupplyProcurement.ProductId) as ProductName,
         dbo.fnGetPlatform(dbo.MorbiditySupplyProcurement.Platform) as PlatformName,
         dbo.fnGetProductMUnit(dbo.MorbiditySupplyProcurement.ProductId) as ProductMUnit,
         (dbo.MorbiditySupplyProcurement.QuantityNeeded-dbo.MorbiditySupplyProcurement.QuantityInStock) as QuantityToPurchase,
         (dbo.MorbiditySupplyProcurement.QuantityNeeded-dbo.MorbiditySupplyProcurement.QuantityInStock)*dbo.MorbiditySupplyProcurement.UnitCost as TotalCost
FROM         dbo.MorbidityForecast INNER JOIN
                      dbo.MorbiditySupplyProcurement ON dbo.MorbidityForecast.ForecastId = dbo.MorbiditySupplyProcurement.MForecastId
 where
 dbo.MorbiditySupplyProcurement.MForecastId=@ForecastId
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spMorbiditySupplyForecast]
@ForecastId int
as
SELECT     dbo.MorbidityForecast.Title, dbo.MorbidityForecast.DateOfQuantification, 
		   dbo.MorbidityForecast.Descritpion, dbo.MorbidityForecast.SatartDate, 
           dbo.MorbidityForecast.StartBudgetPeriod, dbo.MorbidityForecast.EndBudgetPeriod,
           dbo.MorbiditySupplyForecast.SiteId, dbo.MorbiditySupplyForecast.Platform, 
           dbo.MorbiditySupplyForecast.ProductId, 
           dbo.fnGetRegionBySite(dbo.MorbiditySupplyForecast.SiteId) as RegionName,
           dbo.fnGetSiteName(dbo.MorbiditySupplyForecast.SiteId) as SiteName,
           dbo.fnGetPlatform(dbo.MorbiditySupplyForecast.Platform) as PlatformName,
           dbo.fnGetProductName(dbo.MorbiditySupplyForecast.ProductId) as ProductName,
           dbo.MorbiditySupplyForecast.QuantityNeeded,
           dbo.MorbiditySupplyForecast.FinalQuantity
FROM   dbo.MorbidityForecast INNER JOIN
       dbo.MorbiditySupplyForecast ON 
       dbo.MorbidityForecast.ForecastId = dbo.MorbiditySupplyForecast.MForecastId
where
dbo.MorbiditySupplyForecast.MForecastId=@ForecastId
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSiteInstrumentList]
	
	@category int=0,
	@region int=0,
	@testingarea int=0
AS
BEGIN
	
	SET NOCOUNT ON;
SELECT     dbo.Region.RegionName, dbo.SiteCategory.CategoryName, dbo.Site.SiteName, dbo.Instrument.InstrumentName, dbo.SiteInstrument.Quantity, 
                      dbo.SiteInstrument.TestRunPercentage,(select TestingArea.AreaName from TestingArea where TestingArea.TestingAreaID=Instrument.TestingAreaID) as TestingArea
FROM         dbo.Site INNER JOIN
                      dbo.Region ON dbo.Site.RegionID = dbo.Region.RegionID INNER JOIN
                      dbo.SiteCategory ON dbo.Site.CategoryID = dbo.SiteCategory.CategoryID INNER JOIN
                      dbo.SiteInstrument ON dbo.Site.SiteID = dbo.SiteInstrument.SiteID INNER JOIN
                      dbo.Instrument ON dbo.SiteInstrument.InstrumentID = dbo.Instrument.InstrumentID
WHERE
1=case when @category=0 then 1 when @category=Site.CategoryID then 1 end and
1=case when @region=0 then 1 when @region=Site.RegionID then 1 end and
1=case when @testingarea=0 then 1 when @testingarea=dbo.Instrument.TestingAreaID then 1 end
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spServiceTotalSummary]
@forecastid int =0,
@siteid int=0,
@catid int=0
as
begin
SELECT	 SUM(ForecastedResult.PackQty) as TotalPackQty,
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, ForecastedResult.ProductType
        ,
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
WHERE          
 ForecastedResult.ServiceConverted=1 and         
		  1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by ForecastedResult.ProductType,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServicePriceSummarybyDuration]
@forecastid int =0,
@siteid int=0,
@catid int=0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, ForecastedResult.ProductType
        ,
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
WHERE          
 ForecastedResult.ServiceConverted=1 and         
		  1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by ForecastedResult.ProductType,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServicePriceSummary]
@forecastid int =0,
@siteid int=0,
@catid int=0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, ForecastedResult.ProductType,0.00 as percentage
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
WHERE   
 ForecastedResult.ServiceConverted=1 and            
1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       
		  
		 and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by ForecastedResult.ProductType
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServicePricebyDuration]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@testareaId int =0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, Test.TestName as AreaName,
  
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
          INNER JOIN Test on Test.TestID=dbo.ForecastedResult.TestId 
WHERE          
 ForecastedResult.ServiceConverted=1 and         
		  1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                      and
                       1=case when @testareaId=0 then 1 when @testareaId=Test.TestingAreaID then 1 end                      
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by  Test.TestName,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServicePrice]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@testareaId int =0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, Test.TestName as AreaName,0.00 as percentage
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
          INNER JOIN Test on Test.TestID=dbo.ForecastedResult.TestId
WHERE   
 ForecastedResult.ServiceConverted=1 and            
1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end                     
		 and
		 1=case when @testareaId=0 then 1 when @testareaId=Test.TestingAreaID then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by Test.TestName
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServiceNoofTestbyduration]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@testareaId int =0
as
begin
SELECT     
 Sum(dbo.ForecastedResult.ForecastValue) as NoofTest, 
 --dbo.TestingArea.TestingAreaID, 
 Test.TestName as AreaName,
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
FROM          dbo.ForecastedResult  
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
        INNER JOIN Test on Test.TestID=dbo.ForecastedResult.TestId 
                      where 
                      ForecastedResult.ServiceConverted=0 and
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @testareaId=0 then 1 when @testareaId=Test.TestingAreaID then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by    Test.TestName,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServiceNoofTest]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@testareaId int =0
as
begin
SELECT     
 Sum(dbo.ForecastedResult.ForecastValue) as NoofTest, 
 --dbo.TestingArea.TestingAreaID, 
 Test.TestName as AreaName,0.00 as percentage
FROM         dbo.ForecastedResult 
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
       INNER JOIN Test on Test.TestID=dbo.ForecastedResult.TestId 
                      where 
                      ForecastedResult.ServiceConverted=0 and
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @testareaId=0 then 1 when @testareaId=Test.TestingAreaID then 1 end                      
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by   Test.TestName
								
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServiceForecastTestbytypeandduration]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@testareaId int =0
as
begin
SELECT     
 Sum(dbo.ForecastedResult.TotalValue) as NoofTest, 
 --dbo.TestingArea.TestingAreaID, 
 Test.TestName as AreaName,
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime,dbo.ForecastedResult.TestingArea
FROM          dbo.ForecastedResult  
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
       INNER JOIN Test on Test.TestID=dbo.ForecastedResult.TestId 
                      where 
                      ForecastedResult.ServiceConverted=0 and
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @testareaId=0 then 1 when @testareaId=Test.TestingAreaID then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by    Test.TestName,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime,dbo.ForecastedResult.TestingArea
						  order by dbo.ForecastedResult.DurationDateTime asc		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServiceForecastProductbytypeandduration]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@protypeid int =0
as
begin
SELECT     
ForecastedResult.ProductType ,
MasterProduct.ProductName as ProductName,
sum(dbo.ForecastedResult.TotalValue) as NoofProduct,  
SUM(dbo.ForecastedResult.PackQty) as PackQty,
SUM(dbo.ForecastedResult.PackPrice) as Price,
dbo.ForecastedResult.Duration,
dbo.ForecastedResult.DurationDateTime,
MasterProduct.BasicUnit
FROM          dbo.ForecastedResult  
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
       INNER JOIN MasterProduct on MasterProduct.ProductID=dbo.ForecastedResult.ProductId 
                      where 
                      ForecastedResult.ServiceConverted=1 and
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @protypeid=0 then 1 when @protypeid= MasterProduct.ProductTypeId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by    MasterProduct.ProductName,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime,dbo.ForecastedResult.ProductType,MasterProduct.BasicUnit
						  order by dbo.ForecastedResult.DurationDateTime asc		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServiceForecastPricebyDuration]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@testareaId int =0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, Test.TestName as AreaName,
       
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
          INNER JOIN Test on Test.TestID=dbo.ForecastedResult.TestId 
WHERE          
 ForecastedResult.ServiceConverted=1 and         
		  1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @testareaId=0 then 1 when @testareaId=Test.TestingAreaID then 1 end                      
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by Test.TestName,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServiceForecastPrice]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@testareaId int =0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice,Test.TestName as AreaName,0.00 as percentage
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
          INNER JOIN Test on Test.TestID=dbo.ForecastedResult.TestId
WHERE   
 ForecastedResult.ServiceConverted=1 and            
1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       		 and
                       		 1=case when @testareaId=0 then 1 when @testareaId=Test.TestingAreaID then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by Test.TestName
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServiceForecastNoofTestTotalSummary]
@forecastid int =0,
@siteid int=0,
@catid int=0
as
begin
SELECT     
 Sum(dbo.ForecastedResult.ForecastValue) as NoofTest, 
 --dbo.TestingArea.TestingAreaID, 
 dbo.ForecastedResult.TestingArea as AreaName,0.00 as percentage
FROM         dbo.ForecastedResult 
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
                      where 
                      ForecastedResult.ServiceConverted=0 and
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by   dbo.ForecastedResult.TestingArea
								
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServiceForecastNoofTestSummary]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@testareaId int =0
as
begin
SELECT     
 Sum(dbo.ForecastedResult.ForecastValue) as NoofTest, 
 --dbo.TestingArea.TestingAreaID, 
Test.TestName as AreaName,0.00 as percentage
FROM         dbo.ForecastedResult 
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
       INNER JOIN Test on Test.TestID=dbo.ForecastedResult.TestId 
                      where 
                      ForecastedResult.ServiceConverted=0 and
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @testareaId=0 then 1 when @testareaId=Test.TestingAreaID then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by Test.TestName
								
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spServiceForecastNoofTestbyduration]
@forecastid int =0,
@siteid int=0,
@catid int=0
as
begin
SELECT     
 Sum(dbo.ForecastedResult.ForecastValue) as NoofTest, 
 --dbo.TestingArea.TestingAreaID, 
 dbo.ForecastedResult.TestingArea as AreaName,
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
FROM          dbo.ForecastedResult  
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
                      where 
                      ForecastedResult.ServiceConverted=0 and
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by    dbo.ForecastedResult.TestingArea,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spProductUsageList]
 @testingarea int=0,
 @producttype int=0
AS
BEGIN
SELECT     dbo.TestingArea.AreaName, dbo.Test.TestName, dbo.Instrument.InstrumentName, dbo.MasterProduct.ProductName, dbo.ProductUsage.TestId, 
                      dbo.ProductUsage.InstrumentId, dbo.ProductUsage.ProductId, dbo.ProductUsage.Rate, dbo.Test.TestingAreaID, dbo.MasterProduct.ProductTypeId
FROM         dbo.ProductUsage INNER JOIN
                      dbo.Test ON dbo.ProductUsage.TestId = dbo.Test.TestID INNER JOIN
                      dbo.Instrument ON dbo.ProductUsage.InstrumentId = dbo.Instrument.InstrumentID INNER JOIN
                      dbo.MasterProduct ON dbo.ProductUsage.ProductId = dbo.MasterProduct.ProductID INNER JOIN
                      dbo.TestingArea ON dbo.Test.TestingAreaID = dbo.TestingArea.TestingAreaID
WHERE
1=case when @testingarea=0 then 1 when @testingarea=Test.TestingAreaID then 1 end and
1=case when @producttype=0 then 1 when @producttype=MasterProduct.ProductTypeId then 1 end                    
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwHistForecastedREsultSumByTestingArea]
AS
SELECT     dbo.ForecastInfo.ForecastID, dbo.ForecastedResult.SiteId, dbo.ForecastedResult.CategoryId, SUM(dbo.ForecastedResult.TotalValue) AS Total, 
                      dbo.ForecastedResult.TestingArea, dbo.ForecastInfo.Extension, COUNT(dbo.ForecastedResult.Id) AS NoofPeriod, dbo.ForecastInfo.Period, 
                      dbo.fnGetPlatformWorkingDays(COUNT(dbo.ForecastedResult.Id), dbo.ForecastedResult.TestingArea, dbo.ForecastInfo.Period, dbo.ForecastedResult.SiteId) 
                      AS workingday
FROM         dbo.ForecastedResult INNER JOIN
                      dbo.ForecastInfo ON dbo.ForecastInfo.ForecastID = dbo.ForecastedResult.ForecastId
WHERE     (dbo.ForecastedResult.ServiceConverted = 0) AND (dbo.ForecastInfo.Methodology = 'SERVICE_STATISTIC') AND (dbo.ForecastedResult.IsHistory = 1)
GROUP BY dbo.ForecastInfo.ForecastID, dbo.ForecastedResult.SiteId, dbo.ForecastedResult.CategoryId, dbo.ForecastedResult.TestingArea, dbo.ForecastInfo.Extension, 
                      dbo.ForecastInfo.Period
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[33] 4[4] 2[26] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ForecastedResult"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 229
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ForecastInfo"
            Begin Extent = 
               Top = 6
               Left = 267
               Bottom = 125
               Right = 473
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwHistForecastedREsultSumByTestingArea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwHistForecastedREsultSumByTestingArea'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwForecastedResultSumByTestingArea]
AS
SELECT     dbo.ForecastInfo.ForecastID, dbo.ForecastedResult.SiteId, dbo.ForecastedResult.CategoryId, SUM(dbo.ForecastedResult.TotalValue) AS Total, 
                      dbo.ForecastedResult.TestingArea, dbo.ForecastInfo.Extension, COUNT(dbo.ForecastedResult.Id) AS NoofPeriod, dbo.ForecastInfo.Period, 
                      dbo.fnGetPlatformWorkingDays(COUNT(dbo.ForecastedResult.Id), dbo.ForecastedResult.TestingArea, dbo.ForecastInfo.Period, dbo.ForecastedResult.SiteId) 
                      AS workingday
FROM         dbo.ForecastedResult INNER JOIN
                      dbo.ForecastInfo ON dbo.ForecastInfo.ForecastID = dbo.ForecastedResult.ForecastId
WHERE     (dbo.ForecastedResult.ServiceConverted = 0) AND (dbo.ForecastInfo.Methodology = 'SERVICE_STATISTIC') AND (dbo.ForecastedResult.IsHistory = 0)
GROUP BY dbo.ForecastInfo.ForecastID, dbo.ForecastedResult.SiteId, dbo.ForecastedResult.CategoryId, dbo.ForecastedResult.TestingArea, dbo.ForecastInfo.Extension, 
                      dbo.ForecastInfo.Period
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[0] 2[33] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ForecastedResult"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 229
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ForecastInfo"
            Begin Extent = 
               Top = 6
               Left = 267
               Bottom = 125
               Right = 473
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwForecastedResultSumByTestingArea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwForecastedResultSumByTestingArea'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spConsumptionTotalSummary]
@forecastid int =0,
@siteid int=0,
@catid int=0
as
begin
SELECT	 SUM(ForecastedResult.PackQty) as TotalPackQty,
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, ForecastedResult.ProductType
        ,
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
WHERE                
		  1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by ForecastedResult.ProductType,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionPriceSummarybyDuration]
@forecastid int =0,
@siteid int=0,
@catid int=0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, ForecastedResult.ProductType
        ,
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
WHERE                
		  1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by ForecastedResult.ProductType,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionPriceSummary]
@forecastid int =0,
@siteid int=0,
@catid int=0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, ForecastedResult.ProductType,0.00 as percentage
        
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
WHERE                
1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       
		  
		 and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by ForecastedResult.ProductType
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionPricebyDuration]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@protypeid int=0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, MasterProduct.ProductName as AreaName,
        
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
           INNER JOIN MasterProduct on MasterProduct.ProductID=dbo.ForecastedResult.ProductId 
WHERE                
		  1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @protypeid=0 then 1 when @protypeid=dbo.ForecastedResult.ProductTypeId  then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by MasterProduct.ProductName,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionPrice]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@protypeid int=0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, MasterProduct.ProductName as AreaName,0.00 as percentage
        
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
           INNER JOIN MasterProduct on MasterProduct.ProductID=dbo.ForecastedResult.ProductId 
WHERE                
1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
						and
		 1=case when @protypeid=0 then 1 when @protypeid=dbo.ForecastedResult.ProductTypeId  then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by MasterProduct.ProductName
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionForecastTotalSummary]
@forecastid int =0,
@siteid int=0,
@catid int=0
as
begin
SELECT     
 Sum(dbo.ForecastedResult.ForecastValue) as NoofTest,  
 dbo.ForecastedResult.ProductType as AreaName,0.00 as percentage
FROM         
                      dbo.ForecastedResult 
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
                      where 
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by    dbo.ForecastedResult.ProductType 
								
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionForecastSummary]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@protypeid int=0
as
begin
SELECT     
 Sum(dbo.ForecastedResult.ForecastValue) as NoofTest,  
 MasterProduct.ProductName as AreaName,0.00 as percentage
FROM         
                      dbo.ForecastedResult 
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
       INNER JOIN MasterProduct on MasterProduct.ProductID=dbo.ForecastedResult.ProductId 
                      where 
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @protypeid=0 then 1 when @protypeid=dbo.ForecastedResult.ProductTypeId  then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by    MasterProduct.ProductName
								
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionForecastProductSummary]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@protypeid int=0
as
begin
SELECT     
 Sum(dbo.ForecastedResult.ForecastValue) as NoofTest,  
 MasterProduct.ProductName as AreaName,0.00 as percentage
FROM         
                      dbo.ForecastedResult 
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
       INNER JOIN MasterProduct on MasterProduct.ProductID=dbo.ForecastedResult.ProductId 
                      where 
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                      1=case when @protypeid=0 then 1 when @protypeid=dbo.ForecastedResult.ProductTypeId  then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by MasterProduct.ProductName
		
								
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionForecastPricebyDuration]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@protypeid int=0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, MasterProduct.ProductName as AreaName
        ,
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
           INNER JOIN MasterProduct on MasterProduct.ProductID=dbo.ForecastedResult.ProductId 
WHERE                
		  1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @protypeid=0 then 1 when @protypeid=dbo.ForecastedResult.ProductTypeId  then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by MasterProduct.ProductName,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionForecastPrice]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@protypeid int=0
as
begin
SELECT	 
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, MasterProduct.ProductName as AreaName,0.00 as percentage
        
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
          INNER JOIN MasterProduct on MasterProduct.ProductID=dbo.ForecastedResult.ProductId 
WHERE                
1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                        and
                        1=case when @protypeid=0 then 1 when @protypeid=dbo.ForecastedResult.ProductTypeId  then 1 end
                       and
		  
		
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by MasterProduct.ProductName
		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionForecastbytypeandduration]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@protypeid int=0
as
begin
SELECT     
ForecastedResult.ProductType ,
MasterProduct.ProductName as ProductName,
sum(dbo.ForecastedResult.TotalValue) as NoofProduct,  
SUM(dbo.ForecastedResult.PackQty) as PackQty,
SUM(dbo.ForecastedResult.PackPrice) as Price,
dbo.ForecastedResult.Duration,
dbo.ForecastedResult.DurationDateTime
FROM                 dbo.ForecastedResult 
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
       INNER JOIN MasterProduct on MasterProduct.ProductID=dbo.ForecastedResult.ProductId 
                      where 
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @protypeid=0 then 1 when @protypeid=dbo.ForecastedResult.ProductTypeId  then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by    MasterProduct.ProductName,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime,ForecastedResult.ProductType
						  order by dbo.ForecastedResult.DurationDateTime asc		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionForecastbyduration]
@forecastid int =0,
@siteid int=0,
@catid int=0
as
begin
SELECT     
 Sum(dbo.ForecastedResult.ForecastValue) as NoofTest, 
 --dbo.TestingArea.TestingAreaID, 
dbo.ForecastedResult.ProductType as AreaName,
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
FROM                 dbo.ForecastedResult 
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
                      where 
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by    dbo.ForecastedResult.ProductType,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsumptionbytypeandduration]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@protypeid int=0
as
begin
SELECT     
 Sum(dbo.ForecastedResult.ForecastValue) as NoofTest, 
 --dbo.TestingArea.TestingAreaID, 
MasterProduct.ProductName as AreaName,
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
FROM                 dbo.ForecastedResult 
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
       INNER JOIN MasterProduct on MasterProduct.ProductID=dbo.ForecastedResult.ProductId 
                      where 
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @protypeid=0 then 1 when @protypeid=dbo.ForecastedResult.ProductTypeId  then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by    MasterProduct.ProductName,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
						  order by dbo.ForecastedResult.DurationDateTime asc		
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spChemandOtherNumberofTestforecast]
@ForecastId int
as
SELECT    
dbo.MorbidityForecast.Title, dbo.MorbidityForecast.DateOfQuantification, 
		   dbo.MorbidityForecast.Descritpion, dbo.MorbidityForecast.SatartDate, 
           dbo.MorbidityForecast.StartBudgetPeriod, dbo.MorbidityForecast.EndBudgetPeriod,
 Id, dbo.ChemandOtherNumberofTest.ForecastId, Platform, SiteId, TestId, TestBasedOnProtocols, SymptomDirectedTests, RepeatedDuetoClinicalReq, InvalidTestandWastage, BufferStock, 
                      ReagentstoRunControls,
                      dbo.fnGetRegionBySite(SiteId) as RegionN,dbo.fnGetSiteName(SiteId)as SiteN,
                      dbo.fnGetTestName(TestId)as TestName
 
FROM   dbo.MorbidityForecast INNER JOIN
       dbo.ChemandOtherNumberofTest ON 
       dbo.MorbidityForecast.ForecastId = dbo.ChemandOtherNumberofTest.ForecastId
where dbo.MorbidityForecast.ForecastId=@ForecastId
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetForecastNoofPatientSummary]
	@ForecastId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.fnGetForecastNoofPatientSummary(@ForecastId)
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spForecasttestno]
@ForecastId int
as
begin
	SELECT   
	
ForecastInfo.[ForecastNo]
,ForecastInfo.[Methodology]
,ForecastInfo.[DataUsage]
,ForecastInfo.[Status]
,ForecastInfo.[StartDate]
,ForecastInfo.[Period]
,ForecastInfo.[Extension]
,ForecastInfo.[ScopeOfTheForecast]
,ForecastInfo.[LastUpdated]
,ForecastInfo.[ForecastDate]
,ForecastInfo.[Method]
,ForecastInfo.[Westage]
,ForecastInfo.[Scaleup]
,dbo.ForecastedResult.ForecastId,
dbo.ForecastedResult.ProductId,
dbo.ForecastedResult.TestId,
dbo.ForecastedResult.Id, 
dbo.ForecastedResult.DurationDateTime,
dbo.ForecastedResult.ForecastValue, 
dbo.ForecastedResult.TotalValue, 
dbo.ForecastedResult.SiteId,
dbo.ForecastedResult.CategoryId, 
dbo.ForecastedResult.Duration,
dbo.Test.TestName,
dbo.Site.SiteName, 
dbo.ForecastCategory.CategoryName,
dbo.fnGetTestAreaName(dbo.ForecastedResult.TestId) as TestingArea,
dbo.fnGetRegionBySite(dbo.Site.SiteID) as RegionName
						FROM  ForecastedResult
						  LEFT OUTER JOIN
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
          LEFT OUTER JOIN
          dbo.ForecastCategory ON dbo.ForecastedResult.CategoryId = dbo.ForecastCategory.CategoryId 
          LEFT OUTER JOIN
          dbo.Site ON dbo.ForecastedResult.SiteId = dbo.Site.SiteID LEFT OUTER JOIN
          dbo.Test ON dbo.ForecastedResult.TestId = dbo.Test.TestID
          
WHERE                
		  (dbo.ForecastedResult.ForecastId = @ForecastId) 
		 and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
		  order by dbo.ForecastedResult.DurationDateTime asc
						
						
						--WHERE ForecastId = @ForecastId
						--GROUP BY TestId, DurationDateTime,Duration
					
				
				
				end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fnGetConsumptionForecastSummary]
(	
	@ForecastId int
)
RETURNS @ForecastSummary TABLE 
(
Methodology nvarchar(64),
ProductType nvarchar(64),
FYear int, 
Quantity DECIMAL(18,9), 
TotalPrice DECIMAL(18,9),
Duration nvarchar(100),
DurationDateTime datetime
)
AS
BEGIN
INSERT INTO @ForecastSummary 
SELECT	'Consumption Statstics',ForecastedResult.ProductType,
        year(dbo.ForecastInfo.StartDate), 
SUM(ForecastedResult.PackQty) as TotalPackQty,
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, 
       
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
WHERE                
		  1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      --and
                     -- 1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                     -- and
                     -- 1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by ForecastedResult.ProductType,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime,dbo.ForecastInfo.StartDate
						  order by dbo.ForecastedResult.DurationDateTime asc
		RETURN
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--dbo.fnGetAdjustedValue(ForecastSiteId,ProductId,AmountUsed,Stockout,InstrumentDowntime)
create FUNCTION [dbo].[fnGetAdjustedValueT] 
(
	@ForecastSiteId int,
	@TestId int,
	@amountused decimal,
	@stockout int,
	@instrumentdowntime int
	
)
RETURNS decimal(18,2)
AS
BEGIN
	DECLARE @count int
	DECLARE @totalsum decimal
	Declare @adjusted decimal(18,2)
	declare @workingDay int
	
	set @adjusted=@amountused
	set @workingDay=22
	
	IF(@amountused=0)
	begin
		select @count=count(Id) from ForecastSiteTest 
		where ForecastSiteID=@ForecastSiteId and TestID=@TestID
		
		select @totalsum= sum(AmountUsed) from ForecastSiteTest
		where ForecastSiteID=@ForecastSiteId and TestID=@TestID
	
		If @count>0
			Set @adjusted=@totalsum/@count
	end
	IF(@stockout>0 or @instrumentdowntime>0)
	begin
	set @workingDay=dbo.fnGetWorkingDays(@ForecastSiteId,0)
		if(@workingDay-(@stockout+@instrumentdowntime))>0
			set @adjusted=(@amountused*@workingDay)/(@workingDay-(@stockout+@instrumentdowntime))
	end
	
	RETURN @adjusted
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--dbo.fnGetAdjustedValueP(ForecastSiteID,ProductID,AmountUsed,StockOut,InstrumentDowntime)
CREATE FUNCTION [dbo].[fnGetAdjustedValueP] 
(
	@ForecastSiteId int,
	@ProductId int,
	@amountused decimal,
	@stockout int,
	@instrumentdowntime int
	
)
RETURNS decimal(18,2)
AS
BEGIN
	DECLARE @count int
	DECLARE @totalsum decimal
	Declare @adjusted decimal(18,2)
	declare @workingDay int
	
	set @adjusted=@amountused
	set @workingDay=22
	
	IF(@amountused=0)
	begin
		select @count=count(Id) from ForecastSiteProduct 
		where ForecastSiteID=@ForecastSiteId and ProductID=@ProductId
		
		select @totalsum= sum(AmountUsed) from ForecastSiteProduct 
		where ForecastSiteID=@ForecastSiteId and ProductID=@ProductId
	
		If @count>0
			Set @adjusted=@totalsum/@count
	end
	IF(@stockout>0 or @instrumentdowntime>0)
	begin
	set @workingDay=dbo.fnGetWorkingDays(@ForecastSiteId,0)
		if(@workingDay-(@stockout+@instrumentdowntime))>0
			set @adjusted=(@amountused*@workingDay)/(@workingDay-(@stockout+@instrumentdowntime))
	end
	
	RETURN @adjusted
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--dbo.fnGetAdjustedValueP(ForecastSiteID,ProductID,AmountUsed,StockOut,InstrumentDowntime)
create FUNCTION [dbo].[fnGetAdjustedValueCT] 
(
	@categoryId int,
	@TestId int,
	@amountused decimal,
	@stockout int,
	@instrumentdowntime int
	
)
RETURNS decimal(18,2)
AS
BEGIN
	DECLARE @count int
	DECLARE @totalsum decimal
	Declare @adjusted decimal(18,2)
	declare @workingDay int
	
	set @adjusted=@amountused
	set @workingDay=22
	
	IF(@amountused=0)
	begin
		select @count=count(Id) from ForecastCategoryTest 
		where CategoryID=@categoryId and TestID=@TestId
		
		select @totalsum= sum(AmountUsed) from ForecastCategoryTest 
		where CategoryID=@categoryId and TestID=@TestId
	
		If @count>0
			Set @adjusted=@totalsum/@count
	end
	IF(@stockout>0 or @instrumentdowntime>0)
	begin
		set @workingDay=22
		set @adjusted=(@amountused*@workingDay)/(@workingDay-(@stockout+@instrumentdowntime))
	end
	
	RETURN @adjusted
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetForecastResultSummary_WithFinfo]
(	
	@ForecastId INT
)
RETURNS @ForecastSummary TABLE 
(
ProductName NVARCHAR(200), 
SerialNo NVARCHAR(64), 
DurationDateTime DATETIME, 
PackQty INT, 
PackPrice DECIMAL(18,9),
TotalPackQty INT, 
TotalPackPrice DECIMAL(18,9),
ForecastId INT,
TestId INT,
TestingArea NVARCHAR(100),
ProductType NVARCHAR(100),
ProductId int
)
AS
BEGIN
DECLARE @Methodology Nvarchar(64)
select @Methodology = Methodology from ForecastInfo 
where ForecastID = @ForecastId
IF @Methodology = 'CONSUMPTION' BEGIN
	INSERT INTO @ForecastSummary(
	ProductName,
	SerialNo,
	DurationDateTime,
	PackQty,
	PackPrice,
	TotalPackQty,
	TotalPackPrice,
	ForecastId,
	ProductType,
	ProductId
	)
	SELECT 
	
	mp.ProductName, 
	mp.SerialNo, 
	pr.DurationDateTime, 
	dbo.fnGetNumberOfPakage(dbo.fnGetProductPacksize(mp.ProductID,pr.DurationDateTime), pr.Tvalue) AS PackQty, 
	(dbo.fnGetNumberOfPakage(dbo.fnGetProductPacksize(mp.ProductID,pr.DurationDateTime), pr.Tvalue) * dbo.fnGetProductPrice(mp.ProductID, pr.DurationDateTime)) AS PackPrice, 
	dbo.fnGetNumberOfPakage(dbo.fnGetProductPacksize(mp.ProductID,pr.DurationDateTime), pr.Tvalue) AS TotalPackQty, 
	--0,
	(dbo.fnGetNumberOfPakage(dbo.fnGetProductPacksize(mp.ProductID,pr.DurationDateTime), pr.Tvalue) * dbo.fnGetProductPrice(mp.ProductID, pr.DurationDateTime)) AS TotalPackPrice,
	--0,
	@ForecastId,
	dbo.fnGetProductType(mp.ProductTypeId) as ProductType,mp.ProductID
	FROM dbo.MasterProduct AS mp INNER JOIN
		 (SELECT  ProductId, DurationDateTime, SUM(TotalValue) AS Fvalue, SUM(TotalValue) AS Tvalue
		  FROM    dbo.ForecastedResult
		  WHERE ForecastId = @ForecastId
		  GROUP BY ProductId, DurationDateTime) AS pr ON pr.ProductId = mp.ProductID
END
ELSE IF @Methodology = 'SERVICE_STATISTIC' BEGIN
	INSERT INTO @ForecastSummary(
    ProductId,
	ProductName,
	SerialNo,
	DurationDateTime,
	PackQty,
	PackPrice,
	TotalPackQty,
	TotalPackPrice,
	ForecastId,
	TestId,
	TestingArea,
	ProductType
	)
SELECT   
	mp.ProductID,
	mp.ProductName, 
	mp.SerialNo, 
	fr.DurDate, 
	dbo.fnGetNumberOfPakage(dbo.fnGetProductPacksize(mp.ProductID,fr.DurDate), fr.TproQty) AS PackQty, 
	(dbo.fnGetNumberOfPakage(dbo.fnGetProductPacksize(mp.ProductID,fr.DurDate), fr.TproQty) * dbo.fnGetProductPrice(mp.ProductID, fr.DurDate)) AS PackPrice, 
	dbo.fnGetNumberOfPakage(dbo.fnGetProductPacksize(mp.ProductID,fr.DurDate), fr.TproQty) AS TotalPackQty, 
	(dbo.fnGetNumberOfPakage(dbo.fnGetProductPacksize(mp.ProductID,fr.DurDate), fr.TproQty) * dbo.fnGetProductPrice(mp.ProductID, fr.DurDate)) AS TotalPackPrice,
	@ForecastId,
	fr.TestId,
	dbo.fnGetTestAreaName(fr.TestId) as TesingArea,
	dbo.fnGetProductType(mp.ProductTypeId) as ProductType
	FROM dbo.MasterProduct AS mp 
	INNER JOIN (
	
	SELECT  pr.TestId as TestId,ProductId, pr.DurationDateTime as DurDate, sum(Rate * pr.Tvalue) as ProQty,sum(Rate * pr.Tvalue) as TproQty
				FROM   ProductUsage as pu Inner join 
					(SELECT   TestId, DurationDateTime, sum(TotalValue) AS Fvalue, sum(TotalValue) AS Tvalue
						FROM  ForecastedResult inner join ForecastInfo on ForecastedResult.ForecastId=ForecastInfo.ForecastId
						WHERE ForecastedResult.ForecastId = @ForecastId
						 and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
						GROUP BY TestId, DurationDateTime
					) as pr on pr.TestId = pu.TestId
				Group By pr.TestId,pu.ProductId, pr.DurationDateTime
				) AS fr ON fr.ProductId = mp.ProductID
END                       
RETURN
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetForecastResultSummary]
(	
	@ForecastId INT
)
RETURNS @ForecastSummary TABLE 
(
ProductName NVARCHAR(200), 
SerialNo NVARCHAR(200), 
DurationDateTime DATETIME, 
PackQty INT, 
PackPrice DECIMAL(18,9),
TotalPackQty INT, 
TotalPackPrice DECIMAL(18,9)
)
AS
BEGIN
DECLARE @Methodology Nvarchar(64)
select @Methodology = Methodology from ForecastInfo 
where ForecastID = @ForecastId
IF @Methodology = 'CONSUMPTION' BEGIN
	INSERT INTO @ForecastSummary(
	ProductName,
	SerialNo,
	DurationDateTime,
	PackQty,
	PackPrice,
	TotalPackQty,
	TotalPackPrice
	)
	SELECT   
	mp.ProductName, 
	mp.SerialNo, 
	pr.DurationDateTime, 
	dbo.fnGetNumberOfPakage(mp.MinimumPackPerSite, pr.Fvalue) AS PackQty, 
	(dbo.fnGetNumberOfPakage(mp.MinimumPackPerSite, pr.Fvalue) * dbo.fnGetProductPrice(mp.ProductID, pr.DurationDateTime)) AS PackPrice, 
	dbo.fnGetNumberOfPakage(mp.MinimumPackPerSite, pr.Tvalue) AS TotalPackQty, 
	(dbo.fnGetNumberOfPakage(mp.MinimumPackPerSite, pr.Tvalue) * dbo.fnGetProductPrice(mp.ProductID, pr.DurationDateTime)) AS TotalPackPrice
	FROM dbo.MasterProduct AS mp INNER JOIN
		 (SELECT  ProductId, DurationDateTime, SUM(ForecastValue) AS Fvalue, SUM(TotalValue) AS Tvalue
		  FROM    dbo.ForecastedResult
		  WHERE ForecastId = @ForecastId
		  GROUP BY ProductId, DurationDateTime) AS pr ON pr.ProductId = mp.ProductID
END
ELSE IF @Methodology = 'SERVICE_STATISTIC' BEGIN
	INSERT INTO @ForecastSummary(
	ProductName,
	SerialNo,
	DurationDateTime,
	PackQty,
	PackPrice,
	TotalPackQty,
	TotalPackPrice
	)
	SELECT   
	mp.ProductName, 
	mp.SerialNo, 
	fr.DurDate, 
	dbo.fnGetNumberOfPakage(mp.MinimumPackPerSite, fr.ProQty) AS PackQty, 
	(dbo.fnGetNumberOfPakage(mp.MinimumPackPerSite, fr.ProQty) * dbo.fnGetProductPrice(mp.ProductID, fr.DurDate)) AS PackPrice, 
	dbo.fnGetNumberOfPakage(mp.MinimumPackPerSite, fr.TproQty) AS TotalPackQty, 
	(dbo.fnGetNumberOfPakage(mp.MinimumPackPerSite, fr.TproQty) * dbo.fnGetProductPrice(mp.ProductID, fr.DurDate)) AS TotalPackPrice
	FROM dbo.MasterProduct AS mp 
	INNER JOIN (SELECT  ProductId, pr.DurationDateTime as DurDate, Sum(Rate * pr.Fvalue) as ProQty, SUM(Rate * pr.Tvalue) as TproQty
				FROM   ProductUsage as pu Inner join 
					(SELECT   TestId, DurationDateTime, SUM(ForecastValue) AS Fvalue, SUM(TotalValue) AS Tvalue
						FROM  ForecastedResult
						WHERE ForecastId = @ForecastId
						GROUP BY TestId, DurationDateTime
					) as pr on pr.TestId = pu.TestId
				Group By pu.ProductId, pr.DurationDateTime
				) AS fr ON fr.ProductId = mp.ProductID
END                       
RETURN
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InstContributionUtilization]
	@ForecastId INT,
	@TestingAreaName nvarchar(50)
	as
	SELECT dbo.SiteInstrument.SiteID, TestingArea_1.AreaName, dbo.SiteInstrument.TestRunPercentage *
	(SELECT SUM(dbo.ForecastSiteTest.AmountUsed) AS TestRun
	FROM dbo.ForecastSiteTest INNER JOIN
	dbo.Test ON dbo.ForecastSiteTest.TestID = dbo.Test.TestID INNER JOIN
	dbo.TestingArea ON dbo.Test.TestingAreaID =dbo.TestingArea.TestingAreaID INNER JOIN
	dbo.ForecastSite ON dbo.ForecastSiteTest.ForecastSiteID = dbo.ForecastSite.Id INNER JOIN
	dbo.ForecastInfo ON dbo.ForecastSite.ForecastInfoId = dbo.ForecastInfo.ForecastID
	WHERE (dbo.ForecastInfo.ForecastID = @ForecastId) AND (dbo.ForecastSite.SiteId = dbo.SiteInstrument.SiteID) AND
	(dbo.TestingArea.AreaName = TestingArea_1.AreaName)
	GROUP BY dbo.TestingArea.AreaName, dbo.ForecastSite.SiteId) / 100 AS TestDone, dbo.Instrument.MaxThroughPut,
	dbo.SiteInstrument.TestRunPercentage *
	(SELECT SUM(ForecastSiteTest_1.AmountUsed) AS TestRun
	FROM dbo.ForecastSiteTest AS ForecastSiteTest_1 INNER JOIN
	dbo.Test AS Test_1 ON ForecastSiteTest_1.TestID = Test_1.TestID INNER JOIN
	dbo.TestingArea AS TestingArea_2 ON Test_1.TestingAreaID = TestingArea_2.TestingAreaID INNER JOIN
	dbo.ForecastSite AS ForecastSite_1 ON ForecastSiteTest_1.ForecastSiteID = ForecastSite_1.Id INNER JOIN
	dbo.ForecastInfo AS ForecastInfo_1 ON ForecastSite_1.ForecastInfoId = ForecastInfo_1.ForecastID
	WHERE (ForecastInfo_1.ForecastID = @ForecastId) AND (ForecastSite_1.SiteId = dbo.SiteInstrument.SiteID) AND
	(TestingArea_2.AreaName = TestingArea_1.AreaName)
	GROUP BY TestingArea_2.AreaName, ForecastSite_1.SiteId) / dbo.Instrument.MaxThroughPut AS Utilization,
	dbo.SiteInstrument.TestRunPercentage *
	(SELECT SUM(ForecastSiteTest_3.AmountUsed) AS TestRun
	FROM dbo.ForecastSiteTest AS ForecastSiteTest_3 INNER JOIN
	dbo.Test AS Test_3 ON ForecastSiteTest_3.TestID = Test_3.TestID INNER JOIN
	dbo.TestingArea AS TestingArea_4 ON Test_3.TestingAreaID = TestingArea_4.TestingAreaID INNER JOIN
	dbo.ForecastSite AS ForecastSite_3 ON ForecastSiteTest_3.ForecastSiteID = ForecastSite_3.Id INNER JOIN
	dbo.ForecastInfo AS ForecastInfo_3 ON ForecastSite_3.ForecastInfoId = ForecastInfo_3.ForecastID
	WHERE (ForecastInfo_3.ForecastID = @ForecastId) AND (ForecastSite_3.SiteId = dbo.SiteInstrument.SiteID) AND
	(TestingArea_4.AreaName = TestingArea_1.AreaName)
	GROUP BY TestingArea_4.AreaName, ForecastSite_3.SiteId) /
	(SELECT SUM(ForecastSiteTest_2.AmountUsed) AS TestRun
	FROM dbo.ForecastSiteTest AS ForecastSiteTest_2 INNER JOIN
	dbo.Test AS Test_2 ON ForecastSiteTest_2.TestID = Test_2.TestID INNER JOIN
	dbo.TestingArea AS TestingArea_3 ON Test_2.TestingAreaID = TestingArea_3.TestingAreaID INNER JOIN
	dbo.ForecastSite AS ForecastSite_2 ON ForecastSiteTest_2.ForecastSiteID = ForecastSite_2.Id INNER JOIN
	dbo.ForecastInfo AS ForecastInfo_2 ON ForecastSite_2.ForecastInfoId = ForecastInfo_2.ForecastID
	WHERE (ForecastInfo_2.ForecastID = @ForecastId) AND ((TestingArea_3.AreaName = TestingArea_1.AreaName))
	GROUP BY TestingArea_3.AreaName) AS DiagnosticContribution, dbo.Instrument.InstrumentName
	FROM dbo.SiteInstrument INNER JOIN
	dbo.Site ON dbo.SiteInstrument.SiteID = dbo.Site.SiteID INNER JOIN
	dbo.Instrument ON dbo.SiteInstrument.InstrumentID = dbo.Instrument.InstrumentID INNER JOIN
	dbo.TestingArea AS TestingArea_1 ON dbo.Instrument.TestingAreaID = TestingArea_1.TestingAreaID
	where(TestingArea_1.AreaName = @TestingAreaName) 
	GROUP BY dbo.SiteInstrument.SiteID, TestingArea_1.AreaName, dbo.SiteInstrument.TestRunPercentage, dbo.Instrument.MaxThroughPut,
	dbo.Instrument.InstrumentName
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fnGetServiceForecastSummary]
(	
	@ForecastId int
)
RETURNS @ForecastSummary TABLE 
(
Methodology nvarchar(64),
ProductType nvarchar(64),
FYear int, 
Quantity DECIMAL(18,9), 
TotalPrice DECIMAL(18,9),
Duration nvarchar(100),
DurationDateTime datetime
)
AS
BEGIN
INSERT INTO @ForecastSummary 
SELECT	'Service Statstics',ForecastedResult.ProductType,
        year(dbo.ForecastInfo.StartDate), 
SUM(ForecastedResult.PackQty) as TotalPackQty,
        sum(dbo.ForecastedResult.PackPrice) as TotalPrice, 
       
 dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime
        
FROM     ForecastedResult inner join
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
WHERE          
 ForecastedResult.ServiceConverted=1 and         
		  1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                     -- and
                    --  1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                     -- and
                    --  1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 group by ForecastedResult.ProductType,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime,dbo.ForecastInfo.StartDate
						  order by dbo.ForecastedResult.DurationDateTime asc   
RETURN
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuantificationMetric](
	[QuantifyMenuId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassOfTest] [nvarchar](16) NOT NULL,
	[UsageRate] [float] NOT NULL,
	[CollectionSupplieAppliedTo] [nvarchar](16) NULL,
 CONSTRAINT [PK_QuantificationMetric] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetForecastComparisionSummary]
(	@MForecastId int=-1,
	@SForecastId int=-1,
	@CForecastId int=-1
)
RETURNS @ForecastSummary TABLE 
(
Methodology nvarchar(64),
ProductType nvarchar(64),
FYear int, 
Quantity DECIMAL(18,9), 
TotalPrice DECIMAL(18,9),
Duration nvarchar(100),
DurationDateTime datetime,
Title nvarchar(100)
)
AS
BEGIN
DECLARE @Title Nvarchar(64)
select @Title = Title from MorbidityForecast where ForecastID = @MForecastId 
INSERT INTO @ForecastSummary 
Select *,@Title from dbo.fnGetMorbidityForecastSummary(@MForecastId)
select @Title = ForecastNo from ForecastInfo where ForecastID = @SForecastId
INSERT INTO @ForecastSummary 
Select *,@Title from dbo.fnGetServiceForecastSummary(@SForecastId)
--where 
--1= case when @MForecastId=-1 then 1 when Fyear=(Select top 1 Fyear from dbo.fnGetMorbidityForecastSummary(@MForecastId))then 1 end
select @Title = ForecastNo from ForecastInfo where ForecastID = @CForecastId
INSERT INTO @ForecastSummary 
Select *,@Title from dbo.fnGetConsumptionForecastSummary(@CForecastId) 
--where
--1= case when @MForecastId=-1 then 1 when Fyear=(Select top 1 Fyear from dbo.fnGetMorbidityForecastSummary(@MForecastId))then 1 end
RETURN
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetServiceandConsumptionForecastSummary]
(	
	@ForecastId int
)
RETURNS @ForecastSummary TABLE 
(
Methodology nvarchar(64),
ProductType nvarchar(64),
--ProductName NVARCHAR(64), 
FYear int, 
--DurationDate DATETIME, 
Quantity DECIMAL(18,9), 
--Price DECIMAL(18,9),
TotalPrice DECIMAL(18,9)
)
AS
BEGIN
INSERT INTO @ForecastSummary 
SELECT
		dbo.ForecastInfo.Methodology,
		  fnGetForecastResultSummary_WithFinfo_1.ProductType,
		  --fnGetForecastResultSummary_WithFinfo_1.ProductName,
		  --dbo.ForecastedResult.Duration,
		  Year(dbo.ForecastedResult.DurationDateTime),
          sum(fnGetForecastResultSummary_WithFinfo_1.TotalPackQty), 
        --  Sum(fnGetForecastResultSummary_WithFinfo_1.PackPrice),
          Sum(fnGetForecastResultSummary_WithFinfo_1.TotalPackPrice)
FROM      
	      dbo.fnGetForecastResultSummary_WithFinfo(@ForecastId) AS fnGetForecastResultSummary_WithFinfo_1 
	      RIGHT OUTER JOIN dbo.ForecastedResult ON 
	      fnGetForecastResultSummary_WithFinfo_1.ForecastId = dbo.ForecastedResult.ForecastId 
	        and 
	       ForecastedResult.DurationDateTime = fnGetForecastResultSummary_WithFinfo_1.DurationDateTime 
	       and ForecastedResult.ProductId=fnGetForecastResultSummary_WithFinfo_1.ProductId 
	      LEFT OUTER JOIN
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
          LEFT OUTER JOIN
          dbo.ForecastCategory ON dbo.ForecastedResult.CategoryId = dbo.ForecastCategory.CategoryId 
          LEFT OUTER JOIN
          dbo.Site ON dbo.ForecastedResult.SiteId = dbo.Site.SiteID LEFT OUTER JOIN
          dbo.Test ON dbo.ForecastedResult.TestId = dbo.Test.TestID
          
WHERE                
		  (dbo.ForecastedResult.ForecastId = @ForecastId) 
		 -- AND dbo.ForecastedResult.IsHistory='False' 
		 and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		  and
		  (fnGetForecastResultSummary_WithFinfo_1.DurationDateTime = 
		  dbo.ForecastedResult.DurationDateTime)
		  group by dbo.ForecastInfo.Methodology, fnGetForecastResultSummary_WithFinfo_1.ProductType,Year(dbo.ForecastedResult.DurationDateTime)
		  order by Year(dbo.ForecastedResult.DurationDateTime) asc      
RETURN
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spForecastSummeries]
@ForecastId int
as
SELECT	  dbo.ForecastInfo.*,dbo.ForecastedResult.ForecastId, dbo.ForecastedResult.ProductId, dbo.ForecastedResult.TestId,
		  dbo.ForecastedResult.Id, dbo.ForecastedResult.DurationDateTime,
		  dbo.ForecastedResult.ForecastValue, dbo.ForecastedResult.TotalValue, 
		  dbo.ForecastedResult.SiteId, dbo.ForecastedResult.CategoryId, 
          dbo.ForecastedResult.Duration, dbo.Test.TestName, dbo.Site.SiteName, 
          dbo.ForecastCategory.CategoryName,fnGetForecastResultSummary_WithFinfo_1.ProductName, 
          fnGetForecastResultSummary_WithFinfo_1.PackQty, 
          fnGetForecastResultSummary_WithFinfo_1.PackPrice, 
          fnGetForecastResultSummary_WithFinfo_1.TotalPackQty, 
          fnGetForecastResultSummary_WithFinfo_1.TotalPackPrice
FROM      
	      dbo.fnGetForecastResultSummary_WithFinfo(@ForecastId) AS fnGetForecastResultSummary_WithFinfo_1 
	      RIGHT OUTER JOIN dbo.ForecastedResult ON 
	      fnGetForecastResultSummary_WithFinfo_1.ForecastId = dbo.ForecastedResult.ForecastId 
	      LEFT OUTER JOIN
          dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID 
          LEFT OUTER JOIN
          dbo.ForecastCategory ON dbo.ForecastedResult.CategoryId = dbo.ForecastCategory.CategoryId 
          LEFT OUTER JOIN
          dbo.Site ON dbo.ForecastedResult.SiteId = dbo.Site.SiteID LEFT OUTER JOIN
          dbo.Test ON dbo.ForecastedResult.TestId = dbo.Test.TestID
          
WHERE                
		  (dbo.ForecastedResult.ForecastId = @ForecastId) 
		 -- AND dbo.ForecastedResult.IsHistory='False' 
		 and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		  and
		  (fnGetForecastResultSummary_WithFinfo_1.DurationDateTime = 
		  dbo.ForecastedResult.DurationDateTime)
		  order by dbo.ForecastedResult.DurationDateTime asc
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetForecastResultSummary]
	@ForecastId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.fnGetForecastResultSummary(@ForecastId)
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwContributionbySite]
AS
SELECT     vwFRS.ForecastID, vwFRS.SiteId, vwFRS.CategoryId, vwFRS.TestingArea, vwSI.InstrumentName, vwFRS.Total * vwSI.TestRunPercentage / 100 AS TestsDone, 
                      vwFRS.Total * vwSI.TestRunPercentage / 100 / vwFRS.Total AS Contribution, vwFRS.Total * vwSI.TestRunPercentage / 100 / vwFRS.workingday AS TestPerDay, 
                      vwFRS.Total * vwSI.TestRunPercentage / 100 / vwFRS.workingday / vwSI.TotalThroughPut AS Utilization, vwSI.Quantity AS Qty
FROM         dbo.vwForecastedResultSumByTestingArea AS vwFRS INNER JOIN
                      dbo.vwSiteInstrument AS vwSI ON vwFRS.SiteId = vwSI.SiteID AND vwFRS.TestingArea = vwSI.AreaName
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwAggregateContribution]
AS
SELECT     vwFRS.ForecastID, vwFRS.TestingArea, vwSI.InstrumentName, SUM(vwFRS.Total * vwSI.TestRunPercentage / 100) AS TestsDone, 
                      SUM(vwFRS.Total * vwSI.TestRunPercentage / 100) / SUM(vwFRS.Total) AS Contribution, SUM(vwFRS.Total * vwSI.TestRunPercentage / 100) / (SUM(vwSI.Quantity) 
                      * AVG(dbo.fnWorkPeriodToDays(vwFRS.workingday, vwFRS.Period)) * AVG(vwSI.MaxThroughPut)) AS Utilization, SUM(vwSI.Quantity) AS Qty
FROM         dbo.vwForecastedResultSumByTestingArea AS vwFRS INNER JOIN
                      dbo.vwSiteInstrument AS vwSI ON vwFRS.SiteId = vwSI.SiteID AND vwFRS.TestingArea = vwSI.AreaName
GROUP BY vwFRS.ForecastID, vwFRS.TestingArea, vwSI.InstrumentName
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwHistContributionbySite]
AS
SELECT     vwFRS.ForecastID, vwFRS.SiteId, vwFRS.CategoryId, vwFRS.TestingArea, vwSI.InstrumentName, vwFRS.Total * vwSI.TestRunPercentage / 100 AS TestsDone, 
                      vwFRS.Total * vwSI.TestRunPercentage / 100 / vwFRS.Total AS Contribution, vwFRS.Total * vwSI.TestRunPercentage / 100 / vwFRS.workingday AS TestPerDay, 
                      vwFRS.Total * vwSI.TestRunPercentage / 100 / vwFRS.workingday / vwSI.TotalThroughPut AS Utilization, vwSI.Quantity AS Qty
FROM         dbo.vwHistForecastedREsultSumByTestingArea AS vwFRS INNER JOIN
                      dbo.vwSiteInstrument AS vwSI ON vwFRS.SiteId = vwSI.SiteID AND vwFRS.TestingArea = vwSI.AreaName
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "vwFRS"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vwSI"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 125
               Right = 420
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwHistContributionbySite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwHistContributionbySite'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwHistAggregateContribution]
AS
SELECT     vwFRS.ForecastID, vwFRS.TestingArea, vwSI.InstrumentName, SUM(vwFRS.Total * vwSI.TestRunPercentage / 100) AS TestsDone, 
                      SUM(vwFRS.Total * vwSI.TestRunPercentage / 100) / SUM(vwFRS.Total) AS Contribution, SUM(vwFRS.Total * vwSI.TestRunPercentage / 100) / (SUM(vwSI.Quantity) 
                      * AVG(dbo.fnWorkPeriodToDays(vwFRS.workingday, vwFRS.Period)) * AVG(vwSI.MaxThroughPut)) AS Utilization, SUM(vwSI.Quantity) AS Qty
FROM         dbo.vwHistForecastedREsultSumByTestingArea AS vwFRS INNER JOIN
                      dbo.vwSiteInstrument AS vwSI ON vwFRS.SiteId = vwSI.SiteID AND vwFRS.TestingArea = vwSI.AreaName
GROUP BY vwFRS.ForecastID, vwFRS.TestingArea, vwSI.InstrumentName
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "vwFRS"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vwSI"
            Begin Extent = 
               Top = 6
               Left = 252
               Bottom = 125
               Right = 452
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwHistAggregateContribution'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwHistAggregateContribution'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSiteLevelContribandUtil]
@ForecastId int=0,
@SiteId int=0,
@TestingArea varchar(100)=''
AS
BEGIN
 Select * from dbo.vwContributionbySite
 where
 1=case when @ForecastId=0 then 1 when @ForecastId=ForecastID then 1 end and
 1=case when @SiteId=0 then 1 when @SiteId=SiteId then 1 end and
 1=case when @TestingArea='' then 1 when @TestingArea like TestingArea then 1 end
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spHistSiteLevelContribandUtil]
@ForecastId int=0,
@SiteId int=0,
@TestingArea varchar(100)=''
AS
BEGIN
 Select * from dbo.vwHistContributionbySite
 where
 1=case when @ForecastId=0 then 1 when @ForecastId=ForecastID then 1 end and
 1=case when @SiteId=0 then 1 when @SiteId=SiteId then 1 end and
 1=case when @TestingArea='' then 1 when @TestingArea like TestingArea then 1 end
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spHistContribandUtil]
@ForecastId int=0,
@TestingArea varchar(100)=''
AS
BEGIN
 Select * from dbo.vwHistAggregateContribution
 where
 1=case when @ForecastId=0 then 1 when @ForecastId=ForecastID then 1 end and
 1=case when @TestingArea='' then 1 when @TestingArea like TestingArea then 1 end
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spGetForecastComparision]
@MForecastId int,
@SForecastId int,
	@CForecastId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.fnGetForecastComparisionSummary(@MForecastId,@SForecastId,@CForecastId)
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spContribandUtil]
@ForecastId int=0,
@TestingArea varchar(100)=''
AS
BEGIN
 Select * from dbo.vwAggregateContribution
 where
 1=case when @ForecastId=0 then 1 when @ForecastId=ForecastID then 1 end and
 1=case when @TestingArea='' then 1 when @TestingArea like TestingArea then 1 end
END
GO
ALTER TABLE [dbo].[ForecastInfo] ADD  CONSTRAINT [DF_ForecastInfo_ActualCount]  DEFAULT ((0)) FOR [ActualCount]
GO
ALTER TABLE [dbo].[ForecastCategory]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategory_ForecastInfo] FOREIGN KEY([ForecastId])
REFERENCES [dbo].[ForecastInfo] ([ForecastID])
GO
ALTER TABLE [dbo].[ForecastCategory] CHECK CONSTRAINT [FK_ForecastCategory_ForecastInfo]
GO
ALTER TABLE [dbo].[ForecastCategoryProduct]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategoryProduct_ForecastCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ForecastCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[ForecastCategoryProduct] CHECK CONSTRAINT [FK_ForecastCategoryProduct_ForecastCategory]
GO
ALTER TABLE [dbo].[ForecastCategoryProduct]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategoryProduct_MasterProduct] FOREIGN KEY([ProductID])
REFERENCES [dbo].[MasterProduct] ([ProductID])
GO
ALTER TABLE [dbo].[ForecastCategoryProduct] CHECK CONSTRAINT [FK_ForecastCategoryProduct_MasterProduct]
GO
ALTER TABLE [dbo].[ForecastCategorySite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategorySite_ForecastCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ForecastCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[ForecastCategorySite] CHECK CONSTRAINT [FK_ForecastCategorySite_ForecastCategory]
GO
ALTER TABLE [dbo].[ForecastCategorySite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategorySite_Site] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Site] ([SiteID])
GO
ALTER TABLE [dbo].[ForecastCategorySite] CHECK CONSTRAINT [FK_ForecastCategorySite_Site]
GO
ALTER TABLE [dbo].[ForecastCategoryTest]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategoryTest_ForecastCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ForecastCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[ForecastCategoryTest] CHECK CONSTRAINT [FK_ForecastCategoryTest_ForecastCategory]
GO
ALTER TABLE [dbo].[ForecastCategoryTest]  WITH CHECK ADD  CONSTRAINT [FK_ForecastCategoryTest_Test] FOREIGN KEY([TestID])
REFERENCES [dbo].[Test] ([TestID])
GO
ALTER TABLE [dbo].[ForecastCategoryTest] CHECK CONSTRAINT [FK_ForecastCategoryTest_Test]
GO
ALTER TABLE [dbo].[ForecastedResult]  WITH NOCHECK ADD  CONSTRAINT [FK_ForecastedResult_ForecastCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ForecastCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[ForecastedResult] NOCHECK CONSTRAINT [FK_ForecastedResult_ForecastCategory]
GO
ALTER TABLE [dbo].[ForecastedResult]  WITH NOCHECK ADD  CONSTRAINT [FK_ForecastedResult_ForecastInfo] FOREIGN KEY([ForecastId])
REFERENCES [dbo].[ForecastInfo] ([ForecastID])
GO
ALTER TABLE [dbo].[ForecastedResult] CHECK CONSTRAINT [FK_ForecastedResult_ForecastInfo]
GO
ALTER TABLE [dbo].[ForecastedResult]  WITH NOCHECK ADD  CONSTRAINT [FK_ForecastedResult_MasterProduct] FOREIGN KEY([ProductId])
REFERENCES [dbo].[MasterProduct] ([ProductID])
GO
ALTER TABLE [dbo].[ForecastedResult] NOCHECK CONSTRAINT [FK_ForecastedResult_MasterProduct]
GO
ALTER TABLE [dbo].[ForecastedResult]  WITH NOCHECK ADD  CONSTRAINT [FK_ForecastedResult_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteID])
GO
ALTER TABLE [dbo].[ForecastedResult] NOCHECK CONSTRAINT [FK_ForecastedResult_Site]
GO
ALTER TABLE [dbo].[ForecastedResult]  WITH NOCHECK ADD  CONSTRAINT [FK_ForecastedResult_Test] FOREIGN KEY([TestId])
REFERENCES [dbo].[Test] ([TestID])
GO
ALTER TABLE [dbo].[ForecastedResult] NOCHECK CONSTRAINT [FK_ForecastedResult_Test]
GO
ALTER TABLE [dbo].[ForecastNRSite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastNRSite_ForecastSite] FOREIGN KEY([ForecastSiteId])
REFERENCES [dbo].[ForecastSite] ([Id])
GO
ALTER TABLE [dbo].[ForecastNRSite] CHECK CONSTRAINT [FK_ForecastNRSite_ForecastSite]
GO
ALTER TABLE [dbo].[ForecastNRSite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastNRSite_Site] FOREIGN KEY([NReportedSiteId])
REFERENCES [dbo].[Site] ([SiteID])
GO
ALTER TABLE [dbo].[ForecastNRSite] CHECK CONSTRAINT [FK_ForecastNRSite_Site]
GO
ALTER TABLE [dbo].[ForecastSite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastSite_ForecastInfo] FOREIGN KEY([ForecastInfoId])
REFERENCES [dbo].[ForecastInfo] ([ForecastID])
GO
ALTER TABLE [dbo].[ForecastSite] CHECK CONSTRAINT [FK_ForecastSite_ForecastInfo]
GO
ALTER TABLE [dbo].[ForecastSite]  WITH CHECK ADD  CONSTRAINT [FK_ForecastSite_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteID])
GO
ALTER TABLE [dbo].[ForecastSite] CHECK CONSTRAINT [FK_ForecastSite_Site]
GO
ALTER TABLE [dbo].[ForecastSiteProduct]  WITH CHECK ADD  CONSTRAINT [FK_ForecastSiteProduct_ForecastSite] FOREIGN KEY([ForecastSiteID])
REFERENCES [dbo].[ForecastSite] ([Id])
GO
ALTER TABLE [dbo].[ForecastSiteProduct] CHECK CONSTRAINT [FK_ForecastSiteProduct_ForecastSite]
GO
ALTER TABLE [dbo].[ForecastSiteProduct]  WITH CHECK ADD  CONSTRAINT [FK_ForecastSiteProduct_MasterProduct] FOREIGN KEY([ProductID])
REFERENCES [dbo].[MasterProduct] ([ProductID])
GO
ALTER TABLE [dbo].[ForecastSiteProduct] CHECK CONSTRAINT [FK_ForecastSiteProduct_MasterProduct]
GO
ALTER TABLE [dbo].[ForecastSiteTest]  WITH CHECK ADD  CONSTRAINT [FK_ForecastSiteTest_ForecastSite] FOREIGN KEY([ForecastSiteID])
REFERENCES [dbo].[ForecastSite] ([Id])
GO
ALTER TABLE [dbo].[ForecastSiteTest] CHECK CONSTRAINT [FK_ForecastSiteTest_ForecastSite]
GO
ALTER TABLE [dbo].[ForecastSiteTest]  WITH CHECK ADD  CONSTRAINT [FK_ForecastSiteTest_Test] FOREIGN KEY([TestID])
REFERENCES [dbo].[Test] ([TestID])
GO
ALTER TABLE [dbo].[ForecastSiteTest] CHECK CONSTRAINT [FK_ForecastSiteTest_Test]
GO
ALTER TABLE [dbo].[Instrument]  WITH CHECK ADD  CONSTRAINT [FK_Instrument_TestingArea] FOREIGN KEY([TestingAreaID])
REFERENCES [dbo].[TestingArea] ([TestingAreaID])
GO
ALTER TABLE [dbo].[Instrument] CHECK CONSTRAINT [FK_Instrument_TestingArea]
GO
ALTER TABLE [dbo].[InventoryAssumptions]  WITH CHECK ADD  CONSTRAINT [FK_InventoryAssumptions_MorbidityForecast] FOREIGN KEY([ForecastId])
REFERENCES [dbo].[MorbidityForecast] ([ForecastId])
GO
ALTER TABLE [dbo].[InventoryAssumptions] CHECK CONSTRAINT [FK_InventoryAssumptions_MorbidityForecast]
GO
ALTER TABLE [dbo].[MasterProduct]  WITH CHECK ADD  CONSTRAINT [FK_MasterProduct_ProductType] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductType] ([TypeID])
GO
ALTER TABLE [dbo].[MasterProduct] CHECK CONSTRAINT [FK_MasterProduct_ProductType]
GO
ALTER TABLE [dbo].[MorbidityCategory]  WITH CHECK ADD  CONSTRAINT [FK_MorbidityCategory_MorbidityForecast] FOREIGN KEY([ForecastId])
REFERENCES [dbo].[MorbidityForecast] ([ForecastId])
GO
ALTER TABLE [dbo].[MorbidityCategory] CHECK CONSTRAINT [FK_MorbidityCategory_MorbidityForecast]
GO
ALTER TABLE [dbo].[MorbidityTest]  WITH CHECK ADD  CONSTRAINT [FK_MorbidityTest_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [dbo].[Instrument] ([InstrumentID])
GO
ALTER TABLE [dbo].[MorbidityTest] CHECK CONSTRAINT [FK_MorbidityTest_Instrument]
GO
ALTER TABLE [dbo].[MordidityCategorySite]  WITH CHECK ADD  CONSTRAINT [FK_MordidityCategorySite_MorbidityCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[MorbidityCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[MordidityCategorySite] CHECK CONSTRAINT [FK_MordidityCategorySite_MorbidityCategory]
GO
ALTER TABLE [dbo].[MordidityCategorySite]  WITH CHECK ADD  CONSTRAINT [FK_MordidityCategorySite_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteID])
GO
ALTER TABLE [dbo].[MordidityCategorySite] CHECK CONSTRAINT [FK_MordidityCategorySite_Site]
GO
ALTER TABLE [dbo].[PanelTest]  WITH CHECK ADD  CONSTRAINT [FK_PanelTest_ProtocolPanel] FOREIGN KEY([PanelId])
REFERENCES [dbo].[ProtocolPanel] ([Id])
GO
ALTER TABLE [dbo].[PanelTest] CHECK CONSTRAINT [FK_PanelTest_ProtocolPanel]
GO
ALTER TABLE [dbo].[PanelTest]  WITH CHECK ADD  CONSTRAINT [FK_PanelTest_Test] FOREIGN KEY([TestId])
REFERENCES [dbo].[Test] ([TestID])
GO
ALTER TABLE [dbo].[PanelTest] CHECK CONSTRAINT [FK_PanelTest_Test]
GO
ALTER TABLE [dbo].[ProductPrice]  WITH CHECK ADD  CONSTRAINT [FK_ProductPrice_MasterProduct] FOREIGN KEY([ProductId])
REFERENCES [dbo].[MasterProduct] ([ProductID])
GO
ALTER TABLE [dbo].[ProductPrice] CHECK CONSTRAINT [FK_ProductPrice_MasterProduct]
GO
ALTER TABLE [dbo].[ProductUsage]  WITH CHECK ADD  CONSTRAINT [FK_ProductUsage_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [dbo].[Instrument] ([InstrumentID])
GO
ALTER TABLE [dbo].[ProductUsage] CHECK CONSTRAINT [FK_ProductUsage_Instrument]
GO
ALTER TABLE [dbo].[ProductUsage]  WITH CHECK ADD  CONSTRAINT [FK_ProductUsage_MasterProduct] FOREIGN KEY([ProductId])
REFERENCES [dbo].[MasterProduct] ([ProductID])
GO
ALTER TABLE [dbo].[ProductUsage] CHECK CONSTRAINT [FK_ProductUsage_MasterProduct]
GO
ALTER TABLE [dbo].[ProductUsage]  WITH CHECK ADD  CONSTRAINT [FK_ProductUsage_Test] FOREIGN KEY([TestId])
REFERENCES [dbo].[Test] ([TestID])
GO
ALTER TABLE [dbo].[ProductUsage] CHECK CONSTRAINT [FK_ProductUsage_Test]
GO
ALTER TABLE [dbo].[ProtocolPanel]  WITH CHECK ADD  CONSTRAINT [FK_ProtocolPanel_Protocol] FOREIGN KEY([ProtocolId])
REFERENCES [dbo].[Protocol] ([Id])
GO
ALTER TABLE [dbo].[ProtocolPanel] CHECK CONSTRAINT [FK_ProtocolPanel_Protocol]
GO
ALTER TABLE [dbo].[PSymptomDirectedTest]  WITH CHECK ADD  CONSTRAINT [FK_Symptom-DirectedTest_Protocol] FOREIGN KEY([ProtocolId])
REFERENCES [dbo].[Protocol] ([Id])
GO
ALTER TABLE [dbo].[PSymptomDirectedTest] CHECK CONSTRAINT [FK_Symptom-DirectedTest_Protocol]
GO
ALTER TABLE [dbo].[PSymptomDirectedTest]  WITH CHECK ADD  CONSTRAINT [FK_Symptom-DirectedTest_Symptom-Test] FOREIGN KEY([TestId])
REFERENCES [dbo].[Test] ([TestID])
GO
ALTER TABLE [dbo].[PSymptomDirectedTest] CHECK CONSTRAINT [FK_Symptom-DirectedTest_Symptom-Test]
GO
ALTER TABLE [dbo].[QuantificationMetric]  WITH NOCHECK ADD  CONSTRAINT [FK_QuantificationMetric_MasterProduct] FOREIGN KEY([ProductId])
REFERENCES [dbo].[MasterProduct] ([ProductID])
GO
ALTER TABLE [dbo].[QuantificationMetric] CHECK CONSTRAINT [FK_QuantificationMetric_MasterProduct]
GO
ALTER TABLE [dbo].[QuantificationMetric]  WITH CHECK ADD  CONSTRAINT [FK_QuantificationMetric_QuantifyMenu] FOREIGN KEY([QuantifyMenuId])
REFERENCES [dbo].[QuantifyMenu] ([Id])
GO
ALTER TABLE [dbo].[QuantificationMetric] CHECK CONSTRAINT [FK_QuantificationMetric_QuantifyMenu]
GO
ALTER TABLE [dbo].[QuantifyMenu]  WITH CHECK ADD  CONSTRAINT [FK_QuantifyMenu_MorbidityTest] FOREIGN KEY([MorbidityTetsId])
REFERENCES [dbo].[MorbidityTest] ([Id])
GO
ALTER TABLE [dbo].[QuantifyMenu] CHECK CONSTRAINT [FK_QuantifyMenu_MorbidityTest]
GO
ALTER TABLE [dbo].[RapidTestSpec]  WITH CHECK ADD  CONSTRAINT [FK_RapidTestSpec_MasterProduct] FOREIGN KEY([ProductId])
REFERENCES [dbo].[MasterProduct] ([ProductID])
GO
ALTER TABLE [dbo].[RapidTestSpec] CHECK CONSTRAINT [FK_RapidTestSpec_MasterProduct]
GO
ALTER TABLE [dbo].[Site]  WITH CHECK ADD  CONSTRAINT [FK_Site_Region] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Region] ([RegionID])
GO
ALTER TABLE [dbo].[Site] CHECK CONSTRAINT [FK_Site_Region]
GO
ALTER TABLE [dbo].[Site]  WITH CHECK ADD  CONSTRAINT [FK_Site_SiteCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[SiteCategory] ([CategoryID])
GO
ALTER TABLE [dbo].[Site] CHECK CONSTRAINT [FK_Site_SiteCategory]
GO
ALTER TABLE [dbo].[SiteInstrument]  WITH CHECK ADD  CONSTRAINT [FK_SiteInstrument_Instrument] FOREIGN KEY([InstrumentID])
REFERENCES [dbo].[Instrument] ([InstrumentID])
GO
ALTER TABLE [dbo].[SiteInstrument] CHECK CONSTRAINT [FK_SiteInstrument_Instrument]
GO
ALTER TABLE [dbo].[SiteInstrument]  WITH CHECK ADD  CONSTRAINT [FK_SiteInstrument_Site] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Site] ([SiteID])
GO
ALTER TABLE [dbo].[SiteInstrument] CHECK CONSTRAINT [FK_SiteInstrument_Site]
GO
ALTER TABLE [dbo].[SiteStatus]  WITH CHECK ADD  CONSTRAINT [FK_SiteStatus_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteID])
GO
ALTER TABLE [dbo].[SiteStatus] CHECK CONSTRAINT [FK_SiteStatus_Site]
GO
ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK_Test_TestingGroup] FOREIGN KEY([TestingGroupID])
REFERENCES [dbo].[TestingGroup] ([GroupID])
GO
ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK_Test_TestingGroup]
GO
ALTER TABLE [dbo].[TestingAreaProtocol]  WITH CHECK ADD  CONSTRAINT [FK_TestingAreaProtocol_TestingArea] FOREIGN KEY([TestingAreaId])
REFERENCES [dbo].[TestingArea] ([TestingAreaID])
GO
ALTER TABLE [dbo].[TestingAreaProtocol] CHECK CONSTRAINT [FK_TestingAreaProtocol_TestingArea]
GO
ALTER TABLE [dbo].[TestingGroup]  WITH CHECK ADD  CONSTRAINT [FK_TestingGroup_TestingArea] FOREIGN KEY([TestingAreaID])
REFERENCES [dbo].[TestingArea] ([TestingAreaID])
GO
ALTER TABLE [dbo].[TestingGroup] CHECK CONSTRAINT [FK_TestingGroup_TestingArea]
GO


/****** Object:  StoredProcedure [dbo].[spServiceXmlExport]    Script Date: 01/10/2014 06:50:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spServiceXmlExport]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@protypeid int =0
as
begin
SELECT     
ForecastedResult.ProductType ,
MasterProduct.ProductName as ProductName,
sum(dbo.ForecastedResult.TotalValue) as NoofProduct,  
SUM(dbo.ForecastedResult.PackQty) as PackQty,
SUM(dbo.ForecastedResult.PackPrice) as Price,
dbo.ForecastedResult.Duration,
dbo.ForecastedResult.DurationDateTime,
MasterProduct.BasicUnit,MasterProduct.ProductID
FROM          dbo.ForecastedResult  
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
       INNER JOIN MasterProduct on MasterProduct.ProductID=dbo.ForecastedResult.ProductId 
                      where 
                      ForecastedResult.ServiceConverted=1 and
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @protypeid=0 then 1 when @protypeid= MasterProduct.ProductTypeId then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by    MasterProduct.ProductName,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime,dbo.ForecastedResult.ProductType,MasterProduct.BasicUnit,MasterProduct.ProductID
						  order by dbo.ForecastedResult.DurationDateTime asc		
end

GO


/****** Object:  StoredProcedure [dbo].[spConsumptionXmlExport]    Script Date: 01/10/2014 06:50:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spConsumptionXmlExport]
@forecastid int =0,
@siteid int=0,
@catid int=0,
@protypeid int=0
as
begin
SELECT     
ForecastedResult.ProductType ,
MasterProduct.ProductName as ProductName,
sum(dbo.ForecastedResult.TotalValue) as NoofProduct,  
SUM(dbo.ForecastedResult.PackQty) as PackQty,
SUM(dbo.ForecastedResult.PackPrice) as Price,
dbo.ForecastedResult.Duration,
dbo.ForecastedResult.DurationDateTime,
MasterProduct.BasicUnit,MasterProduct.ProductID
FROM                 dbo.ForecastedResult 
                      INNER JOIN
       dbo.ForecastInfo ON dbo.ForecastedResult.ForecastId = dbo.ForecastInfo.ForecastID
       INNER JOIN MasterProduct on MasterProduct.ProductID=dbo.ForecastedResult.ProductId 
                      where 
                      1= case when @forecastid=0 then 1 when @forecastid=ForecastedResult.ForecastId then 1 end 
                      and
                      1=case when @siteid=0 then 1 when @siteid=ForecastedResult.SiteId then 1 end
                      and
                      1=case when @catid=0 then 1 when @catid=ForecastedResult.CategoryId then 1 end
                       and
                       1=case when @protypeid=0 then 1 when @protypeid=dbo.ForecastedResult.ProductTypeId  then 1 end
                       and
		 dbo.ForecastedResult.DurationDateTime>=dbo.ForecastInfo.StartDate
		  and
		 dbo.ForecastedResult.DurationDateTime< 
		 dbo.fnGetMaxForecastDate(ForecastInfo.Period,ForecastInfo.StartDate,ForecastInfo.Extension)
		 
                      group by    MasterProduct.ProductName,dbo.ForecastedResult.Duration,dbo.ForecastedResult.DurationDateTime,ForecastedResult.ProductType,MasterProduct.BasicUnit,MasterProduct.ProductID
						  order by dbo.ForecastedResult.DurationDateTime asc		
end
GO