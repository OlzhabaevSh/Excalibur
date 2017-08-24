using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excalibur.Utilities.Core.Providers
{
    public class StorageProcedureModel
    {
        public string Name { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}
