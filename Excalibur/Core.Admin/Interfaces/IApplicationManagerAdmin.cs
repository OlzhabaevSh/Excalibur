using Core.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Interfaces
{
    public interface IApplicationManagerAdmin<TSource, TKey> : IDisposable
    {
        Task<ICollection<TSource>> GetCollection();

        Task<TSource> FindById(TKey key);

        Task<TSource> Create(TSource entity);

        Task<bool> Delete(TKey key);

        Task<TSource> Update(TSource entity);

        Task<ICollection<ApplicationList>> GetApplicationListCollectionByRoleAndUser(string roleKey, string userKey);

        Task<ApplicationList> GetApplicationListById(int appListId);

        Task<ApplicationList> CreateApplicationList(ApplicationList appList);

        Task<ApplicationList> UpdateApplicationList(ApplicationList appList);

        Task<bool> DeleteApplicationList(int appListId);
    }
}
