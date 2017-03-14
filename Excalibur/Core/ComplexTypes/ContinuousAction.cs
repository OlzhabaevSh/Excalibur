using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ComplexTypes
{
    [ComplexType]
    public class ContinuousAction
    {
        public DateTime? PlanStartDate { get; set; }
        public DateTime? PlanFinishDate { get; set; }
        public DateTime? FactStartDate { get; set; }
        public DateTime? FactFinishDate { get; set; }

        public bool? IsFinished { get; set; }
    }
}
