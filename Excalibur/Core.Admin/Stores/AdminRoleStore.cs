﻿using Core.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq.Expressions;
using Core.Admin.Models;
using System.Data.Entity;

namespace Core.Admin.Stores
{
    //public class AdminRoleStore : IAdminRoleStore
    //{
    //    private readonly ApplicationDbContext _dbContext;

    //    public AdminRoleStore(ApplicationDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    public async Task<ApplicationRoles> CreateElement(ApplicationRoles element)
    //    {
    //        _dbContext.Roles.Add(element);
    //        var res = await _dbContext.SaveChangesAsync();
    //        return element;
    //    }

    //    public async Task<bool> DeleteElement(string key)
    //    {
    //        var role = _dbContext.Roles.Find(key);
    //        if (role == null) return false;
    //        _dbContext.Roles.Remove(role);
    //        var res = await _dbContext.SaveChangesAsync();
    //        return true;
    //    }       

    //    public async Task<ICollection<ApplicationRoles>> GetCollection()
    //    {
    //        return _dbContext.IdentityRoles.ToList();
    //    }

    //    public async Task<ICollection<ApplicationRoles>> GetCollection(Expression<Func<ApplicationRoles, bool>> predicate)
    //    {
    //        return _dbContext.IdentityRoles.Where(predicate).ToList();
    //    }

    //    public async Task<ApplicationRoles> GetElement(string Key)
    //    {
    //        return _dbContext.IdentityRoles.Include(x => x.Applications).FirstOrDefault(x => x.Id == Key);
    //    }

    //    public async Task<ApplicationRoles> GetElement(Expression<Func<ApplicationRoles, bool>> predicate)
    //    {
    //        return _dbContext.IdentityRoles.FirstOrDefault(predicate);
    //    }

    //    public async Task<ApplicationRoles> UpdateElement(string key, ApplicationRoles element)
    //    {
    //        _dbContext.Roles.Attach(element);
    //        _dbContext.Entry(element).State = EntityState.Modified;
    //        var task = await _dbContext.SaveChangesAsync();
    //        return element;
    //    }

    //    public void Dispose()
    //    {
    //        _dbContext.Dispose();
    //    }

    //    public async Task<ICollection<string>> DeleteCollection(ICollection<string> deleteCollection)
    //    {
    //        var roleList = _dbContext.Roles.Where(r => deleteCollection.Contains(r.Id));
    //        foreach (var r in roleList)
    //        {
    //            _dbContext.Roles.Remove(r);
    //        }
    //        _dbContext.SaveChanges();
    //        return roleList.Select(r=> r.Id).ToList();
    //    }
    //}
}
