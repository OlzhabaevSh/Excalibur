using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Interfaces
{
    public interface IAdminRoleManager
    {
        Task<IdentityRole> CreateAsync(IdentityRole role);
        Task<bool> DeleteAsync(IdentityRole role);
        Task<IdentityRole> FindByIdAsync(string roleId);
        Task<IdentityRole> FindByNameAsync(string roleName);
        Task<IdentityRole> UpdateAsync(IdentityRole role);
        Task<IdentityRole> Get(IdentityRole role);
        Task<ICollection<IdentityRole>> Get();
    }
}
