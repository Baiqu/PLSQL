/***************************************************
*
* Data Access Layer Of Winner Framework
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
using Winner.Framework.Core;
using Winner.Framework.Core.DataAccess;
using Winner.Framework.Core.DataAccess.Oracle;
using Winner.Framework.Utils;
namespace Winner.PLSQL.DataAccess
{
    /// <summary>
    /// Data Access Layer Object Of Tsql_View_Parameter
    /// </summary>
    public partial class Tsql_View_Parameter : DataAccessBase
    {
        #region 默认构造

        public Tsql_View_Parameter() : base() { }

        public Tsql_View_Parameter(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _PARAMETER_ID="PARAMETER_ID";
		public const string _PARAMETER_NAME="PARAMETER_NAME";
		public const string _PARAMETER_TYPE="PARAMETER_TYPE";
		public const string _PARAMETER_VALUE="PARAMETER_VALUE";
		public const string _VIEW_ID="VIEW_ID";
		public const string _REMARKS="REMARKS";
		public const string _CREATE_TIME="CREATE_TIME";

    
        public const string _TABLENAME="Tsql_View_Parameter";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// 参数ID
		/// [default:0]
		/// </summary>
		public int ParameterId
		{
			get { return Convert.ToInt32(DataRow[_PARAMETER_ID]); }
			set { setProperty(_PARAMETER_ID,value); }
		}
		/// <summary>
		/// 参数名称
		/// [default:string.Empty]
		/// </summary>
		public string ParameterName
		{
			get { return DataRow[_PARAMETER_NAME].ToString(); }
			set { setProperty(_PARAMETER_NAME,value); }
		}
		/// <summary>
		/// 参数类型{任意字符=0,时间控件=1,数字控件=2,选择控件=3}
		/// [default:0]
		/// </summary>
		public int ParameterType
		{
			get { return Convert.ToInt32(DataRow[_PARAMETER_TYPE]); }
			set { setProperty(_PARAMETER_TYPE,value); }
		}
		/// <summary>
		/// 参数数值，根据ParameterType类型来决定，采用Json格式保存
		/// [default:string.Empty]
		/// </summary>
		public string ParameterValue
		{
			get { return DataRow[_PARAMETER_VALUE].ToString(); }
			set { setProperty(_PARAMETER_VALUE,value); }
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
			dt.Columns.Add(_PARAMETER_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_PARAMETER_NAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_PARAMETER_TYPE, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_PARAMETER_VALUE, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_VIEW_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_CREATE_TIME, typeof(DateTime)).DefaultValue = new DateTime();

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TSQL_VIEW_PARAMETER WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int parameterId)
        {
            string condition = "PARAMETER_ID=:PARAMETER_ID";
            AddParameter(_PARAMETER_ID, parameterId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "PARAMETER_ID=:PARAMETER_ID";
            AddParameter(_PARAMETER_ID, ParameterId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			ParameterId=base.GetSequence("SELECT SEQ_TSQL_VIEW_PARAMETER.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TSQL_VIEW_PARAMETER(
  PARAMETER_ID,
  PARAMETER_NAME,
  PARAMETER_TYPE,
  PARAMETER_VALUE,
  VIEW_ID,
  REMARKS)
VALUES(
  :PARAMETER_ID,
  :PARAMETER_NAME,
  :PARAMETER_TYPE,
  :PARAMETER_VALUE,
  :VIEW_ID,
  :REMARKS)";
			AddParameter(_PARAMETER_ID,DataRow[_PARAMETER_ID]);
			AddParameter(_PARAMETER_NAME,DataRow[_PARAMETER_NAME]);
			AddParameter(_PARAMETER_TYPE,DataRow[_PARAMETER_TYPE]);
			AddParameter(_PARAMETER_VALUE,DataRow[_PARAMETER_VALUE]);
			AddParameter(_VIEW_ID,DataRow[_VIEW_ID]);
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
            ChangePropertys.Remove(_PARAMETER_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TSQL_VIEW_PARAMETER SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE PARAMETER_ID=:PARAMETER_ID");
            AddParameter(_PARAMETER_ID, DataRow[_PARAMETER_ID]);
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
  PARAMETER_ID,
  PARAMETER_NAME,
  PARAMETER_TYPE,
  PARAMETER_VALUE,
  VIEW_ID,
  REMARKS,
  CREATE_TIME
FROM TSQL_VIEW_PARAMETER
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int parameterId)
        {
            string condition = "PARAMETER_ID=:PARAMETER_ID";
            AddParameter(_PARAMETER_ID, parameterId);
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
    /// Data Access Layer Object Collection Of Tsql_View_Parameter
    /// </summary>
    public partial class Tsql_View_ParameterCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tsql_View_ParameterCollection() { }

        public Tsql_View_ParameterCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tsql_View_Parameter(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tsql_View_Parameter().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tsql_View_Parameter._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  PARAMETER_ID,
  PARAMETER_NAME,
  PARAMETER_TYPE,
  PARAMETER_VALUE,
  VIEW_ID,
  REMARKS,
  CREATE_TIME
FROM TSQL_VIEW_PARAMETER
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByParameterId(int parameterId)
        {
            string condition = "PARAMETER_ID=:PARAMETER_ID";
            AddParameter(Tsql_View_Parameter._PARAMETER_ID, parameterId);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TSQL_VIEW_PARAMETER WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tsql_View_Parameter this[int index]
        {
            get
            {
                return new Tsql_View_Parameter(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tsql_View_Parameter Find(Predicate<Tsql_View_Parameter> match)
        {
            foreach (Tsql_View_Parameter item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tsql_View_ParameterCollection FindAll(Predicate<Tsql_View_Parameter> match)
        {
            Tsql_View_ParameterCollection list = new Tsql_View_ParameterCollection();
            foreach (Tsql_View_Parameter item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tsql_View_Parameter> match)
        {
            foreach (Tsql_View_Parameter item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tsql_View_Parameter> match)
        {
            BeginTransaction();
            foreach (Tsql_View_Parameter item in this)
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