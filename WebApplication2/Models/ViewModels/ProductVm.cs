using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.ViewModels
{
    public class ProductVm
    {
        public int Id { get; set; }
        
        [Display(Name="分類名稱")]
        [Required(ErrorMessage ="{0}的名字必填")] //[厲害小功能!!]自動戴上面的欄位屬性名稱
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name="商品描述")]
        [Required(ErrorMessage ="{0}必填")]
        [StringLength(5,ErrorMessage="{0}長度不能超過 {1} 個字")]
        public string Description { get; set; }

        public int Price { get; set; }

        public bool Status { get; set; }

        [Required]
        [StringLength(70)]
        public string ProductImage { get; set; }

        public int Stock { get; set; }

    }

}