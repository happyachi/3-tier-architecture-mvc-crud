using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModels
{
    public class ProductIndexVm
    {
        public int Id { get; set; }

        [Display(Name="品名")]
        public string Name { get; set; }

        [Display(Name = "售價")]
        public int Price { get; set; }

        [Display(Name = "分類")]
        public string CategoryName { get; set; }

    }

}