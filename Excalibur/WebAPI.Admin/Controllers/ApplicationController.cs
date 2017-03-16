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
        public async Task<IEnumerable<ApplicationVM>> Get()
        {
            var res = await _manager.GetCollection();
            
            return res.Select(app => new ApplicationVM()
            {
                Id = app.Id,
                Name = app.Name,
                Token = app.Token,
                Url = app.Url
            }).ToList();
        }

        // GET: api/Application/5
        public async Task<ApplicationVM> Get(string id)
        {
            var res = await _manager.FindById(id);

            return new ApplicationVM()
            {
                Id = res.Id,
                Name = res.Name,
                Token = res.Token,
                Url = res.Url
            });
        }

        // POST: api/Application
        [ResponseType(typeof(ApplicationVM))]
        public Task<IHttpActionResult> Post([FromBody]ApplicationVM ApplicationVM)
        {
            var task = _manager.Create(new Application()
            {
                Id = ApplicationVM.Id,
                Name = ApplicationVM.Name,
                Token = ApplicationVM.Token,
                Url = ApplicationVM.Url
            });
            if (task.Status == TaskStatus.Faulted)
                return Task.FromResult(BadRequest() as IHttpActionResult);
            return Task.FromResult(Ok() as IHttpActionResult);
        }

        // PUT: api/Application/5
        [ResponseType(typeof(ApplicationVM))]
        public async Task<IHttpActionResult> Put(string id, [FromBody]ApplicationVM ApplicationVM)
        {
            var res = await _manager.Update(new Application()
            {
                Id = ApplicationVM.Id,
                Name = ApplicationVM.Name,
                Token = ApplicationVM.Token,
                Url = ApplicationVM.Url
            });

            return Ok(res);
        }

        // DELETE: api/Application/5
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Delete(string id)
        {
            var res = await _manager.Delete(id);

            return Ok(true);
        }

        [HttpGet]
        [Route("Detail")]
        public async Task<IEnumerable<ApplicationListVM>> GetAppDetail(string roleId = "", string userId = "")
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Detail")]
        public async Task<ApplicationListVM> GetAppItemDetail(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("Detail")]
        [ResponseType(typeof(ApplicationListVM))]
        public async Task<IHttpActionResult> PostAppDetail([FromBody]ApplicationListVM appDetail)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("Detail")]
        [ResponseType(typeof(ApplicationListVM))]
        public async Task<IHttpActionResult> PutAppDetail(string id, [FromBody]ApplicationListVM appDetail)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("Detail")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeleteAppDetail(string id)
        {
            throw new NotImplementedException();
        }

    }
}
