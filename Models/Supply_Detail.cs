using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Supply_Detail
    {
        [Key]
        [Column(Order = 1)]
        [Display(Name = "Supply ID")]
        public int Supply_ID { get; set; }

        [Column(Order = 2)]
        [Display(Name = "Product ID")]
        public int Product_ID { get; set; }

        [Display(Name = "Quantity Supplied")]
        public int Quantity_Supplied { get; set; } // Renamed "Qty. Supply" for clarity

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Column(Order = 3)]
        [Display(Name = "Unit")]
        public string Unit { get; set; }

        // Navigation property
        public virtual Product? Product { get; set; }
    }
}
