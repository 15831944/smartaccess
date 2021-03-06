﻿/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_FACEDEV.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_FACEDEV
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/2 15:10:17   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 员工人脸识别设备权限
	/// </summary>
	public partial class SMT_STAFF_FACEDEV
	{
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_STAFF_FACEDEV> GetModelListEx(string strWhere,string staffdept ,int startIndex,int endIndex)
        {
            DataSet ds = dal.GetListEx(strWhere, staffdept, startIndex, endIndex);
            return DataTableToListEx(ds.Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCountEx(string strWhere,string staffdept)
        {
            return dal.GetRecordCountEx(strWhere, staffdept);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_STAFF_FACEDEV> DataTableToListEx(DataTable dt)
        {
            List<Maticsoft.Model.SMT_STAFF_FACEDEV> modelList = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SMT_STAFF_FACEDEV model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelEx(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
	}
}

