using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ComplexTypes
{
    [ComplexType]
    public class ItemChangeInfo
    {
        public DateTime? CreatedDate { get; set; }
        public string CreatedUserId { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
        public string LastUpdatedUserId { get; set; }

        public DateTime? DeletedDate { get; set; }
        public string DeletedUserId { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
