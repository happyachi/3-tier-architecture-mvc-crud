using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Dtos
{
    /// <summary>
    /// Dto 主要用來不同程式之間傳遞資訊，他不必負任何資料正確性的責任
    /// 其次，他通常只有 property ，沒有method
    /// </summary>
    public class ProductDto
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