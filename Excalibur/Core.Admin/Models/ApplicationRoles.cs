﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Models
{
    public class ApplicationRoles: IdentityRole
    {
        public virtual ICollection<Application> Applications { get; set; }
    }
}
