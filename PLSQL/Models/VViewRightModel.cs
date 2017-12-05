using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLSQL.Models
{
    public class VViewRightModel
    {
        public int ID { get; set; }
        public int VIEW_ID { get; set; }
        public int OWNER_ID { get; set; }
        public DateTime AUTH_TIME { get; set; }
        public string AuthTime { get { return AUTH_TIME.ToString("yyyy-MM-dd"); } }
        public DateTime TIMEOUT { get; set; }
        public string TimeOut { get { return TIMEOUT.ToString("yyyy-MM-dd"); } }
        public string USER_CODE { get; set; }
        public string USER_NAME { get; set; }
    }
}