using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class Task
    {
        public Task()
        {
            Categories = new List<Category>();
            IsMasterTask = false;
            IsGoalStep = false;
            IsRecurring = false;
            TaskRecurrence = null;
        }

        public long TaskID { get; set; }
        public bool IsMasterTask { get; set; }
        public bool IsGoalStep { get; set; }
        public string TaskName { get; set; }
        public string TaskNotes { get; set; }
        public DateTime TaskDate { get; set; }
        public TaskPriorities Priority { get; set; }
        public string PriorityText {get;set;}
        public int PriorityID { get; set; }
        public TaskStatuses Status { get; set; }
        public int StatusID  { get; set; }
        public string StatusText {get;set;}
        public bool IsRecurring { get; set; }
        public ISchedule TaskRecurrence { get; set; }

        public AppUser ForUser { get; set; }
        public List<Category> Categories { get; set; }
    }
}
