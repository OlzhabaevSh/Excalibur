using Excalibur.Utilities.CleverDAL.ADO.Models;
using Excalibur.Utilities.CleverDAL.ADO.Providers;
using Excalibur.Utilities.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Excalibur.Utilities.CleverDAL.ADO.Controllers
{
    public abstract class CleverStoreageProcedureController: ApiController
    {
        private readonly IStorageProcedureProvider _provider = new StorageProcedureProvider();

        public string ConnectionString { get; set; }

        public CleverStoreageProcedureController()
        {
        }

        [HttpGet]
        public virtual async Task<ICollection<StorageProcedureModel>> GetStorageProcedues()
        {
            _provider.ConnectionString = ConnectionString;
            return _provider.GetStorageProcedureCollection();
        }

        [HttpGet]
        public virtual async Task<StorageProcedureModel> GetStorageProcedure(string id)
        {
            _provider.ConnectionString = ConnectionString;
            return _provider.GetStorageProcedure(id);
        }

        [HttpPost]
        public virtual async Task<object[,]> PostStorageProcedure(StorageProcedurePostModel model)
        {
            _provider.ConnectionString = ConnectionString;
            var parameters = new Dictionary<string, object>();
            model.Parameters.ForEach(item =>
            {
                parameters.Add(item.Name, item.Value);
            });

            return _provider.CallStorageProcedure(model.Name, parameters);
        }
    }
}
