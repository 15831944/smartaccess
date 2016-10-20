﻿using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAccess
{
    /// <summary>
    /// 权限管理
    /// </summary>
    public class PrivateMgr
    {
        public static List<SYS_FUN_POINT> FUN_POINTS = new List<SYS_FUN_POINT>();
        public static void LoadPrivates()
        {
            if (UserInfoHelper.UserInfo.USER_NAME == "admin")//admin用户本身为超级用户
            {
                Maticsoft.BLL.SMT_FUN_MENUPOINT bll = new Maticsoft.BLL.SMT_FUN_MENUPOINT();
                var list= bll.GetModelList("");
                CreateFunPoint(list);
            }
            else if (UserInfoHelper.UserInfo.ROLE_ID == null)
            {
                WinInfoHelper.ShowInfoWindow(null, "当前用户角色为空，没有权限！");
                return;
            }
            else
            {
                Maticsoft.BLL.SMT_ROLE_FUN rbll = new Maticsoft.BLL.SMT_ROLE_FUN();
                var rolefuns = rbll.GetModelList("ROLE_ID=" + UserInfoHelper.UserInfo.ROLE_ID);
                if (rolefuns.Count==0)
                {
                    WinInfoHelper.ShowInfoWindow(null, "当前用户没有权限！");
                    return;
                }
                string str = "";
                foreach (var item in rolefuns)
                {
                    str += item.FUN_ID + ",";
                }
                str = str.TrimEnd(',');
                Maticsoft.BLL.SMT_FUN_MENUPOINT bll = new Maticsoft.BLL.SMT_FUN_MENUPOINT();
                var list = bll.GetModelList("ID IN ("+str+")");
                CreateFunPoint(list);
            }
        }
        private static void CreateFunPoint(List<Maticsoft.Model.SMT_FUN_MENUPOINT> list)
        {
            foreach (var item in list)
            {
                SYS_FUN_POINT funPoint;
                if (Enum.TryParse<SYS_FUN_POINT>(item.FUN_CODE, out funPoint))
                {
                    FUN_POINTS.Add(funPoint);
                }
            }
        }
    }
     public enum SYS_FUN_POINT
    {
        VER_INFO_MGR,//	证件信息管理
        MODEL_INFO_MGR,//	模板设定管理
        SEARCH_INFO_MGR,//	信息系统查询
        REPORT_INFO_MGR,//	报表统计管理
        CTRLR_INFO_MGR,//	控制设备管理
        REAL_DETECT_MGR,//	实时监控管理
        RULE_INFO_MGR,//	规则设定管理
        SYS_CONFIG_MGR,//	系统配置管理
        VER_CODE,//	证件编码
        DEPT_MGR,//	部门管理
        STAFF_MGR,//	人员管理
        VER_MODEL,//	证件模板
        ACCESS_RECORD,//	门禁出入查询
        STAFF_ROUTE,//	人员轨迹查询
        LOG_INFO,//	操作日志查询
        ACCESS_RECORD_STA,//	门禁出入统计
        CTRLR_INFO,//	控制器管理
        REAL_MAP,//	实时地图显示
        REAL_ACCESS_STATE,//	实时状态显示
        CTRLR_TASK,//	控制定时任务
        MAP_CONFIG,//	地图编辑配置
        CARD_CONFIG,//	发卡编辑配置
        ACCESS_PASSWORD_CONFIG,//	门禁密码管理
        INOUT_TIME_CONFIG,//	出入时段管理
        DATABASE_BACK_CONFIG,//	数据备份管理
        MODIFY_PWD_CONFIG,//	修改用户密码
        SYS_README_CONFIG,//	系统使用说明
        USER_PRIVATE_CONFIG,//	用户权限管理
    }
}