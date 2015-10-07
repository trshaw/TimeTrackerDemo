using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(3),MinLength(3)]
        public string ProjectCode { get; set; }

        [Required]
        public string ProjectName { get; set; }

        //public virtual ICollection<TimeEntry> TimeEntries { get; set; }

        //public virtual List<TimeEntry> TimeEntries { get; set; }

    }
}