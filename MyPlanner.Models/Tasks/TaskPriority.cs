using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    /* 
     * Values for this class are
     * A
     * A1
     * A2
     * A3
     * B
     * B1
     * B2
     * B3
     * C
     * C1
     * C2
     * C3
    */
    [Serializable]
    public class TaskPriority
    {
        public TaskPriority()
        {
        }

        public TaskPriority(int ID)
        {
            TaskPriorityID = ID;
            TaskPriorityName = "A";
        }

        public int TaskPriorityID { get; set; }
        public string TaskPriorityName { get; set; }
        public int Sequence { get; set; }
    }
}
