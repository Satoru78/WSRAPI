using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WSRAPI.Models;

namespace WSRAPI.Controllers
{
    public class TasksController : ApiController
    {
        private dbProjectOfficeEntities db = new dbProjectOfficeEntities();

        // GET: api/Tasks
        public IQueryable<Task> GetTask()
        {
            return db.Task.Select(x => new TaskDto
            {
                ID = x.ID,
                Deadline = x.Deadline,
                DeletedTime = x.DeletedTime,
                Description = x.Description,
                CreatedTime = x.CreatedTime,
                ExecutiveEmployee = x.Employees.LastName,
                FinishActualTime = x.FinishActualTime,
                FullTitle = x.FullTitle,
                PreviousTaskShortTitle = db.Task.FirstOrDefault(q => q.ID == x.PreviousTaskId).ShortTitle,
                ProjectTitle = x.Project.FullTitle,
                ShortTitle = x.ShortTitle,
                StartActualTime = x.StartActualTime,
                StatusTitle = x.TaskStatus.Name,
                UpdatedTime = x.UpdatedTime,
                StatusColor = x.TaskStatus.ColorHex
            });
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask(int id)
        {
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.ID)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // POST: api/Tasks
        [ResponseType(typeof(Task))]
        public IHttpActionResult PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Task.Add(task);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = task.ID }, task);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult DeleteTask(int id)
        {
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            db.Task.Remove(task);
            db.SaveChanges();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Task.Count(e => e.ID == id) > 0;
        }
    }
}