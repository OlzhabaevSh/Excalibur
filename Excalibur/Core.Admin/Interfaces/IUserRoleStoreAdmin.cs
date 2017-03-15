using Core.Admin.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Interfaces
{
    public interface IUserRoleStoreAdmin : IUserRoleStore<ApplicationUser>
    {
        Task AddToRoleAsync(string userId, string roleName, string applicationId);

        Task RemoveFromRoleAsync(string userId, string roleName, string applicationId);

        Task<IList<string>> GetRolesAsync(string userId, string applicationId);

        Task<bool> IsInRoleAsync(string userId, string roleName, string applicationId);
    }
}
