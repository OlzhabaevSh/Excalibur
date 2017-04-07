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
    public class ApplicationUsersController : ODataController
    {
        // GET: ApplicationUsers
        private ApplicationDbContext db;

        public ApplicationUsersController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: odata/Projects
        [EnableQuery]
        public IQueryable<Application> GetApplicationUsers()
        {
            return db.Applications;
        }

        // GET: odata/Projects(5)
        [EnableQuery]
        public SingleResult<ApplicationUser> GetApplicationUser([FromODataUri] string key)
        {
            return SingleResult.Create(db.ApplicationUsers.Where(app => app.Id == key));
        }

        // PUT: odata/Projects(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<ApplicationUser> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser app = db.ApplicationUsers.Find(key);
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
        public IHttpActionResult Post(ApplicationUser app)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplicationUsers.Add(app);
            db.SaveChanges();

            return Created(app);
        }

        // DELETE: odata/Projects(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ApplicationUser app = db.ApplicationUsers.Find(key);
            if (app == null)
            {
                return NotFound();
            }

            db.ApplicationUsers.Remove(app);
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

        private bool ProjectExists(string key)
        {
            return db.ApplicationUsers.Count(e => e.Id == key) > 0;
        }
    }
}