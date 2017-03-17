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
    builder.EntitySet<ApplicationList>("ApplicationLists");
    builder.EntitySet<Application>("Applications"); 
    builder.EntitySet<ApplicationUser>("ApplicationUsers"); 
    builder.EntitySet<ApplicationRoles>("IdentityRoles"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ApplicationListsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/ApplicationLists
        [EnableQuery]
        public IQueryable<ApplicationList> GetApplicationLists()
        {
            return db.ApplicationLists;
        }

        // GET: odata/ApplicationLists(5)
        [EnableQuery]
        public SingleResult<ApplicationList> GetApplicationList([FromODataUri] int key)
        {
            return SingleResult.Create(db.ApplicationLists.Where(applicationList => applicationList.Id == key));
        }

        // PUT: odata/ApplicationLists(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ApplicationList> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationList applicationList = await db.ApplicationLists.FindAsync(key);
            if (applicationList == null)
            {
                return NotFound();
            }

            patch.Put(applicationList);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationListExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(applicationList);
        }

        // POST: odata/ApplicationLists
        public async Task<IHttpActionResult> Post(ApplicationList applicationList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplicationLists.Add(applicationList);
            await db.SaveChangesAsync();

            return Created(applicationList);
        }

        // PATCH: odata/ApplicationLists(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ApplicationList> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationList applicationList = await db.ApplicationLists.FindAsync(key);
            if (applicationList == null)
            {
                return NotFound();
            }

            patch.Patch(applicationList);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationListExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(applicationList);
        }

        // DELETE: odata/ApplicationLists(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ApplicationList applicationList = await db.ApplicationLists.FindAsync(key);
            if (applicationList == null)
            {
                return NotFound();
            }

            db.ApplicationLists.Remove(applicationList);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ApplicationLists(5)/Application
        [EnableQuery]
        public SingleResult<Application> GetApplication([FromODataUri] int key)
        {
            return SingleResult.Create(db.ApplicationLists.Where(m => m.Id == key).Select(m => m.Application));
        }

        // GET: odata/ApplicationLists(5)/ApplicationUser
        [EnableQuery]
        public SingleResult<ApplicationUser> GetApplicationUser([FromODataUri] int key)
        {
            return SingleResult.Create(db.ApplicationLists.Where(m => m.Id == key).Select(m => m.ApplicationUser));
        }

        // GET: odata/ApplicationLists(5)/Role
        [EnableQuery]
        public SingleResult<ApplicationRoles> GetRole([FromODataUri] int key)
        {
            return SingleResult.Create(db.ApplicationLists.Where(m => m.Id == key).Select(m => m.Role));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationListExists(int key)
        {
            return db.ApplicationLists.Count(e => e.Id == key) > 0;
        }
    }
}
