using Core.Admin.Models;
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
        Task<ApplicationRoles> CreateAsync(ApplicationRoles role);
        Task<bool> DeleteAsync(ApplicationRoles role);
        Task<ApplicationRoles> FindByIdAsync(string roleId);
        Task<ApplicationRoles> FindByNameAsync(string roleName);
        Task<ApplicationRoles> UpdateAsync(ApplicationRoles role);
        Task<ApplicationRoles> AddToApplication(string roleId, string applicationId);
        Task<ApplicationRoles> RemoveFromApplication(string roleId, string applicationId);
        Task<ICollection<ApplicationRoles>> Get();
        Task<ICollection<ApplicationRoles>> GetByApplication(string applicationId);
    }
}
