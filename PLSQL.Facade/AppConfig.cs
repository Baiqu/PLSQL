using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;

namespace Winner.PLSQL.Facade
{
    public class AppConfig
    {
        public static string InjectionWord = ConfigProvider.GetAppSetting("InjectionWord");
        public static string TableFilter = ConfigProvider.GetAppSetting("TableFilter");
    }
}
