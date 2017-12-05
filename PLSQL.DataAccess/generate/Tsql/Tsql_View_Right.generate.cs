/***************************************************
*
* Data Access Layer Of Winner Framework
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
        #region 默认构造

        public Tsql_View_Right() : base() { }

        public Tsql_View_Right(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _ID="ID";
		public const string _VIEW_ID="VIEW_ID";
		public const string _OWNER_TYPE="OWNER_TYPE";
		public const string _OWNER_ID="OWNER_ID";
		public const string _AUTH_TIME="AUTH_TIME";
		public const string _TIMEOUT="TIMEOUT";
		public const string _REMARKS="REMARKS";
		public const string _CREATE_TIME="CREATE_TIME";

    
        public const string _TABLENAME="Tsql_View_Right";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// 授权编号
		/// [default:0]
		/// </summary>
		public int Id
		{
			get { return Convert.ToInt32(DataRow[_ID]); }
			set { setProperty(_ID,value); }
		}
		/// <summary>
		/// 视图编号
		/// [default:0]
		/// </summary>
		public int ViewId
		{
			get { return Convert.ToInt32(DataRow[_VIEW_ID]); }
			set { setProperty(_VIEW_ID,value); }
		}
		/// <summary>
		/// 授权者类型{会员授权=1}
		/// [default:0]
		/// </summary>
		public int OwnerType
		{
			get { return Convert.ToInt32(DataRow[_OWNER_TYPE]); }
			set { setProperty(_OWNER_TYPE,value); }
		}
		/// <summary>
		/// 被授权者编号
		/// [default:0]
		/// </summary>
		public int OwnerId
		{
			get { return Convert.ToInt32(DataRow[_OWNER_ID]); }
			set { setProperty(_OWNER_ID,value); }
		}
		/// <summary>
		/// 授权时间
		/// [default:new DateTime()]
		/// </summary>
		public DateTime AuthTime
		{
			get { return Convert.ToDateTime(DataRow[_AUTH_TIME]); }
			set { setProperty(_AUTH_TIME,value); }
		}
		/// <summary>
		/// 过期时间
		/// [default:new DateTime()]
		/// </summary>
		public DateTime Timeout
		{
			get { return Convert.ToDateTime(DataRow[_TIMEOUT]); }
			set { setProperty(_TIMEOUT,value); }
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

        #endregion 公开属性
        
        #region 私有成员
        
        protected override string TableName
        {
            get { return _TABLENAME; }
        }

        protected override DataRow BuildRow()
        {
            DataTable dt = new DataTable(_TABLENAME);
			dt.Columns.Add(_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_VIEW_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_OWNER_TYPE, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_OWNER_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_AUTH_TIME, typeof(DateTime)).DefaultValue = new DateTime();
			dt.Columns.Add(_TIMEOUT, typeof(DateTime)).DefaultValue = new DateTime();
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_CREATE_TIME, typeof(DateTime)).DefaultValue = new DateTime();

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TSQL_VIEW_RIGHT WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int id)
        {
            string condition = "ID=:ID";
            AddParameter(_ID, id);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "ID=:ID";
            AddParameter(_ID, Id);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			Id=base.GetSequence("SELECT SEQ_TSQL_VIEW_RIGHT.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TSQL_VIEW_RIGHT(
  ID,
  VIEW_ID,
  OWNER_TYPE,
  OWNER_ID,
  AUTH_TIME,
  TIMEOUT,
  REMARKS)
VALUES(
  :ID,
  :VIEW_ID,
  :OWNER_TYPE,
  :OWNER_ID,
  :AUTH_TIME,
  :TIMEOUT,
  :REMARKS)";
			AddParameter(_ID,DataRow[_ID]);
			AddParameter(_VIEW_ID,DataRow[_VIEW_ID]);
			AddParameter(_OWNER_TYPE,DataRow[_OWNER_TYPE]);
			AddParameter(_OWNER_ID,DataRow[_OWNER_ID]);
			AddParameter(_AUTH_TIME,DataRow[_AUTH_TIME]);
			AddParameter(_TIMEOUT,DataRow[_TIMEOUT]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
            return base.InsertBySql(sql);
        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TSQL_VIEW_RIGHT SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE ID=:ID");
            AddParameter(_ID, DataRow[_ID]);
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
  ID,
  VIEW_ID,
  OWNER_TYPE,
  OWNER_ID,
  AUTH_TIME,
  TIMEOUT,
  REMARKS,
  CREATE_TIME
FROM TSQL_VIEW_RIGHT
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int id)
        {
            string condition = "ID=:ID";
            AddParameter(_ID, id);
            return SelectByCondition(condition);
        }
		public Tsql_View Get_Tsql_View_ByViewId()
		{
			Tsql_View da=new Tsql_View();
			da.SelectByPK(ViewId);
			return da;
		}



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tsql_View_Right
    /// </summary>
    public partial class Tsql_View_RightCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tsql_View_RightCollection() { }

        public Tsql_View_RightCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tsql_View_Right(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tsql_View_Right().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tsql_View_Right._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  ID,
  VIEW_ID,
  OWNER_TYPE,
  OWNER_ID,
  AUTH_TIME,
  TIMEOUT,
  REMARKS,
  CREATE_TIME
FROM TSQL_VIEW_RIGHT
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListById(int id)
        {
            string condition = "ID=:ID";
            AddParameter(Tsql_View_Right._ID, id);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TSQL_VIEW_RIGHT WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tsql_View_Right this[int index]
        {
            get
            {
                return new Tsql_View_Right(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tsql_View_Right Find(Predicate<Tsql_View_Right> match)
        {
            foreach (Tsql_View_Right item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tsql_View_RightCollection FindAll(Predicate<Tsql_View_Right> match)
        {
            Tsql_View_RightCollection list = new Tsql_View_RightCollection();
            foreach (Tsql_View_Right item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tsql_View_Right> match)
        {
            foreach (Tsql_View_Right item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tsql_View_Right> match)
        {
            BeginTransaction();
            foreach (Tsql_View_Right item in this)
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