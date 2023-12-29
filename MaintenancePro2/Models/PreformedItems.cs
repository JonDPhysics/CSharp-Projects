using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MaintenancePro2.Models
{
    public class PreformedItem
    {
        [Key]
        public int preformedID { get; set; }

        [Display(Name = "Hours Performed At: ")]
        [Required(ErrorMessage = "Hours preformed at required.")]
        public float hpa { get; set; }

        [Display(Name = "Date Performed At: ")]
        [Required(ErrorMessage = "Date preformed at required.")]
        public DateTime dpa { get; set; }

        public int ItemID { get; set; }
        public int MotorID {get; set;}

        public DateTime createdat { get; set; } = DateTime.Now;
        public DateTime updatedat { get; set; } = DateTime.Now;

        public MaintenanceItem Item { get; set; }
        [NotMapped]
        public List<MaintenanceItem> ItemList { get; set; }
        [NotMapped]
        public List<Motor> MotorList {get; set;}
        

    }
}