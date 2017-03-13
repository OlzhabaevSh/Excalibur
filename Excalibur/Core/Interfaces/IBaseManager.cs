using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseManager<TSource, TKey>
    {
        IStore<TSource, TKey> Store { get; }

        TSource Find(TKey key);
    }
}
