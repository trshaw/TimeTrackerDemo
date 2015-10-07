using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TimeTracker.Models;

namespace TimeTracker.Controllers
{
    public class LoginController : ApiController
         {
        private TimeTrackerDataContext db = new TimeTrackerDataContext();


        // POST api/Login
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> PostLogin(string email)
        {

            Employee employee = await db.Employees.Where(e => e.Email == email).FirstAsync();
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }

        }

    }
}



