using Core.Admin.Interfaces;
using Core.Admin.Models;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Managers
{
    public class ApplicationManager : IApplicationManagerAdmin<Application, string>
    {
        private readonly IStore<Application, string> _store;

        public ApplicationManager(IStore<Application, string> store)
        {
            _store = store;
        }

        public Task<Application> Create(Application entity)
        {
            return _store.CreateElement(entity);
        }

        public Task<bool> Delete(string key)
        {
            var task = _store.DeleteElement(key);
            return Task.FromResult(!task.IsFaulted);
        }        

        public Task<Application> FindById(string key)
        {
            return _store.GetElement(key);
        }

        public Task<ICollection<Application>> GetCollection()
        {
            return _store.GetCollection();
        }

        public Task<Application> Update(Application entity)
        {
            return _store.UpdateElement(entity.Id, entity);
        }

        public void Dispose()
        {
            _store.Dispose();
        }
    }
}
