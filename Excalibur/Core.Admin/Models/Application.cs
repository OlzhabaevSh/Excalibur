using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Url { get; set; }
        
        public virtual ICollection<ApplicationRoles> Roles { get; set; }

        public virtual ICollection<ApplicationList> ApplicationList { get; set; }
    }
}
