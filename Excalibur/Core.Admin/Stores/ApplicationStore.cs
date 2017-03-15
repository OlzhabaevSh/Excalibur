using Core.Admin.Models;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Core.Admin.Stores
{
    class ApplicationStore : IStore<Application, string>
    {
        public Task<Application> CreateElement(string element)
        {
            throw new NotImplementedException();
        }

        public Task<Application> DeleteElement(Application key)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Application>> GetCollection()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Application>> GetCollection(Func<Application, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Application>> GetCollection(List<Func<Application, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Application> GetElement(string Key)
        {
            throw new NotImplementedException();
        }

        public Task<Application> GetElement(Func<Application, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Application> GetElementByExpression(Expression<Func<Application, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Application> UpdateElement(string key, Application element)
        {
            throw new NotImplementedException();
        }
    }
}
