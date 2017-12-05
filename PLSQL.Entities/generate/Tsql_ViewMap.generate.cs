/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tsql_View.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2017-06-14 19:10:52  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace Winner.PLSQL.Entities
{
    /// <summary>
    /// Data Access Layer Object Of Tsql_View
    /// </summary>
    public partial class Tsql_ViewMap
    {
        #region 公开属性
        
		/// <summary>
		/// 视图ID
		/// [default:0]
		/// </summary>
		public int ViewId { get; set; }

		/// <summary>
		/// 视图名称
		/// [default:string.Empty]
		/// </summary>
		public string ViewName { get; set; }

		/// <summary>
		/// 类别ID
		/// [default:0]
		/// </summary>
		public int ClassifyId { get; set; }

		/// <summary>
		/// SQL命令
		/// [default:string.Empty]
		/// </summary>
		public string CommandText { get; set; }

		/// <summary>
		/// 展示视图模板
		/// [default:string.Empty]
		/// </summary>
		public string ViewTemplate { get; set; }

		/// <summary>
		/// 默认每页行数
		/// [default:0]
		/// </summary>
		public int PageRow { get; set; }

		/// <summary>
		/// 状态{禁用=0,启用=1}
		/// [default:0]
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// 信息录入人员
		/// [default:string.Empty]
		/// </summary>
		public string Inputer { get; set; }

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

		/// <summary>
		/// 缓存状态
		/// [default:DBNull.Value]
		/// </summary>
		public int CacheStatus { get; set; }



        #endregion 公开属性
    } 
}