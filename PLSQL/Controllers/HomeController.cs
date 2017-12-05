using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Controllers;
using Winner.PLSQL.DataAccess;
using PLSQL.Models;
using Winner.Framework.Utils;
using Winner.Framework.MVC;

namespace PLSQL.Controllers
{
    [AuthLogin]
    public class HomeController : TopControllerBase
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(FormCollection form)
        {
            if (SysUser == null)
            {
                return FailResult("未登录状态");
            }
            string ViewName = form["ViewName"];
            int pageSize = form["PageSize"].Safe().ToInt32();
            int pageIndex = form["PageIndex"].Safe().ToInt32();
            Tsql_ViewCollection daViewColl = new Tsql_ViewCollection();
            daViewColl.ChangePage = this.ChangePage(pageIndex, pageSize);
            daViewColl.GetAllViewByUserInfo(SysUser.UserId, SysUser.UserCode,ViewName);
            List<VSqlList> List = new List<VSqlList>();
            List = MapProvider.Map<VSqlList>(daViewColl.DataTable);
            return SuccessResultList(List, daViewColl.ChangePage);
        }


        [AuthRight(true)]
        public ActionResult Right()
        {
            return View();
        }
    }
}