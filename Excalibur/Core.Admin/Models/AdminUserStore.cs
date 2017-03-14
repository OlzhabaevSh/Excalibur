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
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> CreateElement(string element)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> DeleteElement(ApplicationUser key)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
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

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> UpdateElement(string key, ApplicationUser element)
        {
            throw new NotImplementedException();
        }
    }
}
