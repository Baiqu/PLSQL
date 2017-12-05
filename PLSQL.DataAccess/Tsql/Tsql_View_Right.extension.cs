/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tsql_View_Right.extension.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2017-06-14 11:30:44  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Winner.Framework.Core;
using Winner.Framework.Core.DataAccess;
using Winner.Framework.Core.DataAccess.Oracle;
using Winner.Framework.Utils;
namespace Winner.PLSQL.DataAccess
{
    /// <summary>
    /// Data Access Layer Object Of Tsql_View_Right
    /// </summary>
    public partial class Tsql_View_Right : DataAccessBase
    {
        //Custom Extension Class
        public bool Verification(int userid,int viewid)
        {
            string condition = "OWNER_ID =: USERID AND VIEW_ID =: VIEWID";
            AddParameter("USERID", userid);
            AddParameter("VIEWID", viewid);
            return SelectByCondition(condition);
        }
    }

    /// <summary>
    /// Data Access Layer Object Collection Of Tsql_View_Right
    /// </summary>
    public partial class Tsql_View_RightCollection : DataAccessCollectionBase
    {
        //Custom Extension Class
        public bool GetViewRightByViewId(int ViewId)
        {
            string sql = @"SELECT
                            TVR.ID,
                            TVR.VIEW_ID,
                            TVR.AUTH_TIME,
                            TVR.TIMEOUT,
                            TU.USER_CODE,
                            TU.USER_NAME
                            FROM TSQL_VIEW_RIGHT TVR
                            JOIN TNET_USER TU
                            ON TVR.OWNER_ID = TU.USER_ID
                            WHERE TVR.VIEW_ID =: VIEWID";
            AddParameter("VIEWID", ViewId);
            return ListBySql(sql);
        }
    }
}