using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        
        [Required]
        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100), MinLength(6)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Phone]
        public string PhoneNumber { get; set; }

        public bool IsManager { get; set; }

        public bool IsTerminated { get; set; }

        //public virtual ICollection<TimeEntry> TimeEntries { get; set; }

        public virtual List<TimeEntry> TimeEntries { get; set; }

    }
}
