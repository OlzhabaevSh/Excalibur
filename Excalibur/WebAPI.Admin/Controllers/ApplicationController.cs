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

            if (res != null)
            {
                return res.Select(app => new ApplicationVM()
                {
                    Id = app.Id,
                    Name = app.Name,
                    Token = app.Token,
                    Url = app.Url
                }).ToList();
            }
            else
            {
                return new List<ApplicationVM>();
            }
        }

        // GET: api/Application/5
        [ResponseType(typeof(ApplicationVM))]
        public async Task<IHttpActionResult> Get(string id)
        {
            var res = await _manager.FindById(id);

            if (res == null)
            {
                return BadRequest("Element not founded!");
            }

            var response = new ApplicationVM()
            {
                Id = res.Id,
                Name = res.Name,
                Token = res.Token,
                Url = res.Url
            };

            return Ok(response); 
        }

        // POST: api/Application
        [ResponseType(typeof(ApplicationVM))]
        public async Task<IHttpActionResult> Post([FromBody]ApplicationVM ApplicationVM)
        {
            var task = await _manager.Create(new Application()
            {
                Id = ApplicationVM.Id,
                Name = ApplicationVM.Name,
                Token = ApplicationVM.Token,
                Url = ApplicationVM.Url
            });

            return Ok(task);
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
            var res = await _manager.DeleteAsync(id);

            return Ok(true);
        }

        // DELETE: api/Application/5
        [ResponseType(typeof(IEnumerable<string>))]
        public async Task<IHttpActionResult> Delete(string[] ids)
        {
            var res = await _manager.DeleteAsync(ids);
            return Ok(true);
        }

        [HttpGet]
        [Route("Application/Detail")]
        public async Task<IEnumerable<ApplicationListVM>> GetAppDetail(string roleId = "", string userId = "")
        {
            var appListCollection = await _manager.GetApplicationListCollectionByRoleAndUser(roleId, userId);
            if (appListCollection == null) return new List<ApplicationListVM>();
            return appListCollection.Select(appList => new ApplicationListVM()
            {
                Id = appList.Id,
                Application = new ApplicationVM()
                {
                    Id = appList.Application.Id,
                    Name = appList.Application.Name,
                    Token = appList.Application.Token,
                    Url = appList.Application.Url
                },
                Role = new RoleVM()
                {
                    Id = appList.Role.Id,
                    Name = appList.Role.Name
                },
                User = new ApplicationUserVM()
                {
                    Id = appList.ApplicationUser.Id,
                    Email = appList.ApplicationUser.Email,
                    HashPwd = appList.ApplicationUser.PasswordHash,
                    PersonInfo = appList.ApplicationUser.PersonInfo
                }
            });
        }

        [HttpGet]
        [Route("Application/Detail/{id}")]
        [ResponseType(typeof(ApplicationListVM))]
        public async Task<IHttpActionResult> GetAppItemDetail(int id)
        {
            var appList = await _manager.GetApplicationListById(id);
            if (appList == null) return BadRequest("Element not founded!");
            return Ok(new ApplicationListVM()
            {
                Id = appList.Id,
                Application = new ApplicationVM()
                {
                    Id = appList.Application.Id,
                    Name = appList.Application.Name,
                    Token = appList.Application.Token,
                    Url = appList.Application.Url
                },
                Role = new RoleVM()
                {
                    Id = appList.Role.Id,
                    Name = appList.Role.Name
                },
                User = new ApplicationUserVM()
                {
                    Id = appList.ApplicationUser.Id,
                    Email = appList.ApplicationUser.Email,
                    HashPwd = appList.ApplicationUser.PasswordHash,
                    PersonInfo = appList.ApplicationUser.PersonInfo
                }
            });
        }

        [HttpPost]
        [Route("Application/Detail")]
        [ResponseType(typeof(ApplicationListVM))]
        public async Task<IHttpActionResult> PostAppDetail([FromBody]ApplicationListVM appDetail)
        {
            var appList = await _manager.CreateApplicationList(new ApplicationList()
            {
                Id = appDetail.Id,
                RoleId = appDetail.Role.Id,
                UserId = appDetail.User.Id,
                ApplicationId = appDetail.Application.Id
            });
            return Ok(appList);
        }

        [HttpPut]
        [Route("Application/Detail/{id}")]
        [ResponseType(typeof(ApplicationListVM))]
        public async Task<IHttpActionResult> PutAppDetail(int id, [FromBody]ApplicationListVM appDetail)
        {
            var appList = await _manager.UpdateApplicationList(new ApplicationList()
            {
                Id = appDetail.Id,
                RoleId = appDetail.Role.Id,
                UserId = appDetail.User.Id,
                ApplicationId = appDetail.Application.Id
            });
            return Ok(appList);
        }

        [HttpDelete]
        [Route("Application/Detail/{id}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeleteAppDetail(int id)
        {
            var isDeleted = await _manager.DeleteApplicationList(id);
            return Ok(isDeleted);
        }

        [HttpDelete]
        [Route("Application/Detail/{id}")]
        [ResponseType(typeof(IEnumerable<int>))]
        public async Task<IHttpActionResult> DeleteAppDetail(int[] id)
        {
            var appDetailList = await _manager.DeleteApplicationListCollection(id);
            return Ok(appDetailList);
        }
    }
}
