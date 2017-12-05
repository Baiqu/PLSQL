using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.PLSQL.DataAccess;
using System.Web.Security;
using System.Dynamic;
using System.Reflection;
using Winner.Framework.Utils;

namespace Winner.PLSQL.Facade
{
    public class ExecuteSQL
    {
        /// <summary>
        /// 创建Table标签
        /// </summary>
        /// <param name="table">数据</param>
        /// <returns></returns>
        public string CreateTable(DataTable table)
        {
            #region 创建头部
            StringBuilder html = new StringBuilder();
            html.Append(@"<table  class='table  table-bordered table-hover'><thead><tr>");

            foreach (DataColumn c in table.Columns)
            {
                html.AppendFormat("<th>{0}</th>", c.ColumnName);
            }

            html.Append("</tr></thead>");
            #endregion

            #region 创建行
            html.Append("<tbody data-bind='foreach:Data'>");
            foreach (DataColumn c in table.Columns)
            {
                html.AppendFormat(@"<td data-bind='html:{0},attr:{1}title:{0}{2}' class='subval_'></td>", c.ColumnName,"{","}");
            }
            html.Append("</tbody></table>");
            #endregion
            return html.ToString();
        }

        //public string CreateTable(DataTable table)
        //{
        //    #region 创建头部
        //    StringBuilder html = new StringBuilder();
        //    html.Append(@"<table  class='table  table-bordered table-hover'><thead><tr>");
        //    foreach (DataColumn c in table.Columns)
        //    {
        //        html.AppendFormat("<th>{0}</th>", c.ColumnName);
        //    }
        //    html.Append("</tr></thead>");
        //    #endregion
        //    #region 创建行
        //    foreach (DataRow row in table.Rows)
        //    {
        //        html.Append("<tbody><tr>");
        //        foreach (object o in row.ItemArray)
        //        {
        //            html.AppendFormat("<td>{0}</td>", o == null ? "" : o.ToString());
        //        }
        //        html.Append("</tr></tbody>");
        //    }
        //    html.Append("</table>");
        //    #endregion
        //    return html.ToString();
        //}



        /// <summary>
        /// 把DataTable数据转换成List泛型集合
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<object> TableTd(DataTable dt)
        {
            if (dt == null || dt.Columns.Count <= 0)
            {
                return null;
            }
            var list = new List<dynamic>();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            var json = JsonProvider.ToJson(parentRow);
            return JsonProvider.JsonTo<List<object>>(json);
        }
    }
}
