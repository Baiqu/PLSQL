using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winner.PLSQL.Entities;

namespace PLSQL.Models
{
    public class VViewModel
    {
        public List<Classify> classifylist { get; set; }
        public int VIEW_ID { get; set; }
        public string VIEW_NAME { get; set; }
        public int CLASSIFY_ID { get; set; }
        public string COMMAND_TEXT { get; set; }
        public string VIEW_TEMPLATE { get; set; }
        public int CACHE_STATUS { get; set; }
        public int PAGE_ROW { get; set; }
        public int STATUS { get; set; }
        public string INPUTER { get; set; }
        public string REMARKS { get; set; }

    }
    public class Classify
    {
        public int ClassifyId { get; set; }
        public string ClassifyName { get; set; }
    }
}