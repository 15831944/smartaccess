﻿using Li.SmartAcsServer.RecordsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Li.SmartAcsServer
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class AcsService : IAcsService
    {
        /// <summary>
        /// 程序开启时，启动所有服务
        /// </summary>
        public static void StartAllServices()
        {
            Maticsoft.DBUtility.DbHelperSQL.connectionString = SunCreate.Common.ConfigHelper.GetConfigString("SqlServerConnectString");
            //启动记录读取服务
            RecordTaskService.Instance.Start();
        }
        /// <summary>
        /// 程序退出时退出所有服务
        /// </summary>
        public static void StopAllServices()
        {
            RecordTaskService.Instance.Stop();
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}