using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.PLSQL.DataAccess;

namespace Winner.PLSQL.Facade
{
    public class ClassifyFacade
    {
        public bool DeleteClassify(int id)
        {
            Tsql_Classify daClassify = new Tsql_Classify();
            daClassify.SelectByClassifyId(id);
            daClassify.Status = 0;
            if (daClassify.Update())
                return true;
            return false;
        }
    }
}
