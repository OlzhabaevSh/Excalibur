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
    }
}
