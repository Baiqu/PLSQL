using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Winner.Framework.Utils;

namespace PLSQL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Winner.Framework.MVC.ProviderManager.RegisterAccountProvider(new Winner.Platform.MVC.Provider.AccountProvider());
            Winner.Framework.MVC.ProviderManager.RegisterRightProvider(new Winner.Platform.MVC.Provider.RightProvider());
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            Log.Error(ex); //记录日志信息  
        }
    }
}
