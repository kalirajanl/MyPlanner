using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using MyPlanner.DAL;

namespace MyPlanner.BLL
{
    public class BLLTaskStatus
    {
        public static List<TaskStatus> GetTaskStatuses()
        {
            return DALTaskStatus.GetTaskStatuses();
        }
    }
}
