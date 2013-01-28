using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class Goal
    {
        public Goal()
        {
            Categories = new List<Category>();
            Steps = new List<GoalStep>();
        }

        public int GoalID { get; set; }
        public string GoalSubject { get; set; }
        public string GoalReason {get;set;}
        public string GoalNotes { get; set; }
        public DateTime DueOn { get; set; }
        public bool IsCompleted { get; set; }
        public int Sequence { get; set; }
        
        public List<GoalStep> Steps { get; set; }

        public AppUser ForUser { get; set; }
        public List<Category> Categories { get; set; }
    }
}
