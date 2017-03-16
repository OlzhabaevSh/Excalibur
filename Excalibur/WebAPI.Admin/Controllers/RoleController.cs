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
        private RoleManager<IdentityRole> _manager;
        // GET: api/Role
        public async Task<IEnumerable<RoleVM>> Get()
        {
            return  _manager.Roles.Select(role => new RoleVM()
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
            var identityResult = _manager.Create(new IdentityRole()
            {
                Id = value.Id,
                Name = value.Name
            });
            if (!identityResult.Succeeded) return BadRequest("Element not created");            
            var role = await _manager.FindByNameAsync(value.Name);
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
            var identityResult = await _manager.UpdateAsync(new IdentityRole()
            {
                Id = value.Id,
                Name = value.Name
            });
            if (!identityResult.Succeeded) return BadRequest("Not updated");            
            return Ok(value);
        }

        // DELETE: api/Role/5
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Delete(string id)
        {
            var role = await _manager.FindByIdAsync(id);
            var identityResult = await _manager.DeleteAsync(role);
            if (!identityResult.Succeeded) return BadRequest("Not deleted");
            return Ok(identityResult.Succeeded);
        }
    }
}
