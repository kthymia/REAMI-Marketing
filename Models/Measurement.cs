using System.ComponentModel.DataAnnotations;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Measurement
    {
        [Key]
        public int Measurement_ID { get; set; }

        [Display(Name = "Measurement Type")]
        public string Measurement_Type { get; set; } // Could be renamed to "Measurement" if it represents the type
    }
}
