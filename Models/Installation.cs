using System.ComponentModel.DataAnnotations;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Installation
    {
        [Key]
        public int Installation_ID { get; set; }

        [Display(Name = "Project ID")]
        public int Project_ID { get; set; }

        [Display(Name = "Order ID")]
        public int Order_ID { get; set; }

        // Navigation properties
        [Display(Name = "Project")]
        public virtual Project? Project { get; set; }

        [Display(Name = "Order")]
        public virtual Order? Order { get; set; }
    }
}
