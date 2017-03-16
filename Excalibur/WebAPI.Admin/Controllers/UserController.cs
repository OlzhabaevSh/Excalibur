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
    public class UserController : ApiController
    {
        // GET: api/User
        public Task<IEnumerable<ApplicationUserVM>> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/User/5
        public Task<ApplicationUserVM> Get(string id)
        {
            throw new NotImplementedException();
        }

        // POST: api/User
        [ResponseType(typeof(ApplicationUserVM))]
        public Task<IHttpActionResult> Post([FromBody]ApplicationUserVM value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/User/5
        [ResponseType(typeof(ApplicationUserVM))]
        public Task<IHttpActionResult> Put(string id, [FromBody]ApplicationUserVM value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/User/5
        [ResponseType(typeof(bool))]
        public Task<IHttpActionResult> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
