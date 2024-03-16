using System;
using System.ComponentModel.DataAnnotations;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }

        // Basic Information
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Display(Name = "Middle Name")]
        public string Middle_Name { get; set; } // Optional

        [Display(Name = "Date of Birth")]
        public DateTime Date_of_Birth { get; set; } // Optional

        // Contact Information
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone_Number { get; set; } // Optional

        [Display(Name = "Address")]
        public string Address { get; set; } // Optional

        // Additional Considerations
        [Display(Name = "Active Status")]
        public bool IsActive { get; set; } // Track active/inactive status
    }
}
