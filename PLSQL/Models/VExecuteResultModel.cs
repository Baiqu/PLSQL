using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLSQL.Models
{
    public class VExecuteResultModel
    {
        public string VIEW_NAME { get; set; }
        public string COMMAND_TEXT { get; set; }
        public int PAGE_ROW { get; set; }
        public string REMARKS { get; set; }
        public string TableHtml{ get; set; }
    }
}