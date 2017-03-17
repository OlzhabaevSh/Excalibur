using Core.Admin.Managers;
using Core.Admin.Models;
using Core.Admin.ViewModels;
using Core.ComplexTypes;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.ObjectBuilder2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Admin.Controllers
{
    public class UserController : ApiController
    {
        private readonly ApplicationUserManager _userManager;

        public UserController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: api/User
        public async Task<IEnumerable<ApplicationUserVM>> Get()
        {
            var data = _userManager.Users.ToList();
            return data.Select(x => new ApplicationUserVM()
            {
                Id = x.Id,
                Email = x.Email,
                HashPwd = x.PasswordHash,
                PersonInfo = x.PersonInfo
            }).ToList();
        }

        // GET: api/User/5
        [ResponseType(typeof(ApplicationUserVM))]
        public async Task<IHttpActionResult> Get(string id)
        {
            var item = _userManager.Users.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return BadRequest("User with id not founded. Id: " + id);
            }

            var res = new ApplicationUserVM()
            {
                Id = item.Id,
                Email = item.Email,
                HashPwd = item.PasswordHash,
                PersonInfo = item.PersonInfo
            };

            return Ok(res);
        }

        // POST: api/User
        [ResponseType(typeof(ApplicationUserVM))]
        public async Task<IHttpActionResult> Post([FromBody]ApplicationUserVM value)
        {
            var applicationUser = new ApplicationUser()
            {
                PersonInfo = value.PersonInfo,
                Email = value.Email,
                PasswordHash = value.HashPwd
            };

            var res = await _userManager.CreateAsync(applicationUser);

            if (!res.Succeeded)
            {
                var str = new StringBuilder();

                res.Errors.ForEach(item => 
                {
                    str.Append(item + "; ");
                });

                return BadRequest("Error! Message: " + str.ToString());
            }

            var user = _userManager.Users.First(x => x.Email == value.Email && x.PersonInfo.IIN == value.PersonInfo.IIN);
            var resp = new ApplicationUserVM()
            {
                Id = user.Id,
                Email = user.Email,
                HashPwd = user.PasswordHash,
                PersonInfo = user.PersonInfo
            };

            return Ok(resp);
        }

        // PUT: api/User/5
        [ResponseType(typeof(ApplicationUserVM))]
        public async Task<IHttpActionResult> Put(string id, [FromBody]ApplicationUserVM value)
        {
            var identityResult = await _userManager.UpdateAsync(new ApplicationUser()
            {
                PersonInfo = value.PersonInfo
            });
            return Ok(value);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Delete(string id)
        {
            var appUser = await _userManager.FindByIdAsync(id);
            var identityResult = await _userManager.DeleteAsync(appUser);            
            return Ok(identityResult.Succeeded);
        }

        [ResponseType(typeof(IEnumerable<string>))]
        public async Task<IHttpActionResult> Delete(string[] ids)
        {
            var idList = await _userManager.Delete(ids);            
            return Ok(idList);
        }
    }
}
