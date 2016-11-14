﻿/**  版本信息模板在安装目录下，可自行修改。
* SMT_SUPER_PWD.cs
*
* 功 能： N/A
* 类 名： SMT_SUPER_PWD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/14 23:33:00   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 超级通信密码表
	/// </summary>
	[Serializable]
	public partial class SMT_SUPER_PWD
	{
		public SMT_SUPER_PWD()
		{}
		#region Model
		private decimal _id;
		private string _super_pwd;
		private decimal _door_id;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 超级密码
		/// </summary>
		public string SUPER_PWD
		{
			set{ _super_pwd=value;}
			get{return _super_pwd;}
		}
		/// <summary>
		/// 门禁ID
		/// </summary>
		public decimal DOOR_ID
		{
			set{ _door_id=value;}
			get{return _door_id;}
		}
		#endregion Model

	}
}

