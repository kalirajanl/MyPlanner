using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using System.Data;

namespace MyPlanner.DAL
{
    public class DALTaskStatus
    {
        public static List<TaskStatus> GetTaskStatuses()
        {
            List<TaskStatus> Statuses = new List<TaskStatus>();

            //new QueryData{TableName="",FieldNames="",FilterCondition="",OrderBy=""}
            DataTable dtStatuses = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "TSK_TaskStatuses",  FilterCondition = "", OrderBy = "Sequence" });
            for (int i = 0; i <= dtStatuses.Rows.Count - 1; i++)
            {
                Statuses.Add(new TaskStatus { TaskStatusID = Convert.ToInt32(dtStatuses.Rows[i]["TaskStatusID"]), TaskStatusName = dtStatuses.Rows[i]["TaskStatusName"].ToString(), Sequence = Convert.ToInt32(dtStatuses.Rows[i]["Sequence"]), IsCompletedStep = Convert.ToBoolean(dtStatuses.Rows[i]["IsCompletedStatus"]) });
            }

            return Statuses;
        }
    }
}
