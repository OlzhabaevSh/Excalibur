using Core.Admin.Models;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Core.Admin.Stores
{
    public class ApplicationStore : IStore<Application, string>
    {
        private readonly ApplicationDbContext _dbContext;
        public ApplicationStore(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Application> CreateElement(Application element)
        {
            _dbContext.Applications.Add(element);
            _dbContext.SaveChanges();
            return element;
        }

        public async Task<bool> DeleteElement(string key)
        {
            try
            {
                var application = _dbContext.Applications.Find(key);
                if(application != null)
                {
                     _dbContext.Applications.Remove(application);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public async Task<ICollection<Application>> GetCollection()
        {
            return _dbContext.Applications.ToList() as ICollection<Application>;
        }

        public async Task<ICollection<Application>> GetCollection(Expression<Func<Application, bool>> predicate)
        {
            return _dbContext.Applications.Where(predicate).ToList() as ICollection<Application>;
        }

        public Task<Application> GetElement(string Key)
        {
            return _dbContext.Applications.FindAsync(Key);
        }

        public Task<Application> GetElement(Expression<Func<Application, bool>> predicate)
        {
            return  _dbContext.Applications.FirstOrDefaultAsync(predicate);
        }

        public Task<Application> GetElementByExpression(Expression<Func<Application, bool>> predicate)
        {
            return _dbContext.Applications.FirstOrDefaultAsync(predicate);
        }

        public async Task<Application> UpdateElement(string key, Application element)
        {
            _dbContext.Applications.Attach(element);
            _dbContext.Entry(element).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return element;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<ICollection<string>> DeleteCollection(ICollection<string> deleteCollection)
        {
            var appList = _dbContext.Applications.Where(a => deleteCollection.Contains(a.Id));
            _dbContext.Applications.RemoveRange(appList);
            _dbContext.SaveChanges();
            return appList.Select(a => a.Id).ToList();
        }
    }
}
