using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.PLSQL.Entities
{
    public enum UserStatus
    {
        未激活 = 0,
        已激活 = 1,
        已注销 = 2,
        已封锁 = 3
    }
    public enum AuthStatus
    {
        未实名 = 0, 审核中 = 1, 实名认证 = 2
    }
}
