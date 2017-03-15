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


        public override Task<IdentityResult> DeleteAsync(ApplicationUser user)
        {
            var task = _store.DeleteAsync(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return _store.FindByIdAsync(userId);
        }


        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new AdminUserStore(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
