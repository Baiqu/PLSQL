/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tsql_Classify.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2017-06-14 11:30:22  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace Winner.PLSQL.Entities
{
    /// <summary>
    /// Data Access Layer Object Of Tsql_Classify
    /// </summary>
    public partial class Tsql_ClassifyMap
    {
        #region 公开属性
        
		/// <summary>
		/// Classify主键
		/// [default:0]
		/// </summary>
		public int ClassifyId { get; set; }

		/// <summary>
		/// 类别名称
		/// [default:string.Empty]
		/// </summary>
		public string ClassifyName { get; set; }

		/// <summary>
		/// 父级ID
		/// [default:0]
		/// </summary>
		public int ParentId { get; set; }

		/// <summary>
		/// 类别状态{禁用=0,启用=1}
		/// [default:0]
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// 备注
		/// [default:string.Empty]
		/// </summary>
		public string Remarks { get; set; }

		/// <summary>
		/// 创建时间
		/// [default:new DateTime()]
		/// </summary>
		public DateTime CreateTime { get; set; }



        #endregion 公开属性
    } 
}