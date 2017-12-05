using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Controllers;
using PLSQL.Models;
using System.Text.RegularExpressions;
using Winner.PLSQL.DataAccess;
using Winner.Framework.Utils;
using Winner.Framework.MVC;
using Winner.PLSQL.Facade;

namespace PLSQL.Controllers
{
    [AuthLogin]
    public class UseSQLController : TopControllerBase
    {
        SQLManager sqlManager = new SQLManager();
        // GET: UseSQL
        public ActionResult Index(int? SQLId)
        {
            if (SQLId > 0)
                ViewBag.SQLID = SQLId;
            else
                ViewBag.SQLID = 0;
            Tsql_ClassifyCollection daclassifyColl = new Tsql_ClassifyCollection();
            VViewModel vModel = new VViewModel();
            vModel.classifylist = new List<Classify>();
            daclassifyColl.SelectClassify();
            List<Classify> list = MapProvider.Map<Classify>(daclassifyColl.DataTable);
            foreach (var item in list)
            {
                vModel.classifylist.Add(item);
            }
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

        #region 添加SQL信息
        /// <summary>
        /// 添加SQL信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddSql(ViewModel model)
        {
            if (SysUser != null)
                model.INPUTER = SysUser.UserCode;
            else
                return FailResult("未登录状态");
            var verifymodel = ModelVerify.First(model);
            if (verifymodel != null)
            {
                return FailResult(verifymodel.ErrorMessage);
            }
            if (model.COMMAND_TEXT.Length > 2000)
            {
                return FailResult("该SQL超出长度");
            }
            if (!string.IsNullOrEmpty(model.VIEW_NAME))
            {
                if (sqlManager.IsExists(model.VIEW_NAME))
                {
                    return FailResult("标题已存在，不可用");
                }
            }
            if(!sqlManager.IsCorrect(model.COMMAND_TEXT))
            {
                return FailResult(sqlManager.PromptInfo.Message);
            }

            Tsql_View daView = new Tsql_View()
            {
                ViewName = model.VIEW_NAME,
                ClassifyId = model.CLASSIFY_ID,
                CommandText = model.COMMAND_TEXT,
                ViewTemplate = model.VIEW_TEMPLATE,
                CacheStatus = model.CACHE_STATUS,
                PageRow = model.PAGE_ROW,
                Status = 1,
                Inputer = model.INPUTER,
                Remarks = model.REMARKS,
            };
            if (!daView.Insert())
            {
                return FailResult(daView.PromptInfo.Message);
            }else
            {
                //添加删除缓存数据
                ViewFacade viewfacade = new ViewFacade();
                viewfacade.AddOrUpdateCache(daView.ViewId, Convert.ToInt32(daView.CacheStatus), Isparameter(daView.CommandText));
            }
            return SuccessResult();
        }
        #endregion

        #region 修改SQL信息
        [HttpPost]
        public JsonResult UpdateSql(VViewModel vModel)
        {
            if (SysUser == null)
                FailResult("未登录状态");
            if (!sqlManager.IsCorrect(vModel.COMMAND_TEXT))
            {
                return FailResult(sqlManager.PromptInfo.Message);
            }
            Tsql_View daview = new Tsql_View();
            daview.SelectByPK(vModel.VIEW_ID);
            daview.ViewName = vModel.VIEW_NAME;
            daview.ClassifyId = vModel.CLASSIFY_ID;
            daview.CommandText= vModel.COMMAND_TEXT;
            daview.ViewTemplate= vModel.VIEW_TEMPLATE;
            daview.CacheStatus= vModel.CACHE_STATUS;
            daview.PageRow= vModel.PAGE_ROW;
            daview.Status= 1;
            daview.Remarks = vModel.REMARKS;
            if (!daview.Update())
            {
                return FailResult(daview.PromptInfo.Message);
            }else
            {
                ViewFacade viewfacade = new ViewFacade();
                viewfacade.AddOrUpdateCache(daview.ViewId, Convert.ToInt32(daview.CacheStatus), Isparameter(daview.CommandText));
            }
            return SuccessResult();
        }
        #endregion

        #region 验证SQL是否可用
        /// <summary>
        /// 验证SQL是否可用
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="SQL"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult VerificationSQL(string Title, string SQL, bool isUpdate)
        {
            if (SQL.Length > 2000)
            {
                return FailResult("该SQL超出长度");
            }
            if (!string.IsNullOrEmpty(Title) && !isUpdate)
            {
                if (sqlManager.IsExists(Title))
                {
                    return FailResult("标题已存在，不可用");
                }
            }
            if (!sqlManager.IsCorrect(SQL))
            {
                return FailResult(sqlManager.PromptInfo.Message);
            }
            return SuccessResult();
        }
        #endregion

        #region 获取需要修改的SQL信息
        /// <summary>
        /// 获取需要修改的SQL信息
        /// </summary>
        /// <param name="SQLId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetSQLInfo(int SQLId)
        {
            if (SQLId < 1)
                return FailResult("SQLId不合法");
            VViewModel vModel = new VViewModel();
            //获取分类列表
            Tsql_ClassifyCollection daclassifyColl = new Tsql_ClassifyCollection();
            daclassifyColl.SelectClassify();
            Tsql_View daview = new Tsql_View();
            daview.SelectSQLBySqlId(SQLId);
            vModel = MapProvider.Map<VViewModel>(daview.DataRow);
            List<Classify> list = new List<Classify>();
            list = MapProvider.Map<Classify>(daclassifyColl.DataTable);
            vModel.classifylist = new List<Classify>();
            foreach (var item in list)
            {
                vModel.classifylist.Add(item);
            }
            return SuccessResult(vModel);
        }
        #endregion
    }
}