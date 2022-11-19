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
using Gym_Management.Models;
using Gym_Management.Models.Management;

namespace Gym_Management.Controllers.Api
{
    public class WorkoutTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WorkoutTypes
        public IQueryable<WorkoutType> GetWorkoutTypes()
        {
            return db.WorkoutTypes;
        }

        // GET: api/WorkoutTypes/5
        [ResponseType(typeof(WorkoutType))]
        public async Task<IHttpActionResult> GetWorkoutType(int id)
        {
            WorkoutType workoutType = await db.WorkoutTypes.FindAsync(id);
            if (workoutType == null)
            {
                return NotFound();
            }

            return Ok(workoutType);
        }

        // PUT: api/WorkoutTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorkoutType(int id, WorkoutType workoutType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workoutType.Id)
            {
                return BadRequest();
            }

            db.Entry(workoutType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutTypeExists(id))
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

        // POST: api/WorkoutTypes
        [ResponseType(typeof(WorkoutType))]
        public async Task<IHttpActionResult> PostWorkoutType(WorkoutType workoutType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkoutTypes.Add(workoutType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = workoutType.Id }, workoutType);
        }

        // DELETE: api/WorkoutTypes/5
        [ResponseType(typeof(WorkoutType))]
        public async Task<IHttpActionResult> DeleteWorkoutType(int id)
        {
            WorkoutType workoutType = await db.WorkoutTypes.FindAsync(id);
            if (workoutType == null)
            {
                return NotFound();
            }

            db.WorkoutTypes.Remove(workoutType);
            await db.SaveChangesAsync();

            return Ok(workoutType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkoutTypeExists(int id)
        {
            return db.WorkoutTypes.Count(e => e.Id == id) > 0;
        }
    }
}