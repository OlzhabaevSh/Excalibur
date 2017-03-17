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
    builder.EntitySet<ApplicationRoles>("ApplicationRoles");
    builder.EntitySet<IdentityUserRole>("IdentityUserRoles"); 
    builder.EntitySet<Application>("Applications"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ApplicationRolesController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/ApplicationRoles
        [EnableQuery]
        public IQueryable<ApplicationRoles> GetApplicationRoles()
        {
            return db.IdentityRoles;
        }

        // GET: odata/ApplicationRoles(5)
        [EnableQuery]
        public SingleResult<ApplicationRoles> GetApplicationRoles([FromODataUri] string key)
        {
            return SingleResult.Create(db.IdentityRoles.Where(applicationRoles => applicationRoles.Id == key));
        }

        // PUT: odata/ApplicationRoles(5)
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Delta<ApplicationRoles> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationRoles applicationRoles = await db.IdentityRoles.FindAsync(key);
            if (applicationRoles == null)
            {
                return NotFound();
            }

            patch.Put(applicationRoles);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationRolesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(applicationRoles);
        }

        // POST: odata/ApplicationRoles
        public async Task<IHttpActionResult> Post(ApplicationRoles applicationRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            applicationRoles.Id = Guid.NewGuid().ToString();

            db.IdentityRoles.Add(applicationRoles);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationRolesExists(applicationRoles.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(applicationRoles);
        }

        // PATCH: odata/ApplicationRoles(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<ApplicationRoles> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationRoles applicationRoles = await db.IdentityRoles.FindAsync(key);
            if (applicationRoles == null)
            {
                return NotFound();
            }

            patch.Patch(applicationRoles);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationRolesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(applicationRoles);
        }

        // DELETE: odata/ApplicationRoles(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            ApplicationRoles applicationRoles = await db.IdentityRoles.FindAsync(key);
            if (applicationRoles == null)
            {
                return NotFound();
            }

            db.IdentityRoles.Remove(applicationRoles);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //// GET: odata/ApplicationRoles(5)/Users
        //[EnableQuery]
        //public IQueryable<IdentityUserRole> GetUsers([FromODataUri] string key)
        //{
        //    return db.IdentityRoles.Where(m => m.Id == key).SelectMany(m => m.Users);
        //}

        // GET: odata/ApplicationRoles(5)/Applications
        [EnableQuery]
        public IQueryable<Application> GetApplications([FromODataUri] string key)
        {
            return db.IdentityRoles.Where(m => m.Id == key).SelectMany(m => m.Applications);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationRolesExists(string key)
        {
            return db.IdentityRoles.Count(e => e.Id == key) > 0;
        }
    }
}
