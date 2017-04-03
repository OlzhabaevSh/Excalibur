using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Models
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<ApplicationList> ApplicationLists { get; set; }

        public virtual DbSet<Application> Applications { get; set; }

        public virtual DbSet<ApplicationRoles> ApplicationRoles { get; set; }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}
