/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tsql_Classify.extension.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2017-06-14 11:30:21  
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
    /// Data Access Layer Object Of Tsql_Classify
    /// </summary>
    public partial class Tsql_Classify : DataAccessBase
    {
        //Custom Extension Class
        public bool SelectByClassifyId(int classifyId)
        {
            string condition = "CLASSIFY_ID =: CLASSIFYID AND  STATUS = 1";
            AddParameter("CLASSIFYID", classifyId);
            return SelectByCondition(condition);
        }

        public bool Verificationtitle(string title)
        {
            string condition = "CLASSIFY_NAME =: CLASSIFYNAME";
            AddParameter("CLASSIFYNAME", title);
            return SelectByCondition(condition);
        }
    }

    /// <summary>
    /// Data Access Layer Object Collection Of Tsql_Classify
    /// </summary>
    public partial class Tsql_ClassifyCollection : DataAccessCollectionBase
    {
        //Custom Extension Class
        public bool SelectClassify()
        {
            string condition = "STATUS = 1 ORDER BY CLASSIFY_ID ASC";
            return ListByCondition(condition);
        }
    }
}