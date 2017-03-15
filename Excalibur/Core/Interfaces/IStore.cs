using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStore<TSourse, TKey>: IDisposable
    {
        Task<TSourse> GetElement(TKey Key);

        Task<TSourse> GetElement(Expression<Func<TSourse, bool>> predicate);

        Task<TSourse> GetElementByExpression(Expression<Func<TSourse, bool>> predicate);

        Task<ICollection<TSourse>> GetCollection();

        Task<ICollection<TSourse>> GetCollection(Expression<Func<TSourse, bool>> predicate);
        
        Task<TSourse> CreateElement(TSourse element);

        Task<TSourse> UpdateElement(TKey key, TSourse element);

        Task<TSourse> DeleteElement(TKey key);
    }
}
