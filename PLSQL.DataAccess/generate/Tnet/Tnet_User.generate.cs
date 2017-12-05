/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnet_User.generate.cs 
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
using Winner.PLSQL.Entities;

namespace Winner.PLSQL.DataAccess
{
    /// <summary>
    /// Data Access Layer Object Of Tnet_User
    /// </summary>
    public partial class Tnet_User : DataAccessBase
    {
        #region 默认构造

        public Tnet_User() : base() { }

        public Tnet_User(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _USER_ID="USER_ID";
		public const string _USER_CODE="USER_CODE";
		public const string _USER_NICKNAME="USER_NICKNAME";
		public const string _USER_NAME="USER_NAME";
		public const string _FATHER_ID="FATHER_ID";
		public const string _USER_STATUS="USER_STATUS";
		public const string _USER_LEVEL="USER_LEVEL";
		public const string _E_MAIL="E_MAIL";
		public const string _MOBILE_NO="MOBILE_NO";
		public const string _AUTH_STATUS="AUTH_STATUS";
		public const string _AUTH_TIME="AUTH_TIME";
		public const string _LOGIN_PASSWORD="LOGIN_PASSWORD";
		public const string _PAYMENT_PASSWORD="PAYMENT_PASSWORD";
		public const string _PHOTO_URL="PHOTO_URL";
		public const string _DATA_SOURCE="DATA_SOURCE";
		public const string _REMARKS="REMARKS";
		public const string _CREATE_TIME="CREATE_TIME";

    
        public const string _TABLENAME="Tnet_User";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// 用户编号
		/// [default:0]
		/// </summary>
		public int UserId
		{
			get { return Convert.ToInt32(DataRow[_USER_ID]); }
			set { setProperty(_USER_ID,value); }
		}
		/// <summary>
		/// 用户账号
		/// [default:string.Empty]
		/// </summary>
		public string UserCode
		{
			get { return DataRow[_USER_CODE].ToString(); }
			set { setProperty(_USER_CODE,value); }
		}
		/// <summary>
		/// 用户昵称
		/// [default:string.Empty]
		/// </summary>
		public string UserNickname
		{
			get { return DataRow[_USER_NICKNAME].ToString(); }
			set { setProperty(_USER_NICKNAME,value); }
		}
		/// <summary>
		/// 用户姓名
		/// [default:string.Empty]
		/// </summary>
		public string UserName
		{
			get { return DataRow[_USER_NAME].ToString(); }
			set { setProperty(_USER_NAME,value); }
		}
		/// <summary>
		/// 推荐人用户编号
		/// [default:DBNull.Value]
		/// </summary>
		public int? FatherId
		{
			get { return Helper.ToInt32(DataRow[_FATHER_ID]); }
			set { setProperty(_FATHER_ID,Helper.FromInt32(value)); }
		}
		/// <summary>
		/// 用户状态,未激活=0,已激活=1,已注销=2,已封锁=3
		/// [default:0]
		/// </summary>
		public UserStatus UserStatus
		{
			get { return (UserStatus)int.Parse(DataRow[_USER_STATUS].ToString()); }
			set { setProperty(_USER_STATUS,(int)value); }
		}
		/// <summary>
		/// 用户级别
		/// [default:0]
		/// </summary>
		public int UserLevel
		{
			get { return Convert.ToInt32(DataRow[_USER_LEVEL]); }
			set { setProperty(_USER_LEVEL,value); }
		}
		/// <summary>
		/// E-Mail
		/// [default:string.Empty]
		/// </summary>
		public string EMail
		{
			get { return DataRow[_E_MAIL].ToString(); }
			set { setProperty(_E_MAIL,value); }
		}
		/// <summary>
		/// 手机号码
		/// [default:string.Empty]
		/// </summary>
		public string MobileNo
		{
			get { return DataRow[_MOBILE_NO].ToString(); }
			set { setProperty(_MOBILE_NO,value); }
		}
		/// <summary>
		/// 实名认证状态{未实名=0,审核中=1,已认证=2，认证失败=4}
		/// [default:0]
		/// </summary>
		public AuthStatus AuthStatus
		{
			get { return (AuthStatus)int.Parse(DataRow[_AUTH_STATUS].ToString()); }
			set { setProperty(_AUTH_STATUS,(int)value); }
		}
		/// <summary>
		/// 实名验证时间
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? AuthTime
		{
			get { return Helper.ToDateTime(DataRow[_AUTH_TIME]); }
			set { setProperty(_AUTH_TIME,Helper.FromDateTime(value)); }
		}
		/// <summary>
		/// 用户登陆密码
		/// [default:string.Empty]
		/// </summary>
		public string LoginPassword
		{
			get { return DataRow[_LOGIN_PASSWORD].ToString(); }
			set { setProperty(_LOGIN_PASSWORD,value); }
		}
		/// <summary>
		/// 用户消费密码
		/// [default:string.Empty]
		/// </summary>
		public string PaymentPassword
		{
			get { return DataRow[_PAYMENT_PASSWORD].ToString(); }
			set { setProperty(_PAYMENT_PASSWORD,value); }
		}
		/// <summary>
		/// 用户头像
		/// [default:string.Empty]
		/// </summary>
		public string PhotoUrl
		{
			get { return DataRow[_PHOTO_URL].ToString(); }
			set { setProperty(_PHOTO_URL,value); }
		}
		/// <summary>
		/// 数据来源
		/// [default:0]
		/// </summary>
		public int DataSource
		{
			get { return Convert.ToInt32(DataRow[_DATA_SOURCE]); }
			set { setProperty(_DATA_SOURCE,value); }
		}
		/// <summary>
		/// 备注信息
		/// [default:string.Empty]
		/// </summary>
		public string Remarks
		{
			get { return DataRow[_REMARKS].ToString(); }
			set { setProperty(_REMARKS,value); }
		}
		/// <summary>
		/// 录入时间
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
			dt.Columns.Add(_USER_ID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_USER_CODE, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_USER_NICKNAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_USER_NAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_FATHER_ID, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_USER_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_USER_LEVEL, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_E_MAIL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_MOBILE_NO, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_AUTH_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_AUTH_TIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_LOGIN_PASSWORD, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_PAYMENT_PASSWORD, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_PHOTO_URL, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_DATA_SOURCE, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_REMARKS, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_CREATE_TIME, typeof(DateTime)).DefaultValue = new DateTime();

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TNET_USER WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int userId)
        {
            string condition = "USER_ID=:USER_ID";
            AddParameter(_USER_ID, userId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "USER_ID=:USER_ID";
            AddParameter(_USER_ID, UserId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			UserId=base.GetSequence("SELECT SEQ_TNET_USER.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TNET_USER(
  USER_ID,
  USER_CODE,
  USER_NICKNAME,
  USER_NAME,
  FATHER_ID,
  USER_STATUS,
  USER_LEVEL,
  E_MAIL,
  MOBILE_NO,
  AUTH_STATUS,
  AUTH_TIME,
  LOGIN_PASSWORD,
  PAYMENT_PASSWORD,
  PHOTO_URL,
  DATA_SOURCE,
  REMARKS)
VALUES(
  :USER_ID,
  :USER_CODE,
  :USER_NICKNAME,
  :USER_NAME,
  :FATHER_ID,
  :USER_STATUS,
  :USER_LEVEL,
  :E_MAIL,
  :MOBILE_NO,
  :AUTH_STATUS,
  :AUTH_TIME,
  :LOGIN_PASSWORD,
  :PAYMENT_PASSWORD,
  :PHOTO_URL,
  :DATA_SOURCE,
  :REMARKS)";
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_USER_CODE,DataRow[_USER_CODE]);
			AddParameter(_USER_NICKNAME,DataRow[_USER_NICKNAME]);
			AddParameter(_USER_NAME,DataRow[_USER_NAME]);
			AddParameter(_FATHER_ID,DataRow[_FATHER_ID]);
			AddParameter(_USER_STATUS,DataRow[_USER_STATUS]);
			AddParameter(_USER_LEVEL,DataRow[_USER_LEVEL]);
			AddParameter(_E_MAIL,DataRow[_E_MAIL]);
			AddParameter(_MOBILE_NO,DataRow[_MOBILE_NO]);
			AddParameter(_AUTH_STATUS,DataRow[_AUTH_STATUS]);
			AddParameter(_AUTH_TIME,DataRow[_AUTH_TIME]);
			AddParameter(_LOGIN_PASSWORD,DataRow[_LOGIN_PASSWORD]);
			AddParameter(_PAYMENT_PASSWORD,DataRow[_PAYMENT_PASSWORD]);
			AddParameter(_PHOTO_URL,DataRow[_PHOTO_URL]);
			AddParameter(_DATA_SOURCE,DataRow[_DATA_SOURCE]);
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
            ChangePropertys.Remove(_USER_ID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_USER SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE USER_ID=:USER_ID");
            AddParameter(_USER_ID, DataRow[_USER_ID]);
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
  USER_ID,
  USER_CODE,
  USER_NICKNAME,
  USER_NAME,
  FATHER_ID,
  USER_STATUS,
  USER_LEVEL,
  E_MAIL,
  MOBILE_NO,
  AUTH_STATUS,
  AUTH_TIME,
  LOGIN_PASSWORD,
  PAYMENT_PASSWORD,
  PHOTO_URL,
  DATA_SOURCE,
  REMARKS,
  CREATE_TIME
FROM TNET_USER
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int userId)
        {
            string condition = "USER_ID=:USER_ID";
            AddParameter(_USER_ID, userId);
            return SelectByCondition(condition);
        }

		public bool SelectByUserCode(string userCode)
		{
			string condition = "USER_CODE=:USER_CODE";
			AddParameter("USER_CODE",userCode);
			return SelectByCondition(condition);
		}
		public bool SelectByEMail(string eMail)
		{
			string condition = "E_MAIL=:E_MAIL";
			AddParameter("E_MAIL",eMail);
			return SelectByCondition(condition);
		}
		public bool SelectByMobileNo(string mobileNo)
		{
			string condition = "MOBILE_NO=:MOBILE_NO";
			AddParameter("MOBILE_NO",mobileNo);
			return SelectByCondition(condition);
		}


        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tnet_User
    /// </summary>
    public partial class Tnet_UserCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tnet_UserCollection() { }

        public Tnet_UserCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_User(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tnet_User().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tnet_User._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  USER_ID,
  USER_CODE,
  USER_NICKNAME,
  USER_NAME,
  FATHER_ID,
  USER_STATUS,
  USER_LEVEL,
  E_MAIL,
  MOBILE_NO,
  AUTH_STATUS,
  AUTH_TIME,
  LOGIN_PASSWORD,
  PAYMENT_PASSWORD,
  PHOTO_URL,
  DATA_SOURCE,
  REMARKS,
  CREATE_TIME
FROM TNET_USER
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByUserId(int userId)
        {
            string condition = "USER_ID=:USER_ID";
            AddParameter(Tnet_User._USER_ID, userId);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNET_USER WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tnet_User this[int index]
        {
            get
            {
                return new Tnet_User(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tnet_User Find(Predicate<Tnet_User> match)
        {
            foreach (Tnet_User item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_UserCollection FindAll(Predicate<Tnet_User> match)
        {
            Tnet_UserCollection list = new Tnet_UserCollection();
            foreach (Tnet_User item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_User> match)
        {
            foreach (Tnet_User item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tnet_User> match)
        {
            BeginTransaction();
            foreach (Tnet_User item in this)
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