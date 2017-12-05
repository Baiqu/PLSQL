using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLSQL.Models
{
    public class ViewModel
    {
        [Required(ErrorMessage = "{0}不可为空")]
        [Display(Name = "视图名称")]
        public string VIEW_NAME { get; set; }

        [Required(ErrorMessage = "{0}不可为空")]
        [Display(Name = "类别ID")]
        public int CLASSIFY_ID { get; set; }

        [Required(ErrorMessage = "{0}不可为空")]
        [Display(Name = "SQL命令")]
        public string COMMAND_TEXT { get; set; }

        [Required(ErrorMessage = "请至少选择一种视图模板")]
        public string VIEW_TEMPLATE { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "缓存状态")]
        public int CACHE_STATUS { get; set; }

        [Required(ErrorMessage = "{0}不可为空")]
        [Display(Name = "默认每页行数")]
        public int PAGE_ROW { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "状态")]
        public int STATUS { get; set; }

        [Required(ErrorMessage = "{0}不可为空")]
        [Display(Name = "信息录入人员")]
        public string INPUTER { get; set; }
        public string REMARKS { get; set; }
    }
}