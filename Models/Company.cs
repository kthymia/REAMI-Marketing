using System.ComponentModel.DataAnnotations;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Company
    {
        [Key]
        public int Company_ID { get; set; }

        [Display(Name = "Company Name")]
        public string Company_Name { get; set; }

        [Display(Name = "Contact")]
        public string Contact { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
