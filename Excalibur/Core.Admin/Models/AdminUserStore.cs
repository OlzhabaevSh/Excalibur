using Core.Admin.Interfaces;
using Core.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Models
{
    public class AdminUserStore : IUserStoreAdmin
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminUserStore(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(ApplicationUser user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return Task.FromResult(0);
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            var applicationList = _dbContext.ApplicationLists.Where(x=>x.UserId.Equals(user.Id));
            _dbContext.ApplicationLists.RemoveRange(applicationList);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return Task.FromResult(0);
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return Task.FromResult(_dbContext.Users.Find(userId));
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return Task.FromResult(_dbContext.Users.FirstOrDefault(x=>x.UserName.Equals(userName)));
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            _dbContext.SaveChanges();
            return Task.FromResult(0);
        }

        #region Core.Interface.IStore

        public Task<ApplicationUser> DeleteElement(ApplicationUser key)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> CreateElement(string element)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ApplicationUser>> GetCollection()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ApplicationUser>> GetCollection(Func<ApplicationUser, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ApplicationUser>> GetCollection(List<Func<ApplicationUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetElement(string Key)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetElement(Func<ApplicationUser, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetElement(List<Func<ApplicationUser, bool>> predicates)
        {
            throw new NotImplementedException();
        }



        public Task<ApplicationUser> UpdateElement(string key, ApplicationUser element)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
