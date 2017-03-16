using Core.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Admin.Controllers
{
    public class RoleController : ApiController
    {
        // GET: api/Role
        public Task<IEnumerable<RoleVM>> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Role/5
        public Task<RoleVM> Get(string id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Role
        [ResponseType(typeof(RoleVM))]
        public Task<IHttpActionResult> Post([FromBody]RoleVM value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Role/5
        [ResponseType(typeof(RoleVM))]
        public Task<IHttpActionResult> Put(string id, [FromBody]RoleVM value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Role/5
        [ResponseType(typeof(bool))]
        public Task<IHttpActionResult> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
