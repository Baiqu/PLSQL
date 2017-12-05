using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Controllers;
using Winner.PLSQL.DataAccess;
using Winner.Framework.Utils;
using PLSQL.Models;
using Winner.Framework.MVC;
using Winner.PLSQL.Facade;

namespace PLSQL.Controllers
{
    [AuthLogin]
    public class SQLManagerController : TopControllerBase
    {
        // GET: SQLManager
        public ActionResult Index()
        {
            Tsql_ClassifyCollection daClassifyColl = new Tsql_ClassifyCollection();
            daClassifyColl.SelectClassify();
            List<Classify> classifyList = MapProvider.Map<Classify>(daClassifyColl.DataTable);
            ViewBag.JsonClassify = JsonProvider.ToJson(classifyList);
            return View();
        }

        [HttpPost]
        public JsonResult Index(FormCollection form)
        {
            if (SysUser == null)
            {
                return FailResult("未登录状态");
            }
            string ViewName = form["ViewName"].Safe().ToString();
            int ClassifyId = form["ClassifyId"].Safe().ToInt32();
            string UserName = form["UserName"].Safe().ToString();
            int pageSize = form["PageSize"].Safe().ToInt32();
            int pageIndex = form["PageIndex"].Safe().ToInt32();
            Tsql_ViewCollection daViewColl = new Tsql_ViewCollection();
            daViewColl.ChangePage = this.ChangePage(pageIndex, pageSize);
            daViewColl.GetAllViewByClassifyAndUserName(ViewName, ClassifyId, UserName);
            List<VManagerModel> vModel = MapProvider.Map<VManagerModel>(daViewColl.DataTable);
            return SuccessResultList(vModel, daViewColl.ChangePage);
        }

        [HttpPost]
        public JsonResult DeleteView(int id)
        {
            ViewFacade daView = new ViewFacade();
            if (!daView.DeleteView(id))
                return FailResult("删除失败，请检查ID是否合法");
            return SuccessResult();
        }

        [HttpPost]
        public JsonResult UpdateCacheType(int ID, int Cache)
        {
            ViewFacade daView = new ViewFacade();
            if (!daView.UpadateCache(ID, Cache))
                return FailResult("修改缓存状态失败，请检查ID是否合法");
            return SuccessResult();
        }
    }
}