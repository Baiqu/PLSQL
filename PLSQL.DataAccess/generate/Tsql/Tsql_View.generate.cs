/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tsql_View.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2017-06-19 18:36:28  
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
        #region 默认构造

        public Tsql_View() : base() { }

        public Tsql_View(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _VIEW_ID="VIEW_ID";
		public const string _VIEW_NAME="VIEW_NAME";
		public const string _CLASSIFY_ID="CLASSIFY_ID";
		public const string _COMMAND_TEXT="COMMAND_TEXT";
		public const string _VIEW_TEMPLATE="VIEW_TEMPLATE";
		public const string _PAGE_ROW="PAGE_ROW";
		public const string _STATUS="STATUS";
		public const string _INPUTER="INPUTER";
		public const string _REMARKS="REMARKS";
		public const string _CREATE_TIME="CREATE_TIME";
		public const string _CACHE_STATUS="CACHE_STATUS";

    
        public const string _TABLENAME="Tsql_View";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// 视图ID
		/// [default:0]
		/// </summary>
		public int ViewId
		{
			get { return Convert.ToInt32(DataRow[_VIEW_ID]); }
			set { setProperty(_VIEW_ID,value); }
		}
		/// <summary>
		/// 视图名称
		/// [default:string.Empty]
		/// </summary>
		public string ViewName
		{
			get { return DataRow[_VIEW_NAME].ToString(); }
			set { setProperty(_VIEW_NAME,value); }
		}
		/// <summary>
		/// 类别ID
		/// [default:0]
		/// </summary>
		public int ClassifyId
		{
			get { return Convert.ToInt32(DataRow[_CLASSIFY_ID]); }
			set { setProperty(_CLASSIFY_ID,value); }
		}
		/// <summary>
		/// SQL命令
		/// [default:string.Empty]
		/// </summary>
		public string CommandText
		{
			get { return DataRow[_COMMAND_TEXT].ToString(); }
			set { setProperty(_COMMAND_TEXT,value); }
		}
		/// <summary>
		/// 展示视图模板
		/// [default:string.Empty]
		/// </summary>
		public string ViewTemplate
		{
			get { return DataRow[_VIEW_TEMPLATE].ToString(); }
			set { setProperty(_VIEW_TEMPLATE,value); }
		}
		/// <summary>
		/// 默认每页行数
		/// [default:0]
		/// </summary>
		public int PageRow
		{
			get { return Convert.ToInt32(DataRow[_PAGE_ROW]); }
			set { setProperty(_PAGE_ROW,value); }
		}
		/// <summary>
		/// 状态{禁用=0,启用=1}
		/// [default:0]
		/// </summary>
		public int Status
		{
			get { return Convert.ToInt32(DataRow[_STATUS]); }
			set { setProperty(_STATUS,value); }
		}
		/// <summary>
		/// 信息录入人员
		/// [default:string.Empty]
		/// </summary>
		public string Inputer
		{
			get { return DataRow[_INPUTER].ToString(); }
			set { setProperty(_INPUTER,value); }
		}
		/// <summary>
		/// 备注
		/// [default:string.Empty]
		/// </summary>
		public string Remarks
		{
			get { return DataRow[_REMARKS].ToString(); }
			set { setProperty(_REMARKS,value); }
		}
		/// <summary>
		/// 创建时间
		/// [default:new DateTime()]
		/// </summary>
		public DateTime CreateTime
		{
			get { return Convert.ToDateTime(DataRow[_CREATE_TIME].ToString()); }
		}
		/// <summary>
		/// 缓存状态{未开启=0,已开启=1}
		/// [default:DBNull.Value]
		/// </summary>
		public int? CacheStatus
		{
			get { return Helper.ToInt32(DataRow[_CACHE_STATUS]); }
			set { setProperty(_CACHE_STATUS,Helper.FromInt32(value)); }
		}

        #endregion 公开属性
        
        #region 私有成员
        
        protected override string TableName
        {
            get { return _TABLENAME; }
        }

        protected override DataRow BuildRow()
        {
            DataTable dt = new DataTable(_TABLENAME);
			dt.Columns.Add(_VIEW_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_VIEW_NAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_CLASSIFY_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_COMMAND_TEXT, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_VIEW_TEMPLATE, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_PAGE_ROW, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_INPUTER, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_CREATE_TIME, typeof(DateTime)).DefaultValue = new DateTime();
			dt.Columns.Add(_CACHE_STATUS, typeof(int)).DefaultValue = DBNull.Value;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TSQL_VIEW WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int viewId)
        {
            string condition = "VIEW_ID=:VIEW_ID";
            AddParameter(_VIEW_ID, viewId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "VIEW_ID=:VIEW_ID";
            AddParameter(_VIEW_ID, ViewId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			ViewId=base.GetSequence("SELECT SEQ_TSQL_VIEW.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TSQL_VIEW(
  VIEW_ID,
  VIEW_NAME,
  CLASSIFY_ID,
  COMMAND_TEXT,
  VIEW_TEMPLATE,
  PAGE_ROW,
  STATUS,
  INPUTER,
  REMARKS,
  CACHE_STATUS)
VALUES(
  :VIEW_ID,
  :VIEW_NAME,
  :CLASSIFY_ID,
  :COMMAND_TEXT,
  :VIEW_TEMPLATE,
  :PAGE_ROW,
  :STATUS,
  :INPUTER,
  :REMARKS,
  :CACHE_STATUS)";
			AddParameter(_VIEW_ID,DataRow[_VIEW_ID]);
			AddParameter(_VIEW_NAME,DataRow[_VIEW_NAME]);
			AddParameter(_CLASSIFY_ID,DataRow[_CLASSIFY_ID]);
			AddParameter(_COMMAND_TEXT,DataRow[_COMMAND_TEXT]);
			AddParameter(_VIEW_TEMPLATE,DataRow[_VIEW_TEMPLATE]);
			AddParameter(_PAGE_ROW,DataRow[_PAGE_ROW]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_INPUTER,DataRow[_INPUTER]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_CACHE_STATUS,DataRow[_CACHE_STATUS]);
            return base.InsertBySql(sql);
        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_VIEW_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TSQL_VIEW SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE VIEW_ID=:VIEW_ID");
            AddParameter(_VIEW_ID, DataRow[_VIEW_ID]);
            if (!string.IsNullOrEmpty(condition))
                sql.AppendLine(" AND " + condition);
                
            bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
        }

        protected bool SelectByCondition(string condition)
        {
            string sql = @"
SELECT
  VIEW_ID,
  VIEW_NAME,
  CLASSIFY_ID,
  COMMAND_TEXT,
  VIEW_TEMPLATE,
  PAGE_ROW,
  STATUS,
  INPUTER,
  REMARKS,
  CREATE_TIME,
  CACHE_STATUS
FROM TSQL_VIEW
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int viewId)
        {
            string condition = "VIEW_ID=:VIEW_ID";
            AddParameter(_VIEW_ID, viewId);
            return SelectByCondition(condition);
        }
		public Tsql_Classify Get_Tsql_Classify_ByClassifyId()
		{
			Tsql_Classify da=new Tsql_Classify();
			da.SelectByPK(ClassifyId);
			return da;
		}



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tsql_View
    /// </summary>
    public partial class Tsql_ViewCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tsql_ViewCollection() { }

        public Tsql_ViewCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tsql_View(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tsql_View().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tsql_View._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  VIEW_ID,
  VIEW_NAME,
  CLASSIFY_ID,
  COMMAND_TEXT,
  VIEW_TEMPLATE,
  PAGE_ROW,
  STATUS,
  INPUTER,
  REMARKS,
  CREATE_TIME,
  CACHE_STATUS
FROM TSQL_VIEW
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByViewId(int viewId)
        {
            string condition = "VIEW_ID=:VIEW_ID";
            AddParameter(Tsql_View._VIEW_ID, viewId);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TSQL_VIEW WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tsql_View this[int index]
        {
            get
            {
                return new Tsql_View(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tsql_View Find(Predicate<Tsql_View> match)
        {
            foreach (Tsql_View item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tsql_ViewCollection FindAll(Predicate<Tsql_View> match)
        {
            Tsql_ViewCollection list = new Tsql_ViewCollection();
            foreach (Tsql_View item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tsql_View> match)
        {
            foreach (Tsql_View item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tsql_View> match)
        {
            BeginTransaction();
            foreach (Tsql_View item in this)
            {
                item.ReferenceTransactionFrom(Transaction);
                if (!match(item))
                    continue;
                if (!item.Delete())
                {
                    Rollback();
                    return false;
                }
            }
            Commit();
            return true;
        }
        #endregion Linq
        #endregion
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
} 