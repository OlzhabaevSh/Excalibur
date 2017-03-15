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
        public Task<ApplicationVM> Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Application
        public IHttpActionResult Post([FromBody]string ApplicationVM)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Application/5
        public IHttpActionResult Put(string id, [FromBody]string ApplicationVM)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Application/5
        public IHttpActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
