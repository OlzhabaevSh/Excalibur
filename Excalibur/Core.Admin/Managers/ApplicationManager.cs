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
        private readonly IStore<Application, string> _applicationStore;
        private readonly IStore<ApplicationList, int> _applicationListStore;

        public ApplicationManager(
            IStore<Application, string> applicationStore,
            IStore<ApplicationList, int> applicationListStore)
        {
            _applicationStore = applicationStore;
            _applicationListStore = applicationListStore;
        }

        #region Application
        public async Task<Application> Create(Application entity)
        {
            var guidToken = Guid.NewGuid().ToString();
            var id = Guid.NewGuid().ToString();
            entity.Id = id;
            entity.Token = guidToken;
            var application = await _applicationStore.CreateElement(entity);
            return application;
        }

        public async Task<bool> Delete(string key)
        {
            var isSuccess = await _applicationStore.DeleteElement(key);
            return isSuccess;
        }        

        public async Task<Application> FindById(string key)
        {
            var element = await _applicationStore.GetElement(key);
            return element;
        }

        public async Task<ICollection<Application>> GetCollection()
        {
            var applications = await _applicationStore.GetCollection();
            return applications;
        }

        public async Task<Application> Update(Application entity)
        {
            var element = await _applicationStore.UpdateElement(entity.Id, entity);
            return element;
        }
        #endregion
        #region ApplicationList
        public async Task<ICollection<ApplicationList>> GetApplicationListCollectionByRoleAndUser(string roleKey, string userKey)
        {
            ICollection<ApplicationList> applicationLists = new List<ApplicationList>();
            if(!string.IsNullOrEmpty(roleKey) && !string.IsNullOrEmpty(userKey))
            {
                applicationLists = await _applicationListStore.GetCollection(appList => appList.RoleId.Equals(roleKey) && appList.UserId.Equals(userKey));
            }
            else if(!string.IsNullOrEmpty(roleKey) && string.IsNullOrEmpty(userKey))
            {
                applicationLists = await _applicationListStore.GetCollection(appList => appList.RoleId.Equals(roleKey));
            }
            else if (string.IsNullOrEmpty(roleKey) && !string.IsNullOrEmpty(userKey))
            {
                applicationLists = await _applicationListStore.GetCollection(appList => appList.UserId.Equals(userKey));
            }
            else
            {
                applicationLists = await _applicationListStore.GetCollection();
            }
            return applicationLists;
        }

        public async Task<ApplicationList> GetApplicationListById(int appListId)
        {
            var applicationList = await _applicationListStore.GetElement(appListId);
            return applicationList;
        }

        public async Task<ApplicationList> CreateApplicationList(ApplicationList appList)
        {
            var applicationList = await _applicationListStore.CreateElement(appList);
            return applicationList;
        }

        public async Task<ApplicationList> UpdateApplicationList(ApplicationList appList)
        {
            var applicationList = await _applicationListStore.UpdateElement(appList.Id, appList);
            return applicationList;
        }

        public async Task<bool> DeleteApplicationList(int appListId)
        {
            var isDeleted = await _applicationListStore.DeleteElement(appListId);
            return isDeleted;
        }
        #endregion

        public void Dispose()
        {
            _applicationStore.Dispose();
        }        
    }
}
