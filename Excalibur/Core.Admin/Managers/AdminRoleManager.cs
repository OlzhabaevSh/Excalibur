using Core.Admin.Interfaces;
using Core.Admin.Models;
using Core.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Managers
{
    //public class AdminRoleManager : IAdminRoleManager
    //{
    //    private readonly IAdminRoleStore _store;

    //    private readonly IStore<Application, string> _storeApplications;

    //    public AdminRoleManager(IAdminRoleStore store, IStore<Application, string> storeApplications)
    //    {
    //        _store = store;
    //        _storeApplications = storeApplications;
    //    }

    //    public async Task<ApplicationRoles> CreateAsync(ApplicationRoles role)
    //    {
    //        role.Id = Guid.NewGuid().ToString();
    //        var newRole = await _store.CreateElement(role);
    //        return newRole;
    //    }

    //    public async Task<bool> DeleteAsync(ApplicationRoles role)
    //    {
    //        var isDeleted = await _store.DeleteElement(role.Id);
    //        return isDeleted;
    //    }

    //    public async Task<ICollection<string>> DeleteAsync(string[] roleIds)
    //    {
    //        var roleList = await _store.DeleteCollection(roleIds);
    //        return roleList;
    //    }

    //    public async Task<ApplicationRoles> FindByIdAsync(string roleId)
    //    {
    //        var role = await _store.GetElement(roleId);
    //        return role;
    //    }

    //    public async Task<ApplicationRoles> FindByNameAsync(string roleName)
    //    {
    //        var role = await _store.GetElement(r=> r.Name.Equals(roleName));
    //        return role;
    //    }

    //    public async Task<ICollection<ApplicationRoles>> Get()
    //    {
    //        var roleList = await _store.GetCollection();
    //        return roleList;
    //    }

    //    public async Task<ICollection<ApplicationRoles>> GetByApplication(string applicationId)
    //    {
    //        var res = await _storeApplications.GetElement(x => x.Id == applicationId);

    //        if (res != null)
    //        {
    //            return res.Roles.Select(x => new ApplicationRoles()
    //            {
    //                Id = x.Id,
    //                Name = x.Name
    //            }).ToList();
    //        }
    //        else
    //        {
    //            return new List<ApplicationRoles>();
    //        }
    //    }

    //    public async Task<ApplicationRoles> RemoveFromApplication(string roleId, string applicationId)
    //    {
    //        var app = new Application() { Id = applicationId };

    //        var role = await _store.GetElement(roleId);

    //        role.Applications.Remove(app);

    //        var res = await _store.UpdateElement(roleId, role);
    //        return res;
    //    }

    //    public async Task<ApplicationRoles> AddToApplication(string roleId, string applicationId)
    //    {
    //        var app = new Application() { Id = applicationId };

    //        var role = await _store.GetElement(roleId);

    //        role.Applications.Add(app);

    //        var res = await _store.UpdateElement(roleId, role);
    //        return res;
    //    }

    //    public async Task<ApplicationRoles> UpdateAsync(ApplicationRoles role)
    //    {
    //        var roleUpdated = await _store.UpdateElement(role.Id, role);
    //        return roleUpdated;
    //    }        
    //}
}
