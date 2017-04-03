using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Core.Admin.Models;
using WebAPI.Admin.App_Start;
using Microsoft.Practices.Unity;
using Core.Admin.Interfaces;
//using Core.Admin.Managers;

namespace WebAPI.Admin
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class IdentityConfig
    {
        
        //public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        //{
        //    var cntr = UnityConfig.GetConfiguredContainer();
            
        //    var store = cntr.Resolve<IUserStoreAdmin>();

        //    var manager = new ApplicationUserManager(store);
        //    // Configure validation logic for usernames
        //    manager.UserValidator = new UserValidator<ApplicationUser>(manager)
        //    {
        //        AllowOnlyAlphanumericUserNames = false,
        //        RequireUniqueEmail = true
        //    };
        //    // Configure validation logic for passwords
        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 6,
        //        RequireNonLetterOrDigit = true,
        //        RequireDigit = true,
        //        RequireLowercase = true,
        //        RequireUppercase = true,
        //    };
        //    var dataProtectionProvider = options.DataProtectionProvider;
        //    if (dataProtectionProvider != null)
        //    {
        //        manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
        //    }
            
        //    // regist manager
        //    cntr.RegisterInstance<ApplicationUserManager>(manager);

        //    return manager;
        //}     
    }
}
