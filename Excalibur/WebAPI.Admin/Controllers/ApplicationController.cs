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
        private readonly IApplicationManagerAdmin<Application, string> _manager;

        public ApplicationController(IApplicationManagerAdmin<Application, string> manager)
        {
            _manager = manager;
        }

        // GET: api/Application
        public Task<IEnumerable<ApplicationVM>> Get()
        {
            var task = _manager.GetCollection();
            return Task.FromResult(task.Result.Select(app => new ApplicationVM()
            {
                Id = app.Id,
                Name = app.Name,
                Token = app.Token,
                Url = app.Url
            }));
        }

        // GET: api/Application/5
        public Task<ApplicationVM> Get(string id)
        {
            var task = _manager.FindById(id);
            var application = task.Result;
            return Task.FromResult(new ApplicationVM()
            {
                Id = application.Id,
                Name = application.Name,
                Token = application.Token,
                Url = application.Url
            });
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
            var task = _manager.Delete(id);
            if (task.Status == TaskStatus.Faulted)
                return BadRequest();
            return Ok();
        }
    }
}
