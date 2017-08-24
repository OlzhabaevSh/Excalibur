using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excalibur.Utilities.CleverDAL.ADO.Models
{
    public class StorageProcedurePostModel
    {
        public string Name { get; set; }

        public List<StorageProcedureParameterPostModel> Parameters { get; set; }
    }
}
