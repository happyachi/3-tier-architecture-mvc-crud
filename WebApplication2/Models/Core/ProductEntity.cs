using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Core
{
        /// <summary>
        ///  Entity 可以說是系統的最核心物件，他要負的責任是"他必須自己確保裡面各屬性質都是合理的"
        ///  Entity 裡，通常也會有method ，不像dto沒method 
        ///  其次，最好也是"不可變的" (new 出來之後，各屬性都是唯讀)
        /// </summary>
    public class ProductEntity
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }
       
        public string Description { get; set; }

        public int Price { get; set; }

        public bool Status { get; set; }
        
        public string ProductImage { get; set; }

        public int Stock { get; set; }

    }
}