using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.ViewModels
{
    public class ApplicationListVM
    {
        public int Id { get; set; }

        public ApplicationUserVM User { get; set; }

        public RoleVM Role { get; set; }

        public ApplicationVM Application { get; set; }
    }
}
