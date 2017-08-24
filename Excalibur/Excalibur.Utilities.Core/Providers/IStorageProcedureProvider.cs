using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excalibur.Utilities.Core.Providers
{
    public interface IStorageProcedureProvider
    {
        string ConnectionString { get; set; }

        ICollection<StorageProcedureModel> GetStorageProcedureCollection();

        StorageProcedureModel GetStorageProcedure(string storageProcedureName);

        object[,] CallStorageProcedure(string storageProcedureName, Dictionary<string, object> parameters);
    }
}
