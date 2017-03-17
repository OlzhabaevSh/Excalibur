using Core.Admin.Interfaces;
using Core.Admin.Managers;
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
        private AdminRoleManager _manager;

        public RoleController(AdminRoleManager manager)
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
            var role = await _manager.CreateAsync(new IdentityRole()
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
            var role = await _manager.UpdateAsync(new IdentityRole()
            {
                Id = value.Id,
                Name = value.Name
            });                     
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
    }
}
