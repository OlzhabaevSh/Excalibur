using Core.Admin.Extensions;
using Core.Admin.Interfaces;
using Core.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Models
{
    public class AdminUserStore : IUserStoreAdmin
    {
        private readonly ApplicationDbContext _dbContext;
        UserStore<IdentityUser> _userStore = new UserStore<IdentityUser>(new ApplicationDbContext());

        public AdminUserStore(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Identity.IUserStore
        public Task CreateAsync(ApplicationUser user)
        {            
            _dbContext.Users.Add(user);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            var applicationList = _dbContext.ApplicationLists.Where(x=>x.UserId.Equals(user.Id));
            _dbContext.ApplicationLists.RemoveRange(applicationList);
            _dbContext.Users.Remove(user);
            return _dbContext.SaveChangesAsync();
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
            _dbContext.Users.Attach(user);
            _dbContext.Entry(user).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }
        #endregion        
        
        #region Identity.IUserPasswordStore
        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            var task = _userStore.SetPasswordHashAsync(user.ToIdentityUser(),passwordHash);
            SetApplicationUser(user,user.ToIdentityUser());
            return task;
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            var task = _userStore.GetPasswordHashAsync(user.ToIdentityUser());
            SetApplicationUser(user, user.ToIdentityUser());            
            return task;
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            var task = _userStore.HasPasswordAsync(user.ToIdentityUser());
            SetApplicationUser(user, user.ToIdentityUser());
            return task;
        }
        #endregion
        
        #region Identity.IUserEmailStore
        public Task SetEmailAsync(ApplicationUser user, string email)
        {
            var task = _userStore.SetEmailAsync(user.ToIdentityUser(), email);
            SetApplicationUser(user, user.ToIdentityUser());
            return task;
        }

        public Task<string> GetEmailAsync(ApplicationUser user)
        {
            var task = _userStore.GetEmailAsync(user.ToIdentityUser());
            SetApplicationUser(user, user.ToIdentityUser());
            return task;
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
        {
            var task = _userStore.GetEmailConfirmedAsync(user.ToIdentityUser());
            SetApplicationUser(user, user.ToIdentityUser());
            return task;
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            var task = _userStore.SetEmailConfirmedAsync(user.ToIdentityUser(), confirmed);
            SetApplicationUser(user, user.ToIdentityUser());
            return task;
        }

        public Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return Task.FromResult(_dbContext.Users.FirstOrDefault(x=>x.Email.Equals(email)));
        }
        #endregion
         
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
            _userStore.Dispose();
        }

        #region private helpers
        private static void SetApplicationUser(ApplicationUser user, IdentityUser identityUser)
        {
            user.PasswordHash = identityUser.PasswordHash;           
            user.Id = identityUser.Id;
            user.UserName = identityUser.UserName;
        }
        #endregion
    }
}
