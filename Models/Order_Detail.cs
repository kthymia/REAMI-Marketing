namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Order_Detail
    {
        [Key]
        public int Order_Details_ID { get; set; }

        [Display(Name = "Order ID")]
        public int Order_ID { get; set; }

        [Display(Name = "Product ID")]
        public int Product_ID { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Unit")]
        public string Unit { get; set; }

        // Navigation properties
        [Display(Name = "Order")]
        public virtual Order? Order { get; set; }

        [Display(Name = "Product")]
        public virtual Product? Product { get; set; }
    }
}
