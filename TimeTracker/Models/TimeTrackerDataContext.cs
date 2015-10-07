using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TimeTracker.Models
{
    public class TimeTrackerDataContext : DbContext
    {
        public TimeTrackerDataContext() : base("name=TimeTrackerEntities")
        {
            Database.SetInitializer(new TimeTrackerDBInitializer());
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }
            
        
    }

}



