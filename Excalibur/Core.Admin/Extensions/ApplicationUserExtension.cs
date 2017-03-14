using Core.Admin.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Extensions
{
    public static class ApplicationUserExtension
    {
        public static IdentityUser ToIdentityUser(this ApplicationUser user)
        {
            return new IdentityUser()
            {
                Id = user.Id,                
                PasswordHash = user.PasswordHash,               
                UserName = user.UserName
            };
        }
    }
}
