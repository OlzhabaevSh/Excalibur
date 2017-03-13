using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStore<TSourse, TKey>: IDisposable
    {
        Task<TSourse> GetElement(TKey Key);

        Task<TSourse> GetElement(Func<TSourse, bool> predicate);

        Task<TSourse> GetElement(List<Func<TSourse, bool>> predicates);

        Task<ICollection<TSourse>> GetCollection();

        Task<ICollection<TSourse>> GetCollection(Func<TSourse, bool> predicate);

        Task<ICollection<TSourse>> GetCollection(List<Func<TSourse, bool>> predicate);

        Task<TSourse> CreateElement(TKey element);

        Task<TSourse> UpdateElement(TKey key, TSourse element);

        Task<TSourse> DeleteElement(TSourse key);
    }
}
