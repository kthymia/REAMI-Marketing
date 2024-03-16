using System.ComponentModel.DataAnnotations;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }

        [Display(Name = "Product Description")]
        public string Product_Desc { get; set; }

        [Display(Name = "Stocks Available")]
        public int Stocks_available { get; set; }

        [Display(Name = "Unit")]
        public string Unit { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
