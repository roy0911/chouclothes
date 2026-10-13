using System.ComponentModel.DataAnnotations;

namespace chouclothes.Models
{
    public class ClothingItem
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "服飾名稱")]
        [Required(ErrorMessage = "請輸入服飾名稱")]
        public string Name { get; set; }

        [Display(Name = "服飾種類")]
        // 例如：上衣、外套、褲子、裙子、配件
        public string Category { get; set; }

        [Display(Name = "尺寸")]
        // 例如：S, M, L, XL, F(均碼)
        public string Size { get; set; }

        [Display(Name = "價格 (元)")]
        public int Price { get; set; }

        [Display(Name = "庫存數量")]
        public int StockQuantity { get; set; }
    }
}