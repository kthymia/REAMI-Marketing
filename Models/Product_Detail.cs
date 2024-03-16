using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Product_Detail
    {
        [Key, Column(Order = 1)]
        [Display(Name = "Order Details ID")]
        public int Order_Details_ID { get; set; }

        [Key, Column(Order = 2)]
        [Display(Name = "Measurement ID")]
        public int Measurement_ID { get; set; }

        [Display(Name = "Value")]
        public string Value { get; set; }

        // Navigation property for Order_Details
        [Display(Name = "Order Details")]
        public virtual Order_Detail? OrderDetails { get; set; }

        // Navigation property for Measurement
        [Display(Name = "Measurement")]
        public virtual Measurement? Measurement { get; set; }
    }
}
