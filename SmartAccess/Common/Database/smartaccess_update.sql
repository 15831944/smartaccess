USE [SmartAccess]
/**升级数据库脚本**/
/****** Object:  Table [dbo].[SMT_FUN_MENUPOINT]    Script Date: 11/01/2016 23:00:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SMT_FUN_MENUPOINT]') AND type in (N'U'))
DROP TABLE [dbo].[SMT_FUN_MENUPOINT]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMT_FUN_MENUPOINT](
	[ID] [decimal](18, 0) NOT NULL,
	[PAR_ID] [decimal](18, 0) NOT NULL,
	[FUN_CODE] [varchar](100) NOT NULL,
	[FUN_NAME] [nvarchar](200) NOT NULL,
	[IS_MENU] [bit] NULL,
 CONSTRAINT [PK_SMT_FUN_MENUPOINT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上一级功能ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT', @level2type=N'COLUMN',@level2name=N'PAR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT', @level2type=N'COLUMN',@level2name=N'FUN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT', @level2type=N'COLUMN',@level2name=N'FUN_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT', @level2type=N'COLUMN',@level2name=N'IS_MENU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能菜单/功能点表[SMT_FUN_MENUPOINT]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMT_FUN_MENUPOINT'