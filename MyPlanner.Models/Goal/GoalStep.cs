using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class GoalStep 
    {
        public long GoalStepID { get; set; }
        public int Sequence { get; set; }
        public Task taskInfo { get; set; }
    }
}
