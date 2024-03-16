using System.ComponentModel.DataAnnotations;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Customer
    {
        [Key]
        public int Customer_ID { get; set; }

        [Display(Name = "Customer Name")]
        public string Customer_Name { get; set; }

        [Display(Name = "Contact")]
        public string Customer_Contact { get; set; }

        [Display(Name = "Location")]
        public string Customer_Location { get; set; }
    }
}
