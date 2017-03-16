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
    public class ApplicationListStore : IStore<ApplicationList, string>
    {

        private readonly ApplicationDbContext _dbContext;

        public ApplicationListStore(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationList>  CreateElement(ApplicationList element)
        {
            _dbContext.ApplicationLists.Add(element);
            var task = await _dbContext.SaveChangesAsync();
            return element;
        }

        public async Task<bool> DeleteElement(string key)
        {
            var appList = await _dbContext.ApplicationLists.FindAsync(key);
            if(appList != null)
            {
                _dbContext.ApplicationLists.Remove(appList);
                return true;
            }
            return false;
        }       

        public async Task<ICollection<ApplicationList>> GetCollection()
        {
            return _dbContext.ApplicationLists.ToList();
        }

        public async Task<ICollection<ApplicationList>> GetCollection(Expression<Func<ApplicationList, bool>> predicate)
        {
            return _dbContext.ApplicationLists.Where(predicate).ToList();
        }

        public Task<ApplicationList> GetElement(string Key)
        {
            return _dbContext.ApplicationLists.FindAsync(Key);
        }

        public Task<ApplicationList> GetElement(Expression<Func<ApplicationList, bool>> predicate)
        {
            return _dbContext.ApplicationLists.FirstOrDefaultAsync(predicate);
        }

        public Task<ApplicationList> GetElementByExpression(Expression<Func<ApplicationList, bool>> predicate)
        {
            return _dbContext.ApplicationLists.FirstOrDefaultAsync(predicate);
        }

        public async Task<ApplicationList> UpdateElement(string key, ApplicationList element)
        {
            _dbContext.ApplicationLists.Attach(element);
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
