using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MaintenancePro2.Models
{
    public class MaintenanceItem
    {
        [Key]
        public int itemID { get; set; }

        [Display(Name = "Item: ")]
        [Required(ErrorMessage = "Item required.")]
        public string item { get; set; }

        [Display(Name = "Note: ")]
        public string note { get; set; }

        [Display(Name = "Interval: ")]
        [Required(ErrorMessage = "Interval required.")]
        public float interval { get; set; }

        [Display(Name = "Action: ")]
        [Required(ErrorMessage = "Action required.")]
        public string action { get; set; }

        public  int MotorID { get; set; }

        public DateTime createdat { get; set; } = DateTime.Now;
        public DateTime updatedat { get; set; } = DateTime.Now;

        public Motor Bike { get; set; }
        [NotMapped]
        public List<Motor> MotorList { get; set; }
    }
}