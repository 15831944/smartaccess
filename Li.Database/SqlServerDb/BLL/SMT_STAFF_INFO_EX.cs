﻿/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/1 23:35:04   N/A    初版
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
	/// 员工职员表
	/// </summary>
	public partial class SMT_STAFF_INFO
	{
        public List<Maticsoft.Model.SMT_STAFF_INFO> GetModelListByParOrgId(decimal orgId)
        {
            var ds = dal.GetListByDept(orgId);
            return DataTableToListByParOrgId(ds.Tables[0]);
        }
        public Maticsoft.Model.SMT_STAFF_INFO GetModelWithDept(decimal id)
        {
            var ds = dal.GetListByPageWithDept("SI.ID=" + id, "", 1, 1);
           var models = DataTableToListWithDept(ds.Tables[0]);
           if (models.Count>0)
           {
               return models[0];
           }
           return null;
        }
        public List<Maticsoft.Model.SMT_STAFF_INFO> DataTableToListByParOrgId(DataTable dt)
        {
            List<Maticsoft.Model.SMT_STAFF_INFO> modelList = new List<Maticsoft.Model.SMT_STAFF_INFO>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SMT_STAFF_INFO model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelByParOrgId(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCountByDept(decimal orgId)
        {
            return dal.GetRecordCountByDept(orgId);
        }
        public int GetRecordCountWithDept(string strWhere)
        {
            return dal.GetRecordCountWithDept(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPageByDept(decimal orgId, int startIndex, int endIndex)
        {
            return dal.GetListByPageByDept(orgId, startIndex, endIndex);
        }
        public DataSet GetListByPageWithDept(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPageWithDept(strWhere, orderby, startIndex, endIndex);
        }
        public DataSet GetListByCardNum(string cardNo)
        {
            return dal.GetListByCardNum(cardNo);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_STAFF_INFO> DataTableToListWithDept(DataTable dt)
        {
            List<Maticsoft.Model.SMT_STAFF_INFO> modelList = new List<Maticsoft.Model.SMT_STAFF_INFO>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SMT_STAFF_INFO model;
                string ids = "";
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        if (dt.Rows[n]["ORG_NAME"] != null)
                        {
                            model.ORG_NAME = dt.Rows[n]["ORG_NAME"].ToString();
                        }
                        if (dt.Rows[n]["ORG_CODE"] != null)
                        {
                            model.ORG_CODE = dt.Rows[n]["ORG_CODE"].ToString();
                        }
                        modelList.Add(model);
                        ids += model.ID + ",";
                    }
                }
                ids = ids.TrimEnd(',');
                Maticsoft.BLL.SMT_CARD_INFO cbll = new Maticsoft.BLL.SMT_CARD_INFO();//读取权限

                var clist = cbll.GetModelListByStaffIds(ids);

                foreach (var item in modelList)
                {
                    item.CARDS = clist.FindAll(m => m.STAFF_ID == item.ID);
                }
            }
            return modelList;
        }

        public List<Maticsoft.Model.SMT_STAFF_INFO> GetSimpleModelList(string strWhere)
        {
            DataSet ds = dal.GetSimpleList(strWhere);
            return DataTableToSimpleList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_STAFF_INFO> DataTableToSimpleList(DataTable dt)
        {
            List<Maticsoft.Model.SMT_STAFF_INFO> modelList = new List<Maticsoft.Model.SMT_STAFF_INFO>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SMT_STAFF_INFO model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToSimpleModel(dt.Rows[n]);
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

