USE [master]
GO
if Exists(select name from sysobjects where NAME = 'KillSpByDbName' and type='P') 
DROP PROC KillSpByDbName
GO
CREATE PROC KillSpByDbName(@DBNAME VARCHAR(20))   
AS   
BEGIN   
DECLARE @SQL NVARCHAR(500),@TEMP VARCHAR(1000)
DECLARE @SPID INT   
SET @SQL='DECLARE GETSPID CURSOR FOR   
SELECT SPID FROM SYSPROCESSES WHERE DBID=DB_ID('''+@DBNAME+''')'   
EXEC (@SQL)   
OPEN GETSPID   
FETCH NEXT FROM GETSPID INTO @SPID   
WHILE @@FETCH_STATUS<>-1   
BEGIN   
  SET @TEMP='KILL '+RTRIM(@SPID)
  EXEC(@TEMP)
FETCH NEXT FROM GETSPID INTO @SPID   
END   
CLOSE GETSPID   
DEALLOCATE GETSPID   
END
GO 
IF EXISTS(SELECT 1 FROM sysdatabases WHERE NAME=N'SmartAccess') 
BEGIN
BACKUP DATABASE SmartAccess TO DISK = N'C:\SmartAccessBak\SmartAccess${DATE}.bak' with init
Exec KillSpByDbName N'SmartAccess'
DROP DATABASE SmartAccess --如果数据库存在先删掉数据库 
END
GO
/****** Object:  Database [SmartAccess]    Script Date: 10/09/2016 23:31:35 ******/
CREATE DATABASE [SmartAccess] ON  PRIMARY 
( NAME = N'SmartAccess', FILENAME = N'${DBPATH}\SmartAccess.mdf' , SIZE = 10240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SmartAccess_log', FILENAME = N'${DBPATH}\SmartAccess_log.ldf' , SIZE = 12352KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)