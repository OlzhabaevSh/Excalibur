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
    public partial class ApplicationRolesController : ODataController
    {
        public IHttpActionResult AddToApplication(int key, ODataActionParameters parameters)
        {
            if (!parameters.ContainsKey("applicationId"))
            {
                return BadRequest("No applicationId");
            }

            var role = db.ApplicationRoles.Find(key);

            if (role == null)
            {
                return NotFound();
            }

            var applicationId = (int)parameters["applicationId"];
            var application = db.Applications.Find(applicationId);
            if (application == null)
            {
                return NotFound();
            }

            role.Applications.Add(application);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult RemoveFromApplication(int key, ODataActionParameters parameters)
        {
            if (!parameters.ContainsKey("applicationId"))
            {
                return BadRequest("No applicationId");
            }

            var role = db.ApplicationRoles.Find(key);

            if (role == null)
            {
                return NotFound();
            }

            var applicationId = (int)parameters["applicationId"];
            var application = db.Applications.Find(applicationId);
            if (application == null || !role.Applications.Contains(application))
            {
                return NotFound();
            }

            role.Applications.Remove(application);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }

}