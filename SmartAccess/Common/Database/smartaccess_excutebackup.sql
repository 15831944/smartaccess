USE msdb
DECLARE @filename VARCHAR(500)
DECLARE @date DATETIME
DECLARE @OLD_DATE DATETIME
SET @date=GETDATE()
SET @OLD_DATE=GETDATE()
SET @FILENAME = '${PATH}\smartaccess-'+CAST(DATEPART(YYYY,@DATE) AS VARCHAR(10))+'-'+CAST(DATEPART(MM,@DATE) AS VARCHAR(10))+'-'+CAST(DATEPART(DD,@DATE) AS VARCHAR(10))+'.BAK'
EXECUTE master.dbo.xp_delete_file 0,N'${PATH}',N'bak',@OLD_DATE,1
EXEC sp_start_job @job_name = 'backup_smart_access'