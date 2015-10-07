using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TimeTracker.Models
{
    public class TimeTrackerDBInitializer : DropCreateDatabaseAlways<TimeTrackerDataContext>
    {
        protected override void Seed(TimeTrackerDataContext context)
        {
            // Seed data for Projects
            context.Projects.Add(new Project() 
            { 
                ProjectCode = "AAA", 
                ProjectName = "New Project" 
            });
            context.Projects.Add(new Project() 
            { 
                ProjectCode = "BBB", 
                ProjectName = "Big Project" 
            });
            
            // Seed data for Employees
            context.Employees.Add(new Employee() 
            { 
                FirstName = "Tom", 
                LastName = "Shaw", 
                PhoneNumber = "225-938-9501", 
                Email = "tom@trshaw.com", 
                IsManager = true, 
                IsTerminated = false 
            });
            context.Employees.Add(new Employee() 
            { 
                FirstName = "Greg", 
                LastName = "Lemond", 
                PhoneNumber = "225-555-1221", 
                Email = "greg@cox.net", 
                IsManager = false, 
                IsTerminated = false 
            });
            context.Employees.Add(new Employee() 
            { 
                FirstName = "Laurent", 
                LastName = "Fignon", 
                PhoneNumber = "225-555-1234", 
                Email = "eightseconds@sourgrapes.com", 
                IsManager = false 
            });
            context.Employees.Add(new Employee() 
            { 
                FirstName = "Davis", 
                LastName = "Phinney", 
                PhoneNumber = "225-666-1234", 
                Email = "davis@phinney.com", 
                IsManager = false, 
                IsTerminated = true 
            });
            
            // Seed data for TimeEntries
            context.TimeEntries.Add(new TimeEntry() 
            { 
                ProjectID = 1, 
                EmployeeID = 1, 
                TimeDuration = 4, 
                IsBillable = true, 
                Description="Gathering requirements" 
            });
            context.TimeEntries.Add(new TimeEntry() 
            { 
                ProjectID = 1, 
                EmployeeID = 1, 
                TimeDuration = 2, 
                IsBillable = true, 
                Description = "Coding" 
            });
            context.TimeEntries.Add(new TimeEntry() 
            { 
                ProjectID = 1, 
                EmployeeID = 2, 
                TimeDuration = 6, 
                IsBillable = false, 
                Description = "Research" 
            });
            context.TimeEntries.Add(new TimeEntry() 
            { 
                ProjectID = 2, 
                EmployeeID = 2, 
                TimeDuration = 1, 
                IsBillable = true, 
                Description = "Testing" 
            });

            base.Seed(context);
        }
    }
}