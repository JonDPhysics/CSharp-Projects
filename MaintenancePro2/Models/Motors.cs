using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MaintenancePro2.Models
{
    public class Motor
    {
        [Key]
        public int motorID { get; set; }

        [Display(Name = "Year: ")]
        [Required(ErrorMessage = "Year of vehicle needed.")]
        public int year { get; set; }

        [Display(Name = "Make: ")]
        [Required(ErrorMessage = "Make of vehicle needed.")]
        public string make { get; set; }

        [Display(Name = "Model: ")]
        [Required(ErrorMessage = "Model of vehicle needed.")]
        public string model { get; set; }

        [Display(Name = "Hours: ")]
        [Required(ErrorMessage = "Hours of vehicle needed.")]
        public float hours { get; set; }

        public DateTime createdat { get; set; } = DateTime.Now;
        public DateTime updatedat { get; set; } = DateTime.Now;
        public List<MaintenanceItem> motorItems { get; set; }
    }
}