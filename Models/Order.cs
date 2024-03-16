using System;
using System.ComponentModel.DataAnnotations;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Order
    {
        [Key]
        public int Order_ID { get; set; }

        [Display(Name = "Customer ID")]
        public int Customer_ID { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        // Navigation property for the Customer model
        [Display(Name = "Customer")]
        public  Customer? Customer { get; set; }
    }
}
