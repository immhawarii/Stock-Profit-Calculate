using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sample_Test_MVC.Models
{
    public class Future
    {
        [Display(Name = "Future Value")]
        public string LabelFutureValue { get; set; }
        public int FutureValue { get; set; }        
    }
}