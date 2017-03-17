using Core.Admin.Interfaces;
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
    public class AdminRoleStore : IAdminRoleStore
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminRoleStore(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IdentityRole> CreateElement(IdentityRole element)
        {
            _dbContext.Roles.Add(element);
            var res = await _dbContext.SaveChangesAsync();
            return element;
        }

        public async Task<bool> DeleteElement(string key)
        {
            var role = _dbContext.Roles.Find(key);
            if (role == null) return false;
            _dbContext.Roles.Remove(role);
            var res = await _dbContext.SaveChangesAsync();
            return true;
        }       

        public async Task<ICollection<IdentityRole>> GetCollection()
        {
            return _dbContext.Roles.ToList();
        }

        public async Task<ICollection<IdentityRole>> GetCollection(Expression<Func<IdentityRole, bool>> predicate)
        {
            return _dbContext.Roles.Where(predicate).ToList();
        }

        public async Task<IdentityRole> GetElement(string Key)
        {
            return _dbContext.Roles.Find(Key);
        }

        public async Task<IdentityRole> GetElement(Expression<Func<IdentityRole, bool>> predicate)
        {
            return _dbContext.Roles.FirstOrDefault(predicate);
        }

        public async Task<IdentityRole> GetElementByExpression(Expression<Func<IdentityRole, bool>> predicate)
        {
            return _dbContext.Roles.FirstOrDefault(predicate);
        }

        public async Task<IdentityRole> UpdateElement(string key, IdentityRole element)
        {
            _dbContext.Roles.Attach(element);
            _dbContext.Entry(element).State = EntityState.Modified;
            var task = await _dbContext.SaveChangesAsync();
            return element;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
