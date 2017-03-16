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
        public Task<Application> CreateElement(Application element)
        {
            _dbContext.Applications.Add(element);
            _dbContext.SaveChanges();
            return Task.FromResult(element);
        }

        public Task<bool> DeleteElement(string key)
        {
            try
            {
                var application = _dbContext.Applications.Find(key);
                if(application != null)
                {
                    _dbContext.Applications.Remove(application);
                    _dbContext.SaveChanges();
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
        
        public Task<ICollection<Application>> GetCollection()
        {
            return Task.FromResult(_dbContext.Applications as ICollection<Application>);
        }

        public Task<ICollection<Application>> GetCollection(Expression<Func<Application, bool>> predicate)
        {
            return Task.FromResult(_dbContext.Applications.Where(predicate) as ICollection<Application>);
        }

        public Task<Application> GetElement(string Key)
        {
            return _dbContext.Applications.FindAsync(Key);
        }

        public Task<Application> GetElement(Expression<Func<Application, bool>> predicate)
        {
            return _dbContext.Applications.FirstOrDefaultAsync(predicate);
        }

        public Task<Application> GetElementByExpression(Expression<Func<Application, bool>> predicate)
        {
            return _dbContext.Applications.FirstOrDefaultAsync(predicate);
        }

        public Task<Application> UpdateElement(string key, Application element)
        {
            _dbContext.Applications.Attach(element);
            _dbContext.Entry(element).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Task.FromResult(element);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
