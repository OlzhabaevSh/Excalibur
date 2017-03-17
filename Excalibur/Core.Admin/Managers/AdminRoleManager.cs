using Core.Admin.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Managers
{
    public class AdminRoleManager : IAdminRoleManager
    {
        private readonly IAdminRoleStore _store;

        public AdminRoleManager(IAdminRoleStore store)
        {
            _store = store;
        }

        public async Task<IdentityRole> CreateAsync(IdentityRole role)
        {
            role.Id = Guid.NewGuid().ToString();
            var newRole = await _store.CreateElement(role);
            return newRole;
        }

        public async Task<bool> DeleteAsync(IdentityRole role)
        {
            var isDeleted = await _store.DeleteElement(role.Id);
            return isDeleted;
        }

        public async Task<IdentityRole> FindByIdAsync(string roleId)
        {
            var role = await _store.GetElement(roleId);
            return role;
        }

        public async Task<IdentityRole> FindByNameAsync(string roleName)
        {
            var role = await _store.GetElement(r=> r.Name.Equals(roleName));
            return role;
        }

        public async Task<IdentityRole> Get(IdentityRole role)
        {
            var res = await _store.GetElement(r => r.Name.Equals(role.Name) && r.Id.Equals(role.Id));
            return role;
        }

        public async Task<ICollection<IdentityRole>> Get()
        {
            var roleList = await _store.GetCollection();
            return roleList;
        }

        public async Task<IdentityRole> UpdateAsync(IdentityRole role)
        {
            var roleUpdated = await _store.UpdateElement(role.Id, role);
            return roleUpdated;
        }
    }
}
