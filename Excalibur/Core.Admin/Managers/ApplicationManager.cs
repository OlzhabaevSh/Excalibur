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

        public async Task<Application> Create(Application entity)
        {
            var guidToken = Guid.NewGuid().ToString();
            var id = Guid.NewGuid().ToString();
            entity.Id = id;
            entity.Token = guidToken;
            var application = await _store.CreateElement(entity);
            return application;
        }

        public async Task<bool> Delete(string key)
        {
            var isSuccess = await _store.DeleteElement(key);
            return isSuccess;
        }        

        public async Task<Application> FindById(string key)
        {
            var element = await _store.GetElement(key);
            return element;
        }

        public async Task<ICollection<Application>> GetCollection()
        {
            var applications = await _store.GetCollection();
            return applications;
        }

        public async Task<Application> Update(Application entity)
        {
            var element = await _store.UpdateElement(entity.Id, entity);
            return element;
        }

        public void Dispose()
        {
            _store.Dispose();
        }
    }
}
