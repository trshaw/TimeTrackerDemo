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
    public class TimeEntryController : ApiController
    {
        private TimeTrackerDataContext db = new TimeTrackerDataContext();

        // GET api/TimeEntry
        public IQueryable<TimeEntry> GetTimeEntries()
        {
            return db.TimeEntries.Include(p => p.Project);
        }

        // GET api/TimeEntry/5
        [ResponseType(typeof(TimeEntry))]
        public async Task<IHttpActionResult> GetTimeEntry(int id)
        {
            TimeEntry timeentry = await db.TimeEntries.FindAsync(id);
            if (timeentry == null)
            {
                return NotFound();
            }

            return Ok(timeentry);
        }

        // PUT api/TimeEntry/5
        public async Task<IHttpActionResult> PutTimeEntry(int id, TimeEntry timeentry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeentry.ID)
            {
                return BadRequest();
            }

            db.Entry(timeentry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeEntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/TimeEntry
        [ResponseType(typeof(TimeEntry))]
        public async Task<IHttpActionResult> PostTimeEntry(TimeEntry timeentry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimeEntries.Add(timeentry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = timeentry.ID }, timeentry);
        }

        // DELETE api/TimeEntry/5
        [ResponseType(typeof(TimeEntry))]
        public async Task<IHttpActionResult> DeleteTimeEntry(int id)
        {
            TimeEntry timeentry = await db.TimeEntries.FindAsync(id);
            if (timeentry == null)
            {
                return NotFound();
            }

            db.TimeEntries.Remove(timeentry);
            await db.SaveChangesAsync();

            return Ok(timeentry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeEntryExists(int id)
        {
            return db.TimeEntries.Count(e => e.ID == id) > 0;
        }
    }
}