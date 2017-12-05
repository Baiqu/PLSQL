using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Controllers;
using Winner.PLSQL.DataAccess;
using Winner.Framework.Utils;
using Winner.Framework.MVC;
using PLSQL.Models;
using Winner.PLSQL.Facade;

namespace PLSQL.Controllers
{
    [AuthLogin]
    public class ClassifyController : TopControllerBase
    {
        // GET: Classify
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(FormCollection form)
        {
            Tsql_ClassifyCollection daClassifyColl = new Tsql_ClassifyCollection();
            daClassifyColl.ChangePage = this.ChangePage();
            daClassifyColl.SelectClassify();
            List<VclassifyModel> list = MapProvider.Map<VclassifyModel>(daClassifyColl.DataTable);
            return SuccessResultList(list,daClassifyColl.ChangePage);
        }

        [HttpPost]
        public JsonResult AddClassify(string ClassifyName)
        {
            Tsql_Classify daClassify = new Tsql_Classify()
            {
                ClassifyName = ClassifyName,
                ParentId = 0,
                Status = 1
            };
            if (daClassify.Verificationtitle(ClassifyName))
            {
                return FailResult("该类名已存在");
            }
            if (!daClassify.Insert())
                return FailResult(daClassify.PromptInfo.Message);
            return SuccessResult();
        }

        [HttpPost]
        public JsonResult UpdateClassify(int classifyId,string classifyName)
        {
            Tsql_Classify daClassify = new Tsql_Classify();
            daClassify.SelectByClassifyId(classifyId);
            daClassify.ClassifyName = classifyName;
            if (!daClassify.Update())
                return FailResult(daClassify.PromptInfo.Message);
            return SuccessResult();
        }

        [HttpPost]
        public JsonResult DeleteClassify(int classifyId)
        {
            ClassifyFacade classifyFacade = new ClassifyFacade();
            //逻辑删除
            classifyFacade.DeleteClassify(classifyId);
            return SuccessResult();
        }
    }
}