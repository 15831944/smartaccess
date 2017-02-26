USE [SmartAccess]
--/**升级数据库脚本**/
GO
/****** Object:  Table [dbo].[IMS_VEHICLE_RECORD]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_VEHICLE_RECORD]') AND type in (N'U'))
CREATE TABLE [dbo].[IMS_VEHICLE_RECORD](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[PlateNo] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Depart] [varchar](50) NULL,
	[AccessChannel] [varchar](50) NULL,
	[ThroughForward] [tinyint] NULL,
	[ThroughTime] [datetime] NULL,
	[ThroughResult] [tinyint] NULL,
	[CapturePic] [varchar](500) NULL,
 CONSTRAINT [PK_IMS_VEHICLE_RECORD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMS_VEHICLE_INFO]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_VEHICLE_INFO]') AND type in (N'U'))
CREATE TABLE [dbo].[IMS_VEHICLE_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[PlateNo] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Depart] [varchar](50) NULL,
	[IsGrant] [tinyint] NULL,
	[GrantAccess] [varchar](100) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_IMS_VEHICLE_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMS_PEOPLE_RECORD]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_PEOPLE_RECORD]') AND type in (N'U'))
CREATE TABLE [dbo].[IMS_PEOPLE_RECORD](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CardType] [tinyint] NULL,
	[CardNo] [varchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Depart] [nvarchar](100) NULL,
	[AccessChannel] [nvarchar](100) NULL,
	[ThroughForward] [tinyint] NULL,
	[ThroughTime] [datetime] NULL,
	[ThroughResult] [tinyint] NULL,
	[CapturePic] [varchar](500) NULL,
	[OriginPic] [varchar](500) NULL,
	[CompareResult] [tinyint] NULL,
	[Similarity] [numeric](18, 0) NULL,
	[FacePosition] [nvarchar](100) NULL,
 CONSTRAINT [PK_IMS_PEOPLE_RECORD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMS_FACE_CAMERA]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_FACE_CAMERA]') AND type in (N'U'))
CREATE TABLE [dbo].[IMS_FACE_CAMERA](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CameraName] [varchar](50) NULL,
	[CameraIP] [varchar](50) NULL,
	[CameraPort] [varchar](50) NULL,
	[CameraUser] [varchar](50) NULL,
	[CameraPwd] [varchar](50) NULL,
 CONSTRAINT [PK_IMS_FACE_CAMERA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMS_FACE_BLACKLIST]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_FACE_BLACKLIST]') AND type in (N'U'))
CREATE TABLE [dbo].[IMS_FACE_BLACKLIST](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Sex] [tinyint] NULL,
	[FacePic] [varchar](500) NULL,
	[Description] [varbinary](500) NULL,
 CONSTRAINT [PK_IMS_FACE_BLACKLIST] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IMS_DATA_CONFIG]    Script Date: 11/10/2016 10:40:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMS_DATA_CONFIG]') AND type in (N'U'))
CREATE TABLE [dbo].[IMS_DATA_CONFIG](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[DataType] [varchar](50) NULL,
	[DataKey] [varchar](50) NULL,
	[DataValue] [varchar](500) NULL,
	[DataDesc] [varchar](500) NULL,
 CONSTRAINT [PK_IMS_DATA_CONFIG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF

GO
/****** Object:  Table [dbo].[SMT_DEPT_USER]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_DEPT_USER]') AND type in (N'U'))
CREATE TABLE [dbo].[SMT_DEPT_USER](
	[DEPT_ID] [decimal](18, 0) NOT NULL,
	[USER_ID] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_SMT_DEPT_USER] PRIMARY KEY CLUSTERED 
(
	[DEPT_ID] ASC,
	[USER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DEPT_USER', @level2type=N'COLUMN',@level2name=N'DEPT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DEPT_USER', @level2type=N'COLUMN',@level2name=N'USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门用户权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DEPT_USER'
/****** Object:  Table [dbo].[SMT_SUPER_PWD]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_SUPER_PWD]') AND type in (N'U'))
CREATE TABLE [dbo].[SMT_SUPER_PWD](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[SUPER_PWD] [nvarchar](10) NOT NULL,
	[DOOR_ID] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_SUPER_PWD', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'超级密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_SUPER_PWD', @level2type=N'COLUMN',@level2name=N'SUPER_PWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门禁ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_SUPER_PWD', @level2type=N'COLUMN',@level2name=N'DOOR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'超级通信密码表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_SUPER_PWD'
GO

/****** Object:  Table [dbo].[SMT_DATADICTIONARY_INFO]    Script Date: 01/04/2017 22:44:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_DATADICTIONARY_INFO]') AND type in (N'U'))
CREATE TABLE [dbo].[SMT_DATADICTIONARY_INFO](
	[DATA_TYPE] [varchar](20) NOT NULL,
	[DATA_KEY] [varchar](40) NOT NULL,
	[DATA_VALUE] [nvarchar](500) NOT NULL,
	[DATA_NAME] [nvarchar](80) NULL,
	[DATA_CONTENT] [nvarchar](500) NULL,
 CONSTRAINT [PK_SMT_DATADICTIONARY_INFO] PRIMARY KEY CLUSTERED 
(
	[DATA_TYPE] ASC,
	[DATA_KEY] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO', @level2type=N'COLUMN',@level2name=N'DATA_TYPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO', @level2type=N'COLUMN',@level2name=N'DATA_KEY'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO', @level2type=N'COLUMN',@level2name=N'DATA_VALUE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO', @level2type=N'COLUMN',@level2name=N'DATA_NAME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO', @level2type=N'COLUMN',@level2name=N'DATA_CONTENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据字典管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_DATADICTIONARY_INFO'
GO
/****** Object:  Table [dbo].[SMT_ALARM_SETTING]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_ALARM_SETTING](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CTRL_ID] [decimal](18, 0) NOT NULL,
	[CTRL_FORCE_PWD] [varchar](10) NULL,
	[ENABLE_FORCE_PWD] [bit] NOT NULL,
	[NOT_CLOSED_TIMEOUT] [tinyint] NULL,
	[ENABLE_CLOSED_TIMEOUT] [bit] NOT NULL,
	[ENABLE_FORCE_ACCESS] [bit] NOT NULL,
	[ENABLE_FORCE_CLOSE] [bit] NOT NULL,
	[ENABLE_INVALID_CARD] [bit] NOT NULL,
	[ENABLE_FIRE] [bit] NOT NULL,
	[ENABLE_STEAL] [bit] NOT NULL,
	[ENABLE_FORCE_CARD] [bit] NOT NULL,
 CONSTRAINT [PK_SMT_ALARM_SETTING] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器ID号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'CTRL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'胁迫密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'CTRL_FORCE_PWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用胁迫密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_FORCE_PWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门长时间未关超时时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'NOT_CLOSED_TIMEOUT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用门长时间未关报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_CLOSED_TIMEOUT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用强行闯入报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_FORCE_ACCESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用强制关门报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_FORCE_CLOSE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用无效刷卡报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_INVALID_CARD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用火警报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_FIRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用防盗报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_STEAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用胁迫必须刷合法卡' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING', @level2type=N'COLUMN',@level2name=N'ENABLE_FORCE_CARD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警信息配置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_SETTING'
GO
/****** Object:  Table [dbo].[SMT_ALARM_INFO]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_ALARM_INFO](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[ALARM_TYPE] [tinyint] NOT NULL,
	[ALARM_NAME] [nvarchar](50) NULL,
	[ALARM_CONTENT] [nvarchar](200) NULL,
	[ALARM_TIME] [datetime] NOT NULL,
	[RECORD_ID] [decimal](18, 0) NULL,
	[CARD_NO] [varchar](100) NULL,
	[CTRLR_DOOR_INDEX] [tinyint] NULL,
	[CTRLR_ID] [decimal](18, 0) NULL,
	[DOOR_ID] [decimal](18, 0) NULL,
	[STAFF_ID] [decimal](18, 0) NULL,
 CONSTRAINT [PK_SMT_ALARM_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'ALARM_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'ALARM_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'ALARM_CONTENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'ALARM_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'RECORD_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录的卡号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'CARD_NO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'于控制器的上门序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'CTRLR_DOOR_INDEX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的控制器ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'CTRLR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'DOOR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联的职员ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO', @level2type=N'COLUMN',@level2name=N'STAFF_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_INFO'
GO
/****** Object:  Table [dbo].[SMT_ALARM_CONNECT]    Script Date: 01/04/2017 22:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_ALARM_CONNECT](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[CTRL_ID] [decimal](18, 0) NOT NULL,
	[OUT_PORT] [tinyint] NOT NULL,
	[DOOR_ID] [tinyint] NOT NULL,
	[ENB_FORCE_PWD_EVENT] [bit] NOT NULL,
	[ENB_UNCLOSED_EVENT] [bit] NOT NULL,
	[ENB_FORCE_ACCESS_EVENT] [bit] NOT NULL,
	[ENB_FORCE_CLOSE_EVENT] [bit] NOT NULL,
	[ENB_INVALID_CARD_EVENT] [bit] NOT NULL,
	[ENB_FIRE_EVENT] [bit] NOT NULL,
	[ENB_RELAY_EVENT] [bit] NOT NULL,
	[ENB_CONNECT_ITEM] [tinyint] NOT NULL,
	[ENB_FIXED_TIME] [tinyint] NOT NULL,
 CONSTRAINT [PK_SMT_ALARM_CONNECT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'CTRL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'输出端口' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'OUT_PORT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'触发源（门禁ID）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'DOOR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发胁迫报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_FORCE_PWD_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发门长时间未关报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_UNCLOSED_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发强行闯入' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_FORCE_ACCESS_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发强制锁门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_FORCE_CLOSE_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发无效刷卡' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_INVALID_CARD_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发火警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_FIRE_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否触发门继电器动作' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_RELAY_EVENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联动选项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_CONNECT_ITEM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定延时时长(秒)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT', @level2type=N'COLUMN',@level2name=N'ENB_FIXED_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警联动输出配置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ALARM_CONNECT'

GO
/****** Object:  Table [dbo].[SMT_ATTEN_SETTING]    Script Date: 02/26/2017 13:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_ATTEN_SETTING](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[DUTY_TYPE] [tinyint] NOT NULL,
	[DUTY_LATE_MIN] [int] NOT NULL,
	[DUTY_LATE_MAX] [int] NOT NULL,
	[DUTY_LATE_PUNISH] [float] NOT NULL,
	[DUTY_LEAVE_MIN] [int] NOT NULL,
	[DUTY_LEAVE_MAX] [int] NOT NULL,
	[DUTY_LEAVE_PUNISH] [float] NOT NULL,
	[DUTY_EXTRA_MIN] [int] NOT NULL,
	[DUTY_SWING_TIMES] [tinyint] NOT NULL,
	[DUTY_ON_TIME1] [time](7) NOT NULL,
	[DUTY_OFF_TIME1] [time](7) NOT NULL,
	[DUTY_ON_TIME2] [time](7) NOT NULL,
	[DUTY_OFF_TIME2] [time](7) NOT NULL,
	[DUTY_ONLY_ON] [bit] NOT NULL,
	[DUTY_ON_EARLIEST] [time](7) NOT NULL,
	[DUTY_WORK_LENGTH] [float] NOT NULL,
	[DUTY_FULL_TIME] [bit] NOT NULL,
	[DUTY_SAT_TYPE] [tinyint] NOT NULL,
	[DUTY_SUN_TYPE] [tinyint] NOT NULL,
 CONSTRAINT [PK_SMT_ATTEN_SETTING] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考勤班次类型，0,正常班' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'迟到最小范围，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LATE_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'迟到最大范围，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LATE_MAX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'迟到最大处罚天数，天' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LATE_PUNISH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'早退最小范围，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LEAVE_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'早退最大范围，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LEAVE_MAX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'早退最大处罚天数，天' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_LEAVE_PUNISH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加班范围，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_EXTRA_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'每天刷卡次数，次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_SWING_TIMES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上班时间1，time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_ON_TIME1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下班时间1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_OFF_TIME1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上班时间2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_ON_TIME2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下班时间2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_OFF_TIME2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'只统计上班刷卡，bool' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_ONLY_ON'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上班最早刷卡时间，time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_ON_EARLIEST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'每天工作时间(h)，时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_WORK_LENGTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'满足工作时间不受约束，bool' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_FULL_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'周六上班方式，0，不上班，1全天上班，2上午上班，下午休息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_SAT_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'周日上班方式，0，不上班，1 全天上班，2 上午上班，下午休息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING', @level2type=N'COLUMN',@level2name=N'DUTY_SUN_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考勤班次设置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_SETTING'
GO
/****** Object:  Table [dbo].[SMT_ATTEN_REPORT]    Script Date: 02/26/2017 13:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMT_ATTEN_REPORT](
	[ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[STAFF_ID] [decimal](18, 0) NOT NULL,
	[ATTEN_DATE] [date] NOT NULL,
	[ATTEN_ON_TIME] [time](7) NULL,
	[ATTEN_OFF_TIME] [time](7) NULL,
	[ATTEN_ON_STATE] [nvarchar](20) NULL,
	[ATTEN_OFF_STATE] [nvarchar](20) NULL,
	[ATTEN_LATE_MIN] [int] NULL,
	[ATTEN_LEAVE_MIN] [int] NULL,
	[ATTEN_EXTRA_MIN] [int] NULL,
	[ATTEN_AWAY_DAY] [float] NULL,
	[ATTEN_UNSWIPE_TIMES] [int] NULL,
	[ATTEN_SWIPE_TIMES] [int] NULL,
 CONSTRAINT [PK_SMT_ATTEN_REPORT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'STAFF_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考勤日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上班时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_ON_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下班时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_OFF_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上班描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_ON_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下班描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_OFF_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'迟到时间，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_LATE_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'早退时间，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_LEAVE_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加班时间，分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_EXTRA_MIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旷工天数，天' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_AWAY_DAY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未刷卡次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_UNSWIPE_TIMES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应刷次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT', @level2type=N'COLUMN',@level2name=N'ATTEN_SWIPE_TIMES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考勤信息报表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_ATTEN_REPORT'
GO