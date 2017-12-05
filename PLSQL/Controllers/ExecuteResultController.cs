using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.Utils;
using Winner.PLSQL.DataAccess;
using PLSQL.Models;
using Winner.PLSQL.Facade;
using System.Text.RegularExpressions;
using Winner.Framework.MVC;

namespace PLSQL.Controllers
{
    [AuthLogin]
    public class ExecuteResultController : TopControllerBase
    {
        protected static string _plsql, _yplsql, _plsqlname = string.Empty;
        protected static int _cachetype, _viewid = 0;
        protected static string order, orderby = "";
        private Dictionary<string, string> controlList;
        // GET: ExecuteResult
        public ActionResult Index(int ViewId)
        {
            string parameterSQL = string.Empty;
            VExecuteResultModel vModel = new VExecuteResultModel();
            Tsql_View daView = new Tsql_View();
            daView.SelectView(ViewId);
            _plsql = Isparameter(daView.CommandText);
            _yplsql = daView.CommandText;
            Tsql_ViewCollection daViewColl = new Tsql_ViewCollection();
            daViewColl.ListByALLPlSql(_plsql);

            ExecuteSQL SQLFacade = new ExecuteSQL();
            ViewBag.TableHtml = SQLFacade.CreateTable(daViewColl.DataTable);
            ViewBag.ViewName = daView.ViewName;
            ViewBag.Remarks = daView.Remarks;
            _viewid = ViewBag.ViewId = ViewId;
            _cachetype = ViewBag.Cache = daView.CacheStatus;
            _plsqlname = daView.ViewName;
            ViewBag.PageSize = daView.PageRow == 0 ? 50 : daView.PageRow;
            ViewBag.HeadSearch = CreateCondition(daView.CommandText);
            return View(vModel);
        }

        public string Isparameter(string sql)
        {
            const string pattern = @"#((.|\n)*?)#";
            const string replaceStr = "1=1";
            Regex rgx = new Regex(pattern);
            sql = Regex.Replace(sql, pattern, replaceStr);
            return System.Text.RegularExpressions.Regex.Replace(sql, @"\n", " ");
        }

        //头部查询
        private string CreateCondition(string sqlContent)
        {
            SQLManager sqlFasade = new SQLManager();
            controlList = new Dictionary<string, string>();
            if (!sqlFasade.GetParameterControl(sqlContent, ref controlList))
                return "";

            string strHtml = controlList.Aggregate(string.Empty, (current, val) => current + (" " + val.Value + "：<input type='text' id='tb_" + val.Value + "' name='" + val.Value + "' />"));
            strHtml += " <input type='button' class='btn btn-default' id='but_query' value='查询' />";
            return strHtml;
        }

        [HttpPost]
        public JsonResult TableHTML(FormCollection form)
        {
            Dictionary<string, string> searchStr = new Dictionary<string, string>();
            SQLManager sqlFacade = new SQLManager();
            string strsch = " 1=1";
            searchStr = sqlFacade.GetparameterWhere(_yplsql);
            foreach (var item in searchStr)
            {
                var val = form["" + item.Value + ""];
                if (val.ToString() != "")
                {
                    strsch += " AND " + item.Value + " = '" + form["" + item.Value + ""].ToString() + "'";
                    Session["strsch"] = string.Empty;
                }
            }
            Session["strsch"] = strsch;
            order = form["order"].Safe().ToString();
            orderby = form["orderby"].Safe().ToString();
            int iscache = form["iscache"].Safe().ToInt32();
            Tsql_ViewCollection daViewColl = new Tsql_ViewCollection();
            daViewColl.ChangePage = this.ChangePage();
            Tsql_View daView = new Tsql_View();
            if (_cachetype == 0)
            {
                daViewColl.ListByALLPlSqlByOrder(_plsql, order, orderby, strsch);
            }
            else
            {
                if (daView.IsExistTable(_viewid) && iscache == 0)
                {
                    string cachesql = "SELECT * FROM PLSQLCACHE_" + _viewid;
                    daViewColl.ListByALLPlSqlByOrder(cachesql, order, orderby, strsch);
                }
                else
                {
                    daViewColl.ListByALLPlSqlByOrder(_plsql, order, orderby, strsch);
                }
            }
            List<Object> vList = new List<object>();
            ExecuteSQL SQLFacade = new ExecuteSQL();
            vList = SQLFacade.TableTd(daViewColl.DataTable);
            return SuccessResultList(vList, daViewColl.ChangePage);
        }


        //导出Excel表格
        [Javirs.Common.MVC.MultiButton("ExcelExport"), HttpPost]
        public ActionResult ExcelExport()
        {
            Tsql_ViewCollection daViewColl = new Tsql_ViewCollection();
            //daViewColl.ListByALLPlSql(_plsql);
            daViewColl.ListByALLPlSqlByOrder(_plsql, order, orderby, Session["strsch"].ToString());

            var excel = new Javirs.Common.IO.Excel(daViewColl.DataTable);
            return excel.Export(string.Concat(_plsqlname, DateTime.Now.ToString("yyyyMMdd"), ".xls"));
        }

        #region 控制表头名称跟字段名称
        //Javirs.Common.IO.ExcelCell excel_CellValueMapping(System.Data.DataRow row, string columnName)
        //{
        //    var cell = new Javirs.Common.IO.ExcelCell();
        //    if (columnName.Equals("PAYTYPE", StringComparison.OrdinalIgnoreCase))
        //    {
        //        PayType paytype = (PayType)Convert.ToInt32(row[columnName]);
        //        cell.Value = paytype.ToString();
        //    }

        //    if (columnName.Equals("STATUS", StringComparison.OrdinalIgnoreCase))
        //    {
        //        OrderStatus status = (OrderStatus)Convert.ToInt32(row[columnName]);
        //        cell.Value = status.ToString();
        //    }

        //    if (columnName.Equals("PAYERTYPE", StringComparison.OrdinalIgnoreCase))
        //    {
        //        PayerType status = (PayerType)Convert.ToInt32(row[columnName]);
        //        cell.Value = status.ToString();
        //    }

        //    return cell;
        //}

        //string excel_CellTitleMapping(System.Data.DataColumn arg)
        //{
        //    var map = new Dictionary<string, string>
        //    {
        //        {"ID","序列号" },
        //        {"CREATETIME","创建时间"},
        //        {"ORDERNUMBER","订单号"},
        //        {"STORE_NAME","商家名称"},
        //        {"STOREUSER","商户"},
        //        {"CASH_RATIO","商家返佣比例（%）"},
        //        {"PAYPRICE","付款金额"},
        //        {"RATE","结算费率"},
        //        {"FEE","手续费"},
        //        {"SETTLEMENT","清算金额"},
        //        {"USER_NAME","账户名称"},
        //        {"USER_CODE","帐号"},
        //        {"PAYERTYPE","通道类型"},
        //        {"PAYTYPE","发放状态"},
        //        {"STATUS","订单状态"}
        //    };
        //    string key = arg.ColumnName.ToUpper();
        //    if (map.ContainsKey(key))
        //    {
        //        return map[key];
        //    }
        //    return null;
        //}
        #endregion

    }
}