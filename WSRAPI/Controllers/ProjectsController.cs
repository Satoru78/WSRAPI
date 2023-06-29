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
using WSRAPI.Models.Dto;

namespace WSRAPI.Controllers
{
    public class ProjectsController : ApiController
    {
        private dbProjectOfficeEntities db = new dbProjectOfficeEntities();

        // GET: api/Projects
        public IQueryable<Project> GetProject()
        {
            return db.Task.Select(x => new ProjectDto
            {
                ID = x.ID,
                FullTitle = x.FullTitle,
                ShortTitle = x.ShortTitle,
                Icon = x.Icon,
                CreatedTime = x.CreatedTime,
                DeletedTime = x.DeletedTime,
                StartScheduleDate = x.StartScheduleDate,
                FinishScheduleDate = x.FinishScheduleDate,
                Description = x.Description,
                CreatorEmployeeID = x.CreatorEmployeeID,
                ResponsibleEmployeeId = x.ResponsibleEmployeeId
            });
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(int id)
        {
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.ID)
            {
                return BadRequest();
            }

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Project.Add(project);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project.ID }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(int id)
        {
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Project.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Project.Count(e => e.ID == id) > 0;
        }
    }
}