USE msdb
GO
EXEC dbo.sp_update_job
@job_name = N'backup_smart_access',--这里填上作业的名称
@enabled = 1;--这个值表示启用还是禁用，1为启用作业 ，0为禁用作业
GO