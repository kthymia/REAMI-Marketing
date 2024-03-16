using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Installation_Detail
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Installation ID")]
        public int Installation_ID { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Employee ID")]
        public int Employee_ID { get; set; }

        [Key, Column(Order = 2)]
        [Display(Name = "Role ID")]
        public int Role_ID { get; set; }

        // Navigation properties
        [Display(Name = "Employee")]
        public Employee? Employee { get; set; }

        [Display(Name = "Role")]
        public Role? Role { get; set; }
    }
}
