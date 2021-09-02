using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sample_Test_MVC.Models
{
    public class Current
    {
        [Display(Name = "Future Value")]
        public string LabelCurrentValue { get; set; }
        public int CurrentValue { get; set; }

    }
}