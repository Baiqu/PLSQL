using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.PLSQL.DataAccess;

namespace Winner.PLSQL.Facade
{
    public class ViewFacade
    {
        public bool DeleteView(int id)
        {
            Tsql_View daView = new Tsql_View();
            daView.SelectView(id);
            daView.Status = 0;
            if (daView.Update())
                return true;
            return false;
        }

        public bool UpadateCache(int id,int cache)
        {
            Tsql_View daView = new Tsql_View();
            daView.SelectView(id);
            daView.CacheStatus = cache;
            if (daView.Update())
                return true;
            return false;
        }

        public bool AddOrUpdateCache(int viewId,int cacheStatus,string sql)
        {
            Tsql_View daCache = new Tsql_View();
            if (cacheStatus == 1)
            {
                if (daCache.IsExistTable(viewId))
                {
                    daCache.DropCacheTable(viewId);
                }
                if (!daCache.CreateCacheTable(viewId, sql))
                {
                    return false;
                }
                return true;
            }
            else
            {
                if (daCache.IsExistTable(viewId))
                {
                    return daCache.DropCacheTable(viewId);
                }
                return true;
            }
        }
    }
}
