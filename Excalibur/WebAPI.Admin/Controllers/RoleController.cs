using Core.Admin.Interfaces;
using Core.Admin.Managers;
using Core.Admin.Models;
using Core.Admin.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        private IAdminRoleManager _manager;

        public RoleController(IAdminRoleManager manager)
        {
            _manager = manager;
        }

        // GET: api/Role
        public async Task<IEnumerable<RoleVM>> Get()
        {
            var roles = await _manager.Get();

            return  roles.Select(role => new RoleVM()
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        [Route("api/Role/Application/{id}")]
        public async Task<IEnumerable<RoleVM>> GetByApplication(string id = "")
        {
            ICollection<ApplicationRoles> roles = null;

            if (!string.IsNullOrEmpty(id))
            {
                roles = await _manager.GetByApplication(id);
            }
            else
            {
                roles = await _manager.Get();
            }

            return roles.Select(role => new RoleVM()
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        // GET: api/Role/5
        [ResponseType(typeof(RoleVM))]
        public async Task<IHttpActionResult> Get(string id)
        {
            var role = await _manager.FindByIdAsync(id);
            if (role == null) return BadRequest("Element not found");
            return Ok(new RoleVM()
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        // POST: api/Role
        [ResponseType(typeof(RoleVM))]
        public async Task<IHttpActionResult> Post([FromBody]RoleVM value)
        {
            var role = await _manager.CreateAsync(new ApplicationRoles()
            {
                Id = value.Id,
                Name = value.Name
            });
            if (role == null) return BadRequest("Element not created");                        
            return Ok(new RoleVM()
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        // PUT: api/Role/5
        [ResponseType(typeof(RoleVM))]
        public async Task<IHttpActionResult> Put(string id, [FromBody]RoleVM value)
        {
            var role = await _manager.UpdateAsync(new ApplicationRoles()
            {
                Id = value.Id,
                Name = value.Name
            });                     
            return Ok(role);
        }

        [Route("api/Role/Application/{id}")]
        [HttpPut]
        [ResponseType(typeof(RoleVM))]
        public async Task<IHttpActionResult> PutApplication(string id, [FromBody]ApplicationVM value)
        {
            var role = await _manager.AddToApplication(id, value.Id);
            return Ok(role);
        }

        [Route("api/Role/Application/{id}")]
        [HttpDelete]
        [ResponseType(typeof(RoleVM))]
        public async Task<IHttpActionResult> DeleteApplication(string id, [FromBody]ApplicationVM value)
        {
            var role = await _manager.RemoveFromApplication(id, value.Id);
            return Ok(role);
        }

        // DELETE: api/Role/5
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Delete(string id)
        {
            var role = await _manager.FindByIdAsync(id);
            var isDeleted = await _manager.DeleteAsync(role);
            if (!isDeleted) return BadRequest("Not deleted");
            return Ok(isDeleted);
        }

        // DELETE: api/Role/5
        [HttpDelete]
        [ResponseType(typeof(IEnumerable<string>))]
        public async Task<IHttpActionResult> Delete(string[] ids)
        {
            var roleList = await _manager.DeleteAsync(ids);
            return Ok(roleList);
        }
    }
}
