using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Models
{
    public class ApplicationList
    {
        public int Id { get; set; }

        [ForeignKey("Application")]
        public string ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public virtual ApplicationRoles Role { get; set; }


    }
}
