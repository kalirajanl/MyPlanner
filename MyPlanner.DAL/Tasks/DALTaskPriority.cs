using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using System.Data;

namespace MyPlanner.DAL
{
    public class DALTaskPriority
    {

        public static List<TaskPriority> GetTaskPriorities()
        {
            List<TaskPriority> Priorities = new List<TaskPriority>();

            DataTable dtPriorities = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "TSK_TaskPriorities",  FilterCondition = "", OrderBy = "Sequence" });
            for (int i = 0; i <= dtPriorities.Rows.Count - 1; i++)
            {
                Priorities.Add(new TaskPriority { TaskPriorityID = Convert.ToInt32(dtPriorities.Rows[i]["TaskPriorityID"]), TaskPriorityName = dtPriorities.Rows[i]["TaskPriority"].ToString(), Sequence = Convert.ToInt32(dtPriorities.Rows[i]["Sequence"]) });
            }

            return Priorities;
        }

    }
}
