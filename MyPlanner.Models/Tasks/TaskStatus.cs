using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    /* 
      * Values for this class are
      * Normal
      * InProgress
      * Completed
      * Forwarded
      * Delegated
      * Deleted=6
     */
    [Serializable]
    public class TaskStatus
    {

        public TaskStatus()
        {
        }

        public TaskStatus(int ID)
        {
            TaskStatusID = ID;
            TaskStatusName = "Normal";
        }

        public int TaskStatusID { get; set; }
        public string TaskStatusName { get; set; }
        public int Sequence { get; set; }
        public bool IsCompletedStep { get; set; }
    }
}
