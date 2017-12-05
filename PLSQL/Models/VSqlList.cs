using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLSQL.Models
{
    public class VSqlList
    {
        public int VIEW_ID { get; set; }
        public string VIEW_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string CREATE_TIME_Show { get { return CREATE_TIME.ToString("yyyy-MM-dd HH:mm"); }  }
        public string USER_NAME { get; set; }
        public string REMARKS { get; set; }
    }
}