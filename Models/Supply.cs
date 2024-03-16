namespace REAMI_Marketing_Sales___Inventory_System.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Supply
    {
        [Key]
        public int Supply_ID { get; set; }

        [Display(Name = "Company ID")]
        public int Company_ID { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        // Navigation property
        [Display(Name = "Company")]
        public Company? Company { get; set; }
    }
}
