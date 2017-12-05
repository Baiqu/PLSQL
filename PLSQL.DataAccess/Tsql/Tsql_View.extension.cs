/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tsql_View.extension.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2017-06-19 18:36:27  
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
    /// Data Access Layer Object Of Tsql_View
    /// </summary>
    public partial class Tsql_View : DataAccessBase
    {
        //Custom Extension Class
        public bool IsExistTitle(string title)
        {
            string condition = "VIEW_NAME=:Title";
            AddParameter("Title", title);
            return SelectByCondition(condition);
        }

        public bool SelectSQLBySqlId(int sqlid)
        {
            string sql = @"SELECT 
TV.VIEW_ID,
TV.VIEW_NAME,
TV.CLASSIFY_ID,
TV.COMMAND_TEXT,
TV.VIEW_TEMPLATE,
TV.CACHE_STATUS,
TV.PAGE_ROW,
TV.STATUS,
TV.INPUTER,
TV.REMARKS
FROM TSQL_VIEW TV
WHERE TV.VIEW_ID =: VIEWID";
            AddParameter("VIEWID", sqlid);
            return SelectBySql(sql);
        }

        public bool SelectView(int ViewId)
        {
            string condition = "VIEW_ID  =: VIEWID";
            AddParameter("VIEWID", ViewId);
            return SelectByCondition(condition);
        }

        /// <summary>
        /// 查询缓存表时候存在
        /// </summary>
        /// <returns></returns>
        public bool IsExistTable(int Sqlid)
        {
            string sql = "Select Count(*) From User_Tables t Where t.TABLE_NAME= 'PLSQLCACHE_" + Sqlid + "'";
            return base.GetIntValue(sql) > 0;
        }
        /// <summary>
        /// 删除缓存表
        /// </summary>
        /// <returns></returns>
        public bool DropCacheTable(int Sqlid)
        {
            string sql = "Drop TABLE PLSQLCACHE_" + Sqlid;
            return SelectBySql(sql);
        }
        /// <summary>
        /// 创建缓存表
        /// </summary>
        /// <returns></returns>
        public bool CreateCacheTable(int Sqlid,string Sqlcontent)
        {
            string sql = "create TABLE PLSQLCACHE_" + Sqlid + " AS select * from (" + Sqlcontent + ") where rownum<=1000";
            return base.ExecuteNonQuery(sql) > 0;
        }

        public bool CreateTimeIsToday(int Sqlid)
        {
            string sql = "SELECT  CREATED   FROM   ALL_OBJECTS   WHERE   OBJECT_NAME   = 'PLSQLCACHE_" + Sqlid + "'";
            return Convert.ToDateTime(base.GetStringValue(sql)).Date == DateTime.Today;
        }
    }

    /// <summary>
    /// Data Access Layer Object Collection Of Tsql_View
    /// </summary>
    public partial class Tsql_ViewCollection : DataAccessCollectionBase
    {
        //Custom Extension Class
        public bool ExecuteQuery(string sql)
        {
            return ListBySql(sql);
        }

        public bool GetAllViewByUserInfo(int userid,string usercode,string viewname)
        {
            string sql = @"SELECT DISTINCT TV.VIEW_ID,
                TV.VIEW_NAME,
                TV.CREATE_TIME,
                TV.REMARKS,
                TU.USER_NAME
  FROM TSQL_VIEW TV
  JOIN TNET_USER TU
    ON TV.INPUTER = TU.USER_CODE
  LEFT JOIN TSQL_VIEW_RIGHT TVR
    ON TV.VIEW_ID = TVR.VIEW_ID
 WHERE TV.STATUS = 1
   AND TU.USER_CODE =:USERCODE
    OR (TV.VIEW_ID = TVR.VIEW_ID AND TVR.OWNER_ID =:USERID AND
       (TO_CHAR(SYSDATE, 'yyyy/mm/dd') >=
       TO_CHAR(TVR.AUTH_TIME, 'yyyy/mm/dd') AND
       TO_CHAR(SYSDATE, 'yyyy/mm/dd') <=
       TO_CHAR(TVR.TIMEOUT, 'yyyy/mm/dd')))";
            AddParameter("USERID", userid);
            AddParameter("USERCODE", usercode);
            //if (userid > 0)
            //{
            //    sql += " AND TU.USER_ID =: USERID";
            //    AddParameter("USERID", userid);
            //}
            //if(usercode != "")
            //{
            //    sql += " AND TV.INPUTER =: USERCODE";
            //    AddParameter("USERCODE", usercode);
            //}
            if(viewname != "")
            {
                sql += " AND TV.VIEW_NAME LIKE '%'||:VIEWNAME||'%'";
                AddParameter("VIEWNAME", viewname);
            }
            sql += " ORDER BY TV.VIEW_ID DESC";
            return ListBySql(sql);
        }

        public bool GetAllViewByClassifyAndUserName(string viewname,int classifyid,string username)
        {
            string sql = @"SELECT 
TV.VIEW_ID,
TV.VIEW_NAME,
TV.CLASSIFY_ID,
TV.COMMAND_TEXT,
TV.VIEW_TEMPLATE,
TV.CACHE_STATUS,
TV.PAGE_ROW,
TV.STATUS,
TV.INPUTER,
TV.REMARKS,
TU.USER_NAME UserName,
TV.CREATE_TIME,
TC.CLASSIFY_NAME
FROM TSQL_VIEW TV
JOIN TNET_USER TU
ON TV.INPUTER = TU.USER_CODE
JOIN TSQL_CLASSIFY TC
ON TV.CLASSIFY_ID = TC.CLASSIFY_ID
WHERE TV.STATUS = 1";
            if (viewname != "")
            {
                sql += " AND TV.VIEW_NAME LIKE '%'||:VIEWNAME||'%'";
                AddParameter("VIEWNAME", viewname);
            }
            if (classifyid > 0)
            {
                sql += " AND TV.CLASSIFY_ID =: CLASSIFYID";
                AddParameter("CLASSIFYID", classifyid);
            }
            if (username != "")
            {
                sql += " AND TV.INPUTER =: USERNAME";
                AddParameter("USERNAME", username);
            }
            return ListBySql(sql);
        }

        public bool ListByALLPlSql(string plSql)
        {
            string sql = @"SELECT *
                              FROM (SELECT ROWNUM AS NUM, TAB1.*
                                      FROM ({0}) TAB1 )";
            sql = string.Format(sql, plSql);
            return ListBySql(sql);
        }
        public bool ListByALLPlSqlByOrder(string plSql,string order,string orderby,string sch)
        {
            string sql = "";
            if (order != "" && orderby != "" && order != "NUM")
            {
                sql = @"SELECT *
                              FROM (SELECT ROWNUM AS NUM, TAB1.*
                                      FROM ({0}) TAB1  ORDER BY TAB1.{1} {2} )";
                sql = string.Format(sql, plSql, order, orderby);
            }
            else if (order == "NUM")
            {
                sql = @"SELECT *
                              FROM (SELECT ROWNUM AS NUM, TAB1.*
                                      FROM ({0}) TAB1 ORDER BY NUM {1})";
                sql = string.Format(sql, plSql,orderby);
            }
            else
            {
                sql = @"SELECT *
                              FROM (SELECT ROWNUM AS NUM, TAB1.*
                                      FROM ({0}) TAB1 )";
                sql = string.Format(sql, plSql);
            }
            sql += " WHERE {0}";
            sql = string.Format(sql, sch);
            return ListBySql(sql);
        }

        //public bool ListByALLPlSql(string plSql, int pageSize, int pageIndex)
        //{
        //    int maxRow = pageSize * pageIndex;
        //    int minRow = maxRow - pageSize + 1;
        //    string sql = @"Select *
        //                      from (Select rownum As num, tab1.*
        //                              from ({0}) tab1
        //                             where rownum <= {1}) tab2
        //                     Where num >= {2}";
        //    sql = string.Format(sql, plSql, maxRow, minRow);
        //    return ListBySql(sql);
        //}
    }
}