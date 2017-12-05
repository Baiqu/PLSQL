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
    public class BindingController : TopControllerBase
    {
        // GET: Binding
        public ActionResult Index(int ViewId)
        {
            Tsql_View daview = new Tsql_View();
            daview.SelectView(ViewId);

            ViewBag.ViewId = ViewId;
            ViewBag.ViewName = daview.ViewName;
            return View();
        }

        [HttpPost]
        public JsonResult Index(FormCollection form)
        {
            int ViewId = form["ViewId"].Safe().ToInt32();
            Tsql_View_RightCollection daViewRight = new Tsql_View_RightCollection();
            daViewRight.ChangePage = this.ChangePage();
            daViewRight.GetViewRightByViewId(ViewId);
            List<VViewRightModel> list = MapProvider.Map<VViewRightModel>(daViewRight.DataTable);
            ViewBag.ViewId = ViewId;
            return SuccessResultList(list, daViewRight.ChangePage);
        }

        #region 添加绑定
        [HttpPost]
        public JsonResult AddViewRight(int ViewId, DateTime StartTime,DateTime EndTime,string UserCode)
        {
            Tnet_User daUser = new Tnet_User();
            if(daUser.SelectUserCode(UserCode))
            {
                Tsql_View_Right daViewRight = new Tsql_View_Right()
                {
                    ViewId = ViewId,
                    OwnerType = daUser.UserLevel,
                    OwnerId = daUser.UserId,
                    AuthTime = StartTime,
                    Timeout = EndTime
                };
                if (daViewRight.Verification(daUser.UserId,ViewId))
                {
                    return FailResult("该用户已绑定，请勿重复绑定");
                }
                if (!daViewRight.Insert())
                {
                    return FailResult(daViewRight.PromptInfo.Message);
                }
            }else
            {
                return FailResult("该用户不存在");
            }
            return SuccessResult();
        }
        #endregion

        [HttpPost]
        public JsonResult DeleteViewRight(int id)
        {
            Tsql_View_Right daViewRight = new Tsql_View_Right();
            if (!daViewRight.Delete(id))
                return FailResult(daViewRight.PromptInfo.Message);
            return SuccessResult();
        }
    }
}