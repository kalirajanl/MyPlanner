using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using System.Data;

namespace MyPlanner.DAL
{
    public class DALTask
    {
        public static List<Task> GetTasks(int ForUserID, List<Category> ForCategories, DateTime forDate, bool addAsOfDateOverDueTasks, bool addBlank)
        {
            List<Task> Tasks = new List<Task>();

            DataTable dtTasks = null;

            if (addAsOfDateOverDueTasks)
            {
                dtTasks = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "TSK_Tasks", FilterCondition = "IsGoalStep = 0 AND UserID = " + ForUserID + " AND ((TaskDate = '" + forDate.ToString(Constants.DATE_FORMAT_SQL) + "') OR (TaskDate <= '" + forDate.ToString(Constants.DATE_FORMAT_SQL) + "') AND TaskStatusID in (SELECT TaskStatusID FROM TSK_TaskStatuses WHERE IsCompletedStatus != 1))", OrderBy = "TaskDate,TaskPriorityID" });
            }
            else
            {
                dtTasks = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "TSK_Tasks", FilterCondition = "IsGoalStep = 0 AND UserID = " + ForUserID + " AND TaskDate = '" + forDate.ToString(Constants.DATE_FORMAT_SQL) + "'", OrderBy = "TaskPriorityID" });
            }


            for (int i = 0; i <= dtTasks.Rows.Count - 1; i++)
            {
                Tasks.Add(loadTask(dtTasks, i));
            }
            if (addBlank)
            {
                if (dtTasks.Rows.Count < 13)
                {
                    for (int i = dtTasks.Rows.Count; i < 13; i++)
                    {
                        Tasks.Add(new Task { TaskID = (0 - (i + 1)) });
                    }
                }
            }

            return Tasks;
        }

        public static Task GetTaskByID(long TaskID)
        {
            Task task = null;
            DataTable dtTasks = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "TSK_Tasks", FilterCondition = "TaskID = " + TaskID.ToString(), OrderBy = "TaskPriorityID" });
            if (dtTasks.Rows.Count > 0)
            {
                task = loadTask(dtTasks, 0);
            }
            return task;
        }

        public static long AddTask(Task task)
        {
            long taskID = getNextTaskID();

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new InsertQueryData();
            queryData.TableName = "TSK_Tasks";
            queryData.Fields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = taskID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = task.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "IsMasterTask", FieldType = SqlDbType.Bit, FieldValue = task.IsMasterTask ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "IsGoalStep", FieldType = SqlDbType.Bit, FieldValue = task.IsGoalStep ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "IsRecurring", FieldType = SqlDbType.Bit, FieldValue = task.IsRecurring ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "ScheduleID", FieldType = SqlDbType.Int, FieldValue = "0" });
            queryData.Fields.Add(new FieldData { FieldName = "TaskName", FieldType = SqlDbType.NVarChar, FieldValue = task.TaskName.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskNotes", FieldType = SqlDbType.NVarChar, FieldValue = task.TaskNotes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskDate", FieldType = SqlDbType.Date, FieldValue = task.TaskDate.ToString(Constants.DATE_FORMAT_SQL) });
            queryData.Fields.Add(new FieldData { FieldName = "TaskPriorityID", FieldType = SqlDbType.Int, FieldValue = ((int)task.Priority).ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskStatusID", FieldType = SqlDbType.Int, FieldValue = ((int)task.Status).ToString() });
            queryDatum.Add(queryData);

            for (int i = 0; i <= task.Categories.Count - 1; i++)
            {
                queryData = new InsertQueryData();

                queryData.TableName = "TSK_TaskCategories";
                queryData.Fields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = taskID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "CategoryID", FieldType = SqlDbType.Int, FieldValue = task.Categories[i].CategoryID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = (i + 1).ToString() });
                queryDatum.Add(queryData);
            }

            SQLWrapper.ExecuteQuery(queryDatum);

            return taskID;
        }

        public static bool UpdateTask(Task task)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();
            IBaseQueryData queryData = new UpdateQueryData();

            queryData.TableName = "TSK_Tasks";
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = task.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "IsMasterTask", FieldType = SqlDbType.Bit, FieldValue = task.IsMasterTask ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "IsGoalStep", FieldType = SqlDbType.Bit, FieldValue = task.IsGoalStep ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "IsRecurring", FieldType = SqlDbType.Bit, FieldValue = task.IsRecurring ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "ScheduleID", FieldType = SqlDbType.Int, FieldValue = "0" });
            queryData.Fields.Add(new FieldData { FieldName = "TaskName", FieldType = SqlDbType.NVarChar, FieldValue = task.TaskName.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskNotes", FieldType = SqlDbType.NVarChar, FieldValue = task.TaskNotes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskDate", FieldType = SqlDbType.Date, FieldValue = task.TaskDate.ToString(Constants.DATE_FORMAT_SQL) });
            queryData.Fields.Add(new FieldData { FieldName = "TaskPriorityID", FieldType = SqlDbType.Int, FieldValue = ((int)task.Priority).ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskStatusID", FieldType = SqlDbType.Int, FieldValue = ((int)task.Status).ToString() });

            queryData.KeyFields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = task.TaskID.ToString() });

            queryDatum.Add(queryData);

            queryData = new DeleteQueryData();
            queryData.TableName = "TSK_TaskCategories";
            queryData.KeyFields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = task.TaskID.ToString() });

            queryDatum.Add(queryData);

            for (int i = 0; i <= task.Categories.Count - 1; i++)
            {
                queryData = new InsertQueryData();

                queryData.TableName = "TSK_TaskCategories";
                queryData.Fields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = task.TaskID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "CategoryID", FieldType = SqlDbType.Int, FieldValue = task.Categories[i].CategoryID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = (i + 1).ToString() });
                queryDatum.Add(queryData);
            }

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool UpdateTaskStatus(long taskID, TaskStatuses withStatus)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();
            IBaseQueryData queryData = new UpdateQueryData();

            queryData.TableName = "TSK_Tasks";
            queryData.Fields.Add(new FieldData { FieldName = "TaskStatusID", FieldType = SqlDbType.Int, FieldValue = ((int)withStatus).ToString() });

            queryData.KeyFields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = taskID.ToString() });
            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteTask(Task task)
        {
            return SQLWrapper.ExecuteQuery(PrepareDeleteTaskQueries(task));
        }

        public static List<IBaseQueryData> PrepareDeleteTaskQueries(Task task)
        {
            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            DeleteQueryData queryData = new DeleteQueryData();
            queryData.TableName = "TSK_TaskCategories";
            queryData.KeyFields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = task.TaskID.ToString() });
            queryDatum.Add(queryData);

            queryData = new DeleteQueryData();
            queryData.TableName = "TSK_Tasks";
            queryData.KeyFields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = task.TaskID.ToString() });
            queryDatum.Add(queryData);

            return queryDatum;
        }

        public static List<IBaseQueryData> PrepareDeleteTaskQueries(long TaskID)
        {
            return PrepareDeleteTaskQueries(GetTaskByID(TaskID));
        }

        public static bool DeleteTask(long TaskID)
        {
            return DeleteTask(GetTaskByID(TaskID));
        }

        #region Private Methods

        private static Task loadTask(DataTable dtTasks, int RowNo)
        {
            Task task = new Task();
            task.TaskID = Convert.ToInt32(dtTasks.Rows[RowNo]["TaskID"]);
            task.ForUser = DALAppUser.GetUserByID( Convert.ToInt32(dtTasks.Rows[RowNo]["UserID"]));
            task.TaskName = dtTasks.Rows[RowNo]["TaskName"].ToString();
            task.TaskNotes = dtTasks.Rows[RowNo]["TaskNotes"].ToString();
            task.TaskDate = Convert.ToDateTime(dtTasks.Rows[RowNo]["TaskDate"]);
            task.Priority = (TaskPriorities)Convert.ToInt32(dtTasks.Rows[RowNo]["TaskPriorityID"]);
            task.PriorityText = task.Priority.ToString();
            task.PriorityID = Convert.ToInt32(dtTasks.Rows[RowNo]["TaskPriorityID"]);
            task.Status = (TaskStatuses)Convert.ToInt32(dtTasks.Rows[RowNo]["TaskStatusID"]);
            task.StatusID = Convert.ToInt32(dtTasks.Rows[RowNo]["TaskStatusID"]);
            task.StatusText = task.Status.ToString();

            task.Categories = loadTaskCategories(task.TaskID);
            return task;
        }

        private static List<Category> loadTaskCategories(long taskID)
        {
            List<Category> taskCategories = new List<Category>();
            DataTable dtTaskCategories = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "TSK_TaskCategories", FilterCondition = "TaskID = " + taskID.ToString(), OrderBy = "Sequence" });
            for (int i = 0; i <= dtTaskCategories.Rows.Count - 1; i++)
            {
                taskCategories.Add(DALCategory.GetCategoryByID(Convert.ToInt32(dtTaskCategories.Rows[i]["CategoryID"])));
            }
            return taskCategories;
        }

        public static long getNextTaskID()
        {
            long nextID = 1;
            DataTable dtTasks = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "TSK_Tasks", FieldNames = "Max(TaskID)" });
            if (dtTasks.Rows.Count > 0)
            {
                if (dtTasks.Rows[0][0] != DBNull.Value)
                {
                    nextID = ((long)(Convert.ToDecimal(dtTasks.Rows[0][0]))) + 1;
                }
            }
            return nextID;
        }

        #endregion
    }
}
