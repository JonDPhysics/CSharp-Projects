using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MaintenancePro2.Models
{
    public class IndexView
    {
        public List<Motor> AllMotors { get; set;}
        public List<MaintenanceItem> AllItems { get; set; }
        public List<PreformedItem> AllPerformedItems { get; set; }
        public int AMotorID { get; set; }
    }
}