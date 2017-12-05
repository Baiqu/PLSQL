/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tsql_View_Right.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2017-06-14 11:30:45  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace Winner.PLSQL.Entities
{
    /// <summary>
    /// Data Access Layer Object Of Tsql_View_Right
    /// </summary>
    public partial class Tsql_View_RightMap
    {
        #region 公开属性
        
		/// <summary>
		/// 授权编号
		/// [default:0]
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// 视图编号
		/// [default:0]
		/// </summary>
		public int ViewId { get; set; }

		/// <summary>
		/// 授权者类型{会员授权=1}
		/// [default:0]
		/// </summary>
		public int OwnerType { get; set; }

		/// <summary>
		/// 被授权者编号
		/// [default:0]
		/// </summary>
		public int OwnerId { get; set; }

		/// <summary>
		/// 授权时间
		/// [default:new DateTime()]
		/// </summary>
		public DateTime AuthTime { get; set; }

		/// <summary>
		/// 过期时间
		/// [default:new DateTime()]
		/// </summary>
		public DateTime Timeout { get; set; }

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