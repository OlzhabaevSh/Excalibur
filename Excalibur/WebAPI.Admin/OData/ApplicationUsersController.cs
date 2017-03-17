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
    builder.EntitySet<ApplicationUser>("ApplicationUsers");
    builder.EntitySet<ApplicationList>("ApplicationLists"); 
    builder.EntitySet<IdentityUserClaim>("IdentityUserClaims"); 
    builder.EntitySet<IdentityUserLogin>("IdentityUserLogins"); 
    builder.EntitySet<IdentityUserRole>("IdentityUserRoles"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ApplicationUsersController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/ApplicationUsers
        [EnableQuery]
        public IQueryable<ApplicationUser> GetApplicationUsers()
        {
            return db.Users;
        }

        // GET: odata/ApplicationUsers(5)
        [EnableQuery]
        public SingleResult<ApplicationUser> GetApplicationUser([FromODataUri] string key)
        {
            return SingleResult.Create(db.Users.Where(applicationUser => applicationUser.Id == key));
        }

        // PUT: odata/ApplicationUsers(5)
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Delta<ApplicationUser> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser applicationUser = await db.Users.FirstOrDefaultAsync(x => x.Id == key);
            if (applicationUser == null)
            {
                return NotFound();
            }

            patch.Put(applicationUser);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(applicationUser);
        }

        // POST: odata/ApplicationUsers
        public async Task<IHttpActionResult> Post(ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(applicationUser);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationUserExists(applicationUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(applicationUser);
        }

        // PATCH: odata/ApplicationUsers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<ApplicationUser> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser applicationUser = await db.Users.FirstOrDefaultAsync(x => x.Id == key);
            if (applicationUser == null)
            {
                return NotFound();
            }

            patch.Patch(applicationUser);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(applicationUser);
        }

        // DELETE: odata/ApplicationUsers(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            ApplicationUser applicationUser = await db.Users.FirstOrDefaultAsync(x => x.Id == key);
            if (applicationUser == null)
            {
                return NotFound();
            }

            db.Users.Remove(applicationUser);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ApplicationUsers(5)/ApplicationList
        [EnableQuery]
        public IQueryable<ApplicationList> GetApplicationList([FromODataUri] string key)
        {
            return db.Users.Where(m => m.Id == key).SelectMany(m => m.ApplicationList);
        }

        //// GET: odata/ApplicationUsers(5)/Claims
        //[EnableQuery]
        //public IQueryable<IdentityUserClaim> GetClaims([FromODataUri] string key)
        //{
        //    return db.ApplicationUsers.Where(m => m.Id == key).SelectMany(m => m.Claims);
        //}

        //// GET: odata/ApplicationUsers(5)/Logins
        //[EnableQuery]
        //public IQueryable<IdentityUserLogin> GetLogins([FromODataUri] string key)
        //{
        //    return db.ApplicationUsers.Where(m => m.Id == key).SelectMany(m => m.Logins);
        //}

        //// GET: odata/ApplicationUsers(5)/Roles
        //[EnableQuery]
        //public IQueryable<IdentityUserRole> GetRoles([FromODataUri] string key)
        //{
        //    return db.ApplicationUsers.Where(m => m.Id == key).SelectMany(m => m.Roles);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationUserExists(string key)
        {
            return db.Users.Any(e => e.Id == key);
        }
    }
}
