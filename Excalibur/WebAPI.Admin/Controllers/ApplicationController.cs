using Core.Admin.Interfaces;
using Core.Admin.Models;
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
    public class ApplicationController : ApiController
    {
        private readonly IManagerAdmin<Application> _manager;

        public ApplicationController(IManagerAdmin<Application> manager)
        {
            _manager = manager;
        }

        // GET: api/Application
        public Task<IEnumerable<ApplicationVM>> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Application/5
        public Task<ApplicationVM> Get(string id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Application
        [ResponseType(typeof(ApplicationVM))]
        public Task<IHttpActionResult> Post([FromBody]ApplicationVM ApplicationVM)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Application/5
        [ResponseType(typeof(ApplicationVM))]
        public Task<IHttpActionResult> Put(string id, [FromBody]ApplicationVM ApplicationVM)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Application/5
        [ResponseType(typeof(bool))]
        public Task<IHttpActionResult> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
