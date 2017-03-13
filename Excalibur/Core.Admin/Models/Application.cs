using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Models
{
    public class Application
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Token { get; set; }

        public virtual ICollection<ApplicationList> ApplicationList { get; set; }
    }
}
