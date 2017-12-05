/***************************************************
*
* Data Access Layer Of Winner Framework
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
        #region 默认构造

        public Tsql_Classify() : base() { }

        public Tsql_Classify(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _CLASSIFY_ID="CLASSIFY_ID";
		public const string _CLASSIFY_NAME="CLASSIFY_NAME";
		public const string _PARENT_ID="PARENT_ID";
		public const string _STATUS="STATUS";
		public const string _REMARKS="REMARKS";
		public const string _CREATE_TIME="CREATE_TIME";

    
        public const string _TABLENAME="Tsql_Classify";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// Classify主键
		/// [default:0]
		/// </summary>
		public int ClassifyId
		{
			get { return Convert.ToInt32(DataRow[_CLASSIFY_ID]); }
			set { setProperty(_CLASSIFY_ID,value); }
		}
		/// <summary>
		/// 类别名称
		/// [default:string.Empty]
		/// </summary>
		public string ClassifyName
		{
			get { return DataRow[_CLASSIFY_NAME].ToString(); }
			set { setProperty(_CLASSIFY_NAME,value); }
		}
		/// <summary>
		/// 父级ID
		/// [default:0]
		/// </summary>
		public int ParentId
		{
			get { return Convert.ToInt32(DataRow[_PARENT_ID]); }
			set { setProperty(_PARENT_ID,value); }
		}
		/// <summary>
		/// 类别状态{禁用=0,启用=1}
		/// [default:0]
		/// </summary>
		public int Status
		{
			get { return Convert.ToInt32(DataRow[_STATUS]); }
			set { setProperty(_STATUS,value); }
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
			dt.Columns.Add(_CLASSIFY_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_CLASSIFY_NAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_PARENT_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_CREATE_TIME, typeof(DateTime)).DefaultValue = new DateTime();

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TSQL_CLASSIFY WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int classifyId)
        {
            string condition = "CLASSIFY_ID=:CLASSIFY_ID";
            AddParameter(_CLASSIFY_ID, classifyId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "CLASSIFY_ID=:CLASSIFY_ID";
            AddParameter(_CLASSIFY_ID, ClassifyId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			ClassifyId=base.GetSequence("SELECT SEQ_TSQL_CLASSIFY.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TSQL_CLASSIFY(
  CLASSIFY_ID,
  CLASSIFY_NAME,
  PARENT_ID,
  STATUS,
  REMARKS)
VALUES(
  :CLASSIFY_ID,
  :CLASSIFY_NAME,
  :PARENT_ID,
  :STATUS,
  :REMARKS)";
			AddParameter(_CLASSIFY_ID,DataRow[_CLASSIFY_ID]);
			AddParameter(_CLASSIFY_NAME,DataRow[_CLASSIFY_NAME]);
			AddParameter(_PARENT_ID,DataRow[_PARENT_ID]);
			AddParameter(_STATUS,DataRow[_STATUS]);
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
            ChangePropertys.Remove(_CLASSIFY_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TSQL_CLASSIFY SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE CLASSIFY_ID=:CLASSIFY_ID");
            AddParameter(_CLASSIFY_ID, DataRow[_CLASSIFY_ID]);
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
  CLASSIFY_ID,
  CLASSIFY_NAME,
  PARENT_ID,
  STATUS,
  REMARKS,
  CREATE_TIME
FROM TSQL_CLASSIFY
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int classifyId)
        {
            string condition = "CLASSIFY_ID=:CLASSIFY_ID";
            AddParameter(_CLASSIFY_ID, classifyId);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tsql_Classify
    /// </summary>
    public partial class Tsql_ClassifyCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tsql_ClassifyCollection() { }

        public Tsql_ClassifyCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tsql_Classify(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tsql_Classify().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tsql_Classify._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  CLASSIFY_ID,
  CLASSIFY_NAME,
  PARENT_ID,
  STATUS,
  REMARKS,
  CREATE_TIME
FROM TSQL_CLASSIFY
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByClassifyId(int classifyId)
        {
            string condition = "CLASSIFY_ID=:CLASSIFY_ID";
            AddParameter(Tsql_Classify._CLASSIFY_ID, classifyId);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TSQL_CLASSIFY WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tsql_Classify this[int index]
        {
            get
            {
                return new Tsql_Classify(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tsql_Classify Find(Predicate<Tsql_Classify> match)
        {
            foreach (Tsql_Classify item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tsql_ClassifyCollection FindAll(Predicate<Tsql_Classify> match)
        {
            Tsql_ClassifyCollection list = new Tsql_ClassifyCollection();
            foreach (Tsql_Classify item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tsql_Classify> match)
        {
            foreach (Tsql_Classify item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tsql_Classify> match)
        {
            BeginTransaction();
            foreach (Tsql_Classify item in this)
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