using Core.Admin.Interfaces;
using Core.Admin.Models;
using Core.Admin.Stores;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Managers
{
    public class ApplicationUserManager : UserManager<ApplicationUser>, IManagerAdmin<ApplicationUser>
    {
        private readonly IUserStoreAdmin _store;
        public ApplicationUserManager(IUserStoreAdmin store) : base(store)
        {
            _store = store;
        }

        public override Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            var task = _store.CreateAsync(user);
            
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
            var user = _store.GetElement(x => x.Email == userName && x.PasswordHash == password);

            return user;
        }

        public override Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            user.PasswordHash = password;
            var task = _store.CreateAsync(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<IdentityResult> DeleteAsync(ApplicationUser user)
        {
            var task = _store.DeleteAsync(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return _store.FindByIdAsync(userId);
        }        
    }
}
