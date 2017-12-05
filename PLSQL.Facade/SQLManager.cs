using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Winner.PLSQL.DataAccess;
using Winner.Framework.Utils;
using Winner.Framework.Core.Facade;

namespace Winner.PLSQL.Facade
{
    public class SQLManager : FacadeBase
    {
        /// <summary>
        /// 是否参数化
        /// </summary>
        /// <returns></returns>
        public static bool IsParameter(string sqlcontent, out string sql)
        {
            const string pattern = @"#((.|\n)*?)#";
            const string replaceStr = "1=1";
            Regex rgx = new Regex(pattern);
            sql = Regex.Replace(sqlcontent, pattern, replaceStr);
            return rgx.IsMatch(sqlcontent);
        }

        /// <summary>
        /// 是否sql注入
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool IsInjection(string sql)
        {
            string str = Winner.PLSQL.Facade.AppConfig.InjectionWord;
            string tables = Winner.PLSQL.Facade.AppConfig.TableFilter;
            bool hasWord = string.IsNullOrEmpty(str);
            string injectionWord = hasWord ? AppConfig.InjectionWord : str;
            injectionWord += AppConfig.TableFilter;
            string[] injection = injectionWord.Split('|');
            foreach (string word in injection)
            {
                Regex regex = new Regex(@"((^|\s+)" + word + @")(\s+|$)", RegexOptions.IgnoreCase);
                if (regex.IsMatch(sql))
                {
                    if (word.ToUpper() == "TNET_REGINFO")//TBLC_CENTCARD
                    {
                        Alert("不要直接查询TNET_REGINFO用户表，请使用VNET_REGINFO视图");
                        return false;
                    }
                    else if (word.ToUpper() == "TBLC_CENTCARD")
                    {
                        Alert("不要直接查询TBLC_CENTCARD表，请使用VBLC_CENTCARD视图");
                        return false;
                    }else if (word.ToUpper() == "TNET_USER")
                    {
                        Alert("不要直接查询TNET_USER用户表，请使用VNET_USER视图");
                        return false;
                    }
                    else
                    {
                        Alert("存在可疑字符串:" + word);
                        return false;
                    }
                }
            }
            return IsSqlCorrect(sql);
        }

        public bool IsSqlCorrect(string sql)
        {
            try
            {
                if (sql.Substring(0, sql.Length - 1) == ";")
                    sql = sql.Substring(0, sql.Length - 1);
                Tsql_ViewCollection daSqlColl = new Tsql_ViewCollection();
                if (daSqlColl.ExecuteQuery(sql))
                {
                    Alert("没有问题");
                    return true;
                }else
                {
                    Alert("SQL语句有错误:"+daSqlColl.PromptInfo.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Alert("SQL语句有错误," + ex.Message);
                return false;
            }
        }

        public bool IsCorrect(string sqlContent)
        {
            if (string.IsNullOrEmpty(sqlContent))
            {
                Alert("SQL不能为空");
                return false;
            }
            while (true)
            {
                if (sqlContent.Substring(sqlContent.Length - 1, 1) == ";")
                    sqlContent = sqlContent.Substring(0, sqlContent.Length - 1);
                else
                    break;
            }

            //是否参数化
            IsParameter(sqlContent, out sqlContent);
            if (IsInjection(sqlContent))
            {
                Alert("没有问题");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExists(string title)
        {
            Tsql_View daSql = new Tsql_View();
            if (string.IsNullOrEmpty(title))
                return false;
            if (daSql.IsExistTitle(title))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取要动态创建的控件name
        /// </summary>
        /// <param name="sqlcontent"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        public bool GetParameterControl(string sqlcontent, ref Dictionary<string, string> controlName)
        {
            const string pattern = @"#((.|\n)*?)#";
            const string pattern2 = @":(\W*\w*)";
            Regex rgx = new Regex(pattern);
            if (!rgx.IsMatch(sqlcontent))
                return false;
            foreach (var key in rgx.Matches(sqlcontent))
            {
                string strKey = key.ToString();
                Regex regex2 = new Regex(pattern2);

                string strValue = regex2.Matches(key.ToString())[0].Groups[1].Value;
                controlName.Add(strKey, strValue);
            }
            return true;
        }

        public Dictionary<string,string> GetparameterWhere(string sqlcontent)
        {
            Dictionary<string, string> controlName = new Dictionary<string, string>();
            const string pattern = @"#((.|\n)*?)#";
            const string pattern2 = @":(\W*\w*)";
            Regex rgx = new Regex(pattern);
            if (!rgx.IsMatch(sqlcontent))
                return controlName;
            foreach (var key in rgx.Matches(sqlcontent))
            {
                string strKey = key.ToString();
                Regex regex2 = new Regex(pattern2);

                string strValue = regex2.Matches(key.ToString())[0].Groups[1].Value;
                controlName.Add(strKey, strValue);
            }
            return controlName;
        }
    }
}
