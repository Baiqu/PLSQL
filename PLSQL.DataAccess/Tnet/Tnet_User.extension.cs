/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnet_User.extension.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2017-06-17 11:13:25  
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
    /// Data Access Layer Object Of Tnet_User
    /// </summary>
    public partial class Tnet_User : DataAccessBase
    {
        //Custom Extension Class
        public bool SelectUserCode(string usercode)
        {
            string condition = "USER_CODE=:USERCODE";
            AddParameter("USERCODE", usercode);
            return SelectByCondition(condition);
        }
    }

    /// <summary>
    /// Data Access Layer Object Collection Of Tnet_User
    /// </summary>
    public partial class Tnet_UserCollection : DataAccessCollectionBase
    {
        //Custom Extension Class
    }
}