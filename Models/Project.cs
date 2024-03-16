using System.ComponentModel.DataAnnotations;

namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    public class Project
    {
        [Key]
        public int Project_ID { get; set; }

        [Display(Name = "Project Name")]
        public string Project_Name { get; set; }

        [Display(Name = "Duration")]
        public int Duration { get; set; } // Could be a TimeSpan depending on your needs
    }
}
