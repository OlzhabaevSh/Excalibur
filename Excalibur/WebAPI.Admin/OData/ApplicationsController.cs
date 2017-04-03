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
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using Core.Admin.Models;

namespace WebAPI.Admin.OData
{
    //[Authorize]
    public class ApplicationsController : ODataController
    {
        private ApplicationDbContext db;

        public ApplicationsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: odata/Projects
        [EnableQuery]
        public IQueryable<Application> GetApplications()
        {
            return db.Applications;
        }

        // GET: odata/Projects(5)
        [EnableQuery]
        public SingleResult<Application> GetApplication([FromODataUri] int key)
        {
            return SingleResult.Create(db.Applications.Where(app => app.Id == key));
        }

        // PUT: odata/Projects(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Application> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Application app = db.Applications.Find(key);
            if (app == null)
            {
                return NotFound();
            }

            patch.Put(app);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(app);
        }

        // POST: odata/Projects
        public IHttpActionResult Post(Application app)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Applications.Add(app);
            db.SaveChanges();

            return Created(app);
        }
        
        // DELETE: odata/Projects(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Application app = db.Applications.Find(key);
            if (app == null)
            {
                return NotFound();
            }

            db.Applications.Remove(app);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int key)
        {
            return db.Applications.Count(e => e.Id == key) > 0;
        }
    }
}