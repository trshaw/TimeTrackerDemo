using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Models
{
    public class TimeEntry
    {
        [Key]
        public int ID { get; set; }
        
        //Foreign Key for Employee
        public int EmployeeID { get; set; }

        //Foreign Key for Project
        public int ProjectID { get; set; }

        public int TimeDuration { get; set; }
        public bool IsBillable { get; set; }
        public string Description { get; set; }

        //public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}