using System.ComponentModel.DataAnnotations;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Role
    {
        [Key]
        public int Role_ID { get; set; }

        [Display(Name = "Role Name")]
        public string Role_Name { get; set; } // Renamed "Role" for clarity
    }
}
