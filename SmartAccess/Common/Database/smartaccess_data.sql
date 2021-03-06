USE [SmartAccess]
GO
/**插入默认用户admin，默认密码123456**/
IF NOT EXISTS (SELECT * from [dbo].[SMT_USER_INFO] where USER_NAME = 'admin' )
INSERT INTO [dbo].[SMT_USER_INFO] (USER_NAME,PASS_WORD,REAL_NAME,IS_ENABLE,IS_DELETE,ORDER_VALUE) values('admin',substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','123456')),3,32),'admin',1,0,100)
GO
/*插入报警服务配置*/
IF NOT EXISTS (SELECT * from [dbo].[SMT_DATADICTIONARY_INFO] where [DATA_TYPE] = N'ALARM_INFO' and  [DATA_KEY]=N'ALARM_SERVER')
INSERT [dbo].[SMT_DATADICTIONARY_INFO] ([DATA_TYPE], [DATA_KEY], [DATA_VALUE], [DATA_NAME], [DATA_CONTENT]) VALUES (N'ALARM_INFO', N'ALARM_SERVER', N'127.0.0.1:56010', N'报警转发配置参数', N'报警服务IP和端口，格式:192.168.1.1:56010')
GO
IF NOT EXISTS (SELECT * from [dbo].[SMT_DATADICTIONARY_INFO] where [DATA_TYPE] = N'STAFF_TYPE' and  [DATA_KEY]=N'STAFF')
INSERT [dbo].[SMT_DATADICTIONARY_INFO] ([DATA_TYPE], [DATA_KEY], [DATA_VALUE], [DATA_NAME], [DATA_CONTENT]) VALUES (N'STAFF_TYPE', N'STAFF', N'STAFF', N'内部员工', N'内部员工')
IF NOT EXISTS (SELECT * from [dbo].[SMT_DATADICTIONARY_INFO] where [DATA_TYPE] = N'STAFF_TYPE' and  [DATA_KEY]=N'VISITOR')
INSERT [dbo].[SMT_DATADICTIONARY_INFO] ([DATA_TYPE], [DATA_KEY], [DATA_VALUE], [DATA_NAME], [DATA_CONTENT]) VALUES (N'STAFF_TYPE', N'VISITOR', N'VISITOR', N'访客', N'访客')
IF NOT EXISTS (SELECT * from [dbo].[SMT_DATADICTIONARY_INFO] where [DATA_TYPE] = N'SYSTEM_CONFIG' and  [DATA_KEY]=N'AUTO_ACCESS')
INSERT [dbo].[SMT_DATADICTIONARY_INFO] ([DATA_TYPE], [DATA_KEY], [DATA_VALUE], [DATA_NAME], [DATA_CONTENT]) VALUES (N'SYSTEM_CONFIG', N'AUTO_ACCESS', N'True', N'自动授权开启状态', N'自动授权开启状态：True开启，False关闭')
/**********插入功能点数据**************/
GO
/****** Object:  Table [dbo].[SMT_FUN_MENUPOINT]    Script Date: 11/01/2016 01:15:19 插入权限数据******/
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 1 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(1 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'VER_INFO_MGR', N'证件信息管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 3 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(3 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'SEARCH_INFO_MGR', N'信息系统查询', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 4 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(4 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'REPORT_INFO_MGR', N'报表统计管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 5 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(5 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'CTRLR_INFO_MGR', N'控制设备管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 6 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(6 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'REAL_DETECT_MGR', N'实时监控管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 7 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(7 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'RULE_INFO_MGR', N'规则设定管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 8 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(8 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'SYS_CONFIG_MGR', N'系统配置管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 101 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(101 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), N'VER_CODE', N'证件编码', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 102 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(102 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), N'DEPT_MGR', N'部门管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 103 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(103 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), N'STAFF_MGR', N'人员管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 104 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(104 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), N'VER_MODEL', N'证件模板', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 105 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(105 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), N'FACERECG_DEV_PRIVATE', N'人脸识别授权', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 301 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(301 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'ACCESS_RECORD', N'门禁出入查询', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 302 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(302 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'STAFF_ROUTE', N'人员轨迹查询', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 303 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(303 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'LOG_INFO', N'操作日志查询', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 304 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(304 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'ALARM_INFO', N'报警信息查询', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 305 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(305 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'ATTENDANCE_INFO', N'考勤信息查询', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 306 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(306 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'IMS_PEOPLE_RECORD', N'查验记录查询', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 307 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(307 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'IMS_VEHICLE_RECORD', N'过车记录查询', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 308 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(308 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'FACERECG_RECORD', N'人脸识别查询', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 309 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(309 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'AUTOACCESS_RECORD', N'自动授权记录查询', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 310 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(310 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'AUTOACCESS_EDIT', N'自动授权编辑', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 401 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(401 AS Decimal(18, 0)), CAST(4 AS Decimal(18, 0)), N'ACCESS_RECORD_STA', N'门禁出入统计', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 501 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(501 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), N'CTRLR_INFO', N'控制器管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 502 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(502 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), N'ELEVATOR_DOOR_MGR', N'梯门管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 503 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(503 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), N'FACERECG_DEV_INFO', N'人脸识别设备', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 601 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(601 AS Decimal(18, 0)), CAST(6 AS Decimal(18, 0)), N'REAL_MAP', N'实时地图显示', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 602 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(602 AS Decimal(18, 0)), CAST(6 AS Decimal(18, 0)), N'REAL_ACCESS_STATE', N'实时状态显示', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 603 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(603 AS Decimal(18, 0)), CAST(6 AS Decimal(18, 0)), N'REAL_ALARM_DETECT', N'报警实时监控', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 701 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(701 AS Decimal(18, 0)), CAST(7 AS Decimal(18, 0)), N'CTRLR_TASK', N'控制定时任务', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 801 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(801 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'MAP_CONFIG', N'地图编辑配置', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 802 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(802 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'CARD_CONFIG', N'发卡编辑配置', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 803 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(803 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'ACCESS_PASSWORD_CONFIG', N'门禁密码管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 804 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(804 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'INOUT_TIME_CONFIG', N'出入时段管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 805 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(805 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'DATABASE_BACK_CONFIG', N'数据备份管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 806 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(806 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'MODIFY_PWD_CONFIG', N'修改用户密码', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 807 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(807 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'SYS_README_CONFIG', N'系统使用说明', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 808 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(808 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'USER_PRIVATE_CONFIG', N'用户权限管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 809 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(809 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'ALARM_CONNECT_SETTING', N'报警联动设定', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 810 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(810 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'ATTENDANCE_SETTING', N'考勤上班设置', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 811 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(811 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'DOOR_CAMERA_SETTING', N'门禁相机设置', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 812 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(812 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'FACE_BLACK_LIST', N'人脸黑名单管理', 1)
IF NOT EXISTS (SELECT * from [dbo].[SMT_FUN_MENUPOINT] where [ID] = 813 )
INSERT [dbo].[SMT_FUN_MENUPOINT] ([ID], [PAR_ID], [FUN_CODE], [FUN_NAME], [IS_MENU]) VALUES (CAST(813 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), N'DATA_DIC_CONFIG', N'数据类型配置', 1)
GO
/****** Object:  Table [dbo].[SMT_DATADICTIONARY_INFO]    Script Date: 01/04/2017 22:50:45 ******/
IF NOT EXISTS (SELECT * from [dbo].[SMT_DATADICTIONARY_INFO] where [DATA_TYPE] = N'ALARM_INFO' AND [DATA_KEY] = N'ALARM_SERVER')
INSERT [dbo].[SMT_DATADICTIONARY_INFO] ([DATA_TYPE], [DATA_KEY], [DATA_VALUE], [DATA_NAME], [DATA_CONTENT]) VALUES (N'ALARM_INFO', N'ALARM_SERVER', N'127.0.0.1:56010', N'报警转发配置参数', N'报警服务IP和端口，格式:192.168.1.1:56010')
/**IMS **/
GO
SET IDENTITY_INSERT [dbo].[IMS_DATA_CONFIG] ON
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 1 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(1 AS Decimal(18, 0)), N'IMS_CONFIG', N'FaceMode', N'0', N'人脸模式')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 2 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(2 AS Decimal(18, 0)), N'IMS_CONFIG', N'IsBlackMode', N'1', N'黑名单模式')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 3 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(3 AS Decimal(18, 0)), N'IMS_CONFIG', N'SwipeMode', N'0', N'刷卡模式')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 4 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(4 AS Decimal(18, 0)), N'FACE_1_N', N'Threshold', N'50', N'人脸1：N阈值')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 5 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(5 AS Decimal(18, 0)), N'FACE_1_1', N'Threshold', N'50', N'人脸1：1阈值')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 6 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(6 AS Decimal(18, 0)), N'FACE_1_LN', N'Threshold', N'50', N'人脸1：n阈值')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 7 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(7 AS Decimal(18, 0)), N'STAFF_FACE', N'FilePath', N'c:\LocalFace\StaffFace\', N'员工人脸本地库路径')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 8 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(8 AS Decimal(18, 0)), N'BLACK_FACE', N'FilePath', N'c:\LocalFace\BlackFace\', N'黑名单人脸本地库路径')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 9 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(9 AS Decimal(18, 0)), N'TEMP_FACE', N'FilePath', N'c:\LocalFace\TempFace\', N'1：n临时人脸本地库')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 10 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(10 AS Decimal(18, 0)), N'IMS_CONFIG', N'FaceCamera', N'1', N'人脸相机编号')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 11 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(11 AS Decimal(18, 0)), N'IMS_CONFIG', N'Controller', N'1', N'人脸联动控制器编号')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 12 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(12 AS Decimal(18, 0)), N'IMS_CONFIG', N'Door', N'1', N'人脸联动门编号')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 13 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(13 AS Decimal(18, 0)), N'FACE_BLACK', N'Threshold', N'60', N'黑名单阈值')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 14 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(14 AS Decimal(18, 0)), N'FACE_1_LN', N'STORELENGTH', N'15', N'特征库大小')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 15 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(15 AS Decimal(18, 0)), N'FACE_1_LN', N'DELETETICK', N'20', N'删除特征间隔')
SET IDENTITY_INSERT [dbo].[IMS_DATA_CONFIG] OFF

GO
SET IDENTITY_INSERT [dbo].[IMS_PEOPLE_RECORD] ON
IF NOT EXISTS (SELECT * from [dbo].[IMS_PEOPLE_RECORD] where [ID] = 999 )
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(999 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA009FB7E4 AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
IF NOT EXISTS (SELECT * from [dbo].[IMS_PEOPLE_RECORD] where [ID] = 1000 )
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1000 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A1025C AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
IF NOT EXISTS (SELECT * from [dbo].[IMS_PEOPLE_RECORD] where [ID] = 1001 )
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1001 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A12C8C AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
IF NOT EXISTS (SELECT * from [dbo].[IMS_PEOPLE_RECORD] where [ID] = 1002 )
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1002 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A1BB84 AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
IF NOT EXISTS (SELECT * from [dbo].[IMS_PEOPLE_RECORD] where [ID] = 1003 )
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1003 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A3686C AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
IF NOT EXISTS (SELECT * from [dbo].[IMS_PEOPLE_RECORD] where [ID] = 1004 )
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1004 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A36E48 AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
IF NOT EXISTS (SELECT * from [dbo].[IMS_PEOPLE_RECORD] where [ID] = 1005 )
INSERT [dbo].[IMS_PEOPLE_RECORD] ([ID], [CardType], [CardNo], [Name], [Depart], [AccessChannel], [ThroughForward], [ThroughTime], [ThroughResult], [CapturePic], [OriginPic], [CompareResult], [Similarity], [FacePosition]) VALUES (CAST(1005 AS Decimal(18, 0)), 0, N'8E591A5B', N'唐飞', N'-1', N'1', 0, CAST(0x0000A6BA00A39170 AS DateTime), 1, N'C:\查验系统\Code\IMS\IMS\IMS\bin\Debug\Faces\20161106194611546.jpg', N'c:\LocalFace\StaffFace\1.jpg', 1, CAST(64 AS Numeric(18, 0)), N'')
SET IDENTITY_INSERT [dbo].[IMS_PEOPLE_RECORD] OFF

GO
SET IDENTITY_INSERT [dbo].[IMS_DATA_CONFIG] ON
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 1 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(1 AS Decimal(18, 0)), N'IMS_CONFIG', N'FaceMode', N'0', N'人脸模式')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 2 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(2 AS Decimal(18, 0)), N'IMS_CONFIG', N'IsBlackMode', N'1', N'黑名单模式')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 3 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(3 AS Decimal(18, 0)), N'IMS_CONFIG', N'SwipeMode', N'0', N'刷卡模式')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 4 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(4 AS Decimal(18, 0)), N'FACE_1_N', N'Threshold', N'50', N'人脸1：N阈值')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 5 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(5 AS Decimal(18, 0)), N'FACE_1_1', N'Threshold', N'50', N'人脸1：1阈值')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 6 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(6 AS Decimal(18, 0)), N'FACE_1_LN', N'Threshold', N'50', N'人脸1：n阈值')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 7 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(7 AS Decimal(18, 0)), N'STAFF_FACE', N'FilePath', N'c:\LocalFace\StaffFace\', N'员工人脸本地库路径')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 8 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(8 AS Decimal(18, 0)), N'BLACK_FACE', N'FilePath', N'c:\LocalFace\BlackFace\', N'黑名单人脸本地库路径')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 9 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(9 AS Decimal(18, 0)), N'TEMP_FACE', N'FilePath', N'c:\LocalFace\TempFace\', N'1：n临时人脸本地库')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 10 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(10 AS Decimal(18, 0)), N'IMS_CONFIG', N'FaceCamera', N'1', N'人脸相机编号')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 11 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(11 AS Decimal(18, 0)), N'IMS_CONFIG', N'Controller', N'1', N'人脸联动控制器编号')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 12 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(12 AS Decimal(18, 0)), N'IMS_CONFIG', N'Door', N'1', N'人脸联动门编号')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 13 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(13 AS Decimal(18, 0)), N'FACE_BLACK', N'Threshold', N'60', N'黑名单阈值')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 14 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(14 AS Decimal(18, 0)), N'FACE_1_LN', N'STORELENGTH', N'15', N'特征库大小')
IF NOT EXISTS (SELECT * from [dbo].[IMS_DATA_CONFIG] where [ID] = 15 )
INSERT [dbo].[IMS_DATA_CONFIG] ([ID], [DataType], [DataKey], [DataValue], [DataDesc]) VALUES (CAST(15 AS Decimal(18, 0)), N'FACE_1_LN', N'DELETETICK', N'20', N'删除特征间隔')
SET IDENTITY_INSERT [dbo].[IMS_DATA_CONFIG] OFF
GO
SET IDENTITY_INSERT [dbo].[IMS_FACE_CAMERA] ON
IF NOT EXISTS (SELECT * from [dbo].[IMS_FACE_CAMERA] where [ID] = 1 )
INSERT [dbo].[IMS_FACE_CAMERA] ([ID], [CameraName], [CameraIP], [CameraPort], [CameraUser], [CameraPwd]) VALUES (CAST(1 AS Decimal(18, 0)), N'测试相机', N'192.168.0.64', N'8000', N'admin', N'admin123')
SET IDENTITY_INSERT [dbo].[IMS_FACE_CAMERA] OFF

