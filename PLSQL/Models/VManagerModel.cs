using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winner.PLSQL.Entities;

namespace PLSQL.Models
{
    public class VManagerModel
    {
        public int VIEW_ID { get; set; }
        public string VIEW_NAME { get; set; }
        public string CLASSIFY_NAME { get; set; }
        public int PAGE_ROW { get; set; }
        public string VIEW_TEMPLATE { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string CREATE_TIME_Show { get { return CREATE_TIME.ToString("yyyy-MM-dd HH:mm"); } }
        public CacheStatus CACHE_STATUS { get; set; }
        public string UserName { get; set; }
        public List<Classify> classifyList { get; set; }
    }
}