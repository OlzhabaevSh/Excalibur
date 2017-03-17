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
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using Core.Admin.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Application>("Applications");
    builder.EntitySet<ApplicationList>("ApplicationLists"); 
    builder.EntitySet<ApplicationRoles>("Roles"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ApplicationsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Applications
        [EnableQuery]
        public IQueryable<Application> GetApplications()
        {
            return db.Applications;
        }

        // GET: odata/Applications(5)
        [EnableQuery]
        public SingleResult<Application> GetApplication([FromODataUri] string key)
        {
            return SingleResult.Create(db.Applications.Where(application => application.Id == key));
        }

        // PUT: odata/Applications(5)
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Delta<Application> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Application application = await db.Applications.FindAsync(key);
            if (application == null)
            {
                return NotFound();
            }

            patch.Put(application);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(application);
        }

        // POST: odata/Applications
        public async Task<IHttpActionResult> Post(Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            application.Id = Guid.NewGuid().ToString();
            db.Applications.Add(application);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationExists(application.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(application);
        }

        // PATCH: odata/Applications(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Application> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Application application = await db.Applications.FindAsync(key);
            if (application == null)
            {
                return NotFound();
            }

            patch.Patch(application);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(application);
        }

        // DELETE: odata/Applications(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            Application application = await db.Applications.FindAsync(key);
            if (application == null)
            {
                return NotFound();
            }

            db.Applications.Remove(application);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Applications(5)/ApplicationList
        [EnableQuery]
        public IQueryable<ApplicationList> GetApplicationList([FromODataUri] string key)
        {
            return db.Applications.Where(m => m.Id == key).SelectMany(m => m.ApplicationList);
        }

        // GET: odata/Applications(5)/Roles
        [EnableQuery]
        public IQueryable<ApplicationRoles> GetRoles([FromODataUri] string key)
        {
            return db.Applications.Where(m => m.Id == key).SelectMany(m => m.Roles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationExists(string key)
        {
            return db.Applications.Count(e => e.Id == key) > 0;
        }
    }
}
