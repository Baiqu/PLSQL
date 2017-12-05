/***************************************************
*
* Data Access Layer Map Of Winner Framework
* FileName : Tsql_View_Parameter.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2017-06-14 11:30:37  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace Winner.PLSQL.Entities
{
    /// <summary>
    /// Data Access Layer Object Of Tsql_View_Parameter
    /// </summary>
    public partial class Tsql_View_ParameterMap
    {
        #region 公开属性
        
		/// <summary>
		/// 参数ID
		/// [default:0]
		/// </summary>
		public int ParameterId { get; set; }

		/// <summary>
		/// 参数名称
		/// [default:string.Empty]
		/// </summary>
		public string ParameterName { get; set; }

		/// <summary>
		/// 参数类型{任意字符=0,时间控件=1,数字控件=2,选择控件=3}
		/// [default:0]
		/// </summary>
		public int ParameterType { get; set; }

		/// <summary>
		/// 参数数值，根据ParameterType类型来决定，采用Json格式保存
		/// [default:string.Empty]
		/// </summary>
		public string ParameterValue { get; set; }

		/// <summary>
		/// 视图编号
		/// [default:0]
		/// </summary>
		public int ViewId { get; set; }

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