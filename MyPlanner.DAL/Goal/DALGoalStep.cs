using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using System.Data;

namespace MyPlanner.DAL
{
    public class DALGoalStep
    {

        public static List<GoalStep> GetGoalStepsByGoalID(int goalID)
        {
            List<GoalStep> goalSteps = new List<GoalStep>();

            DataTable dtGoalSteps = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_GoalSteps", FilterCondition = "GoalID = " + goalID.ToString(), OrderBy = "Sequence" });

            for (int i = 0; i <= dtGoalSteps.Rows.Count - 1; i++)
            {
                goalSteps.Add(loadGoalStep(dtGoalSteps, i));
            }
            return goalSteps;
        }

        public static GoalStep GetGoalStepByID(int goalStepID)
        {
            GoalStep goalStep = new GoalStep();

            DataTable dtGoalSteps = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_GoalSteps", FilterCondition = "GoalStepID = " + goalStepID.ToString(), OrderBy = "Sequence" });

            if (dtGoalSteps.Rows.Count > 0)
            {
                goalStep = loadGoalStep(dtGoalSteps, 0);
            }
            return goalStep;
        }

        public static bool AddGoalStep(int GoalID, GoalStep goalStep)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new InsertQueryData();

            long taskID = DALTask.getNextTaskID();

            queryData = new InsertQueryData();
            queryData.TableName = "TSK_Tasks";
            queryData.Fields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = taskID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = goalStep.taskInfo.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "IsMasterTask", FieldType = SqlDbType.Bit, FieldValue = goalStep.taskInfo.IsMasterTask ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "IsGoalStep", FieldType = SqlDbType.Bit, FieldValue = "1" });
            queryData.Fields.Add(new FieldData { FieldName = "IsRecurring", FieldType = SqlDbType.Bit, FieldValue = goalStep.taskInfo.IsRecurring ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "ScheduleID", FieldType = SqlDbType.Int, FieldValue = "0" });
            queryData.Fields.Add(new FieldData { FieldName = "TaskName", FieldType = SqlDbType.NVarChar, FieldValue = goalStep.taskInfo.TaskName.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskNotes", FieldType = SqlDbType.NVarChar, FieldValue = goalStep.taskInfo.TaskNotes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskDate", FieldType = SqlDbType.Date, FieldValue = goalStep.taskInfo.TaskDate.ToString(Constants.DATE_FORMAT_SQL) });
            queryData.Fields.Add(new FieldData { FieldName = "TaskPriorityID", FieldType = SqlDbType.Int, FieldValue = ((int)goalStep.taskInfo.Priority).ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskStatusID", FieldType = SqlDbType.Int, FieldValue = ((int)goalStep.taskInfo.Status).ToString() });
            queryDatum.Add(queryData);

            for (int j = 0; j <= goalStep.taskInfo.Categories.Count - 1; j++)
            {
                queryData = new InsertQueryData();

                queryData.TableName = "TSK_TaskCategories";
                queryData.Fields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = taskID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "CategoryID", FieldType = SqlDbType.Int, FieldValue = goalStep.taskInfo.Categories[j].CategoryID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = (j + 1).ToString() });
                queryDatum.Add(queryData);
            }

            queryData = new InsertQueryData();

            queryData.TableName = "PLN_GoalSteps";
            queryData.Fields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = GoalID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Decimal, FieldValue = taskID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = getNextSequence(GoalID).ToString() });
            queryDatum.Add(queryData);

            SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool UpdateGoalStep(int GoalID, GoalStep goalStep)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new UpdateQueryData();

            queryData = new UpdateQueryData();
            queryData.TableName = "TSK_Tasks";
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = goalStep.taskInfo.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "IsMasterTask", FieldType = SqlDbType.Bit, FieldValue = goalStep.taskInfo.IsMasterTask ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "IsGoalStep", FieldType = SqlDbType.Bit, FieldValue = "1" });
            queryData.Fields.Add(new FieldData { FieldName = "IsRecurring", FieldType = SqlDbType.Bit, FieldValue = goalStep.taskInfo.IsRecurring ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "ScheduleID", FieldType = SqlDbType.Int, FieldValue = "0" });
            queryData.Fields.Add(new FieldData { FieldName = "TaskName", FieldType = SqlDbType.NVarChar, FieldValue = goalStep.taskInfo.TaskName.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskNotes", FieldType = SqlDbType.NVarChar, FieldValue = goalStep.taskInfo.TaskNotes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskDate", FieldType = SqlDbType.Date, FieldValue = goalStep.taskInfo.TaskDate.ToString(Constants.DATE_FORMAT_SQL) });
            queryData.Fields.Add(new FieldData { FieldName = "TaskPriorityID", FieldType = SqlDbType.Int, FieldValue = ((int)goalStep.taskInfo.Priority).ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskStatusID", FieldType = SqlDbType.Int, FieldValue = ((int)goalStep.taskInfo.Status).ToString() });

            queryData.KeyFields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = goalStep.taskInfo.TaskID.ToString() });
            queryDatum.Add(queryData);

            queryData = new DeleteQueryData();

            queryData.TableName = "TSK_TaskCategories";
            queryData.KeyFields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = goalStep.taskInfo.TaskID.ToString() });
            queryDatum.Add(queryData);

            for (int j = 0; j <= goalStep.taskInfo.Categories.Count - 1; j++)
            {
                queryData = new InsertQueryData();

                queryData.TableName = "TSK_TaskCategories";
                queryData.Fields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Int, FieldValue = goalStep.taskInfo.TaskID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "CategoryID", FieldType = SqlDbType.Int, FieldValue = goalStep.taskInfo.Categories[j].CategoryID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = (j + 1).ToString() });
                queryDatum.Add(queryData);
            }

            queryData = new UpdateQueryData();

            queryData.TableName = "PLN_GoalSteps";
            queryData.Fields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = GoalID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "TaskID", FieldType = SqlDbType.Decimal, FieldValue = goalStep.taskInfo.TaskID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = goalStep.Sequence.ToString() });

            queryData.KeyFields.Add(new FieldData { FieldName = "GoalStepID", FieldType = SqlDbType.Int, FieldValue = goalStep.GoalStepID.ToString() });
            queryDatum.Add(queryData);

            SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }


        public static bool DeleteGoalStep(GoalStep goalStep)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new DeleteQueryData();
            queryData.TableName = "PLN_GoalSteps";
            queryData.KeyFields.Add(new FieldData { FieldName = "GoalStepID", FieldType = SqlDbType.Int, FieldValue = goalStep.GoalStepID.ToString() });
            queryDatum.Add(queryData);

            SQLWrapper.ExecuteQuery(queryDatum);

            DALTask.DeleteTask(goalStep.taskInfo);

            return returnValue;
        }

        public static bool DeleteGoalStep(int goalStepID)
        {
            return DeleteGoalStep(GetGoalStepByID(goalStepID));
        }

        #region Private Methods

        private static List<GoalStep> loadGoalSteps(int GoalID)
        {
            List<GoalStep> GoalSteps = new List<GoalStep>();
            DataTable dtGoalSteps = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_GoalSteps", FilterCondition = "GoalID = " + GoalID.ToString(), OrderBy = "Sequence" });
            for (int i = 0; i <= dtGoalSteps.Rows.Count - 1; i++)
            {
                GoalSteps.Add(loadGoalStep(dtGoalSteps, i));
            }
            return GoalSteps;
        }

        private static GoalStep loadGoalStep(DataTable dtGoalSteps, int RowNo)
        {
            GoalStep goalStep = new GoalStep();
            goalStep.GoalStepID = Convert.ToInt32(dtGoalSteps.Rows[RowNo]["GoalStepID"]);
            goalStep.Sequence = Convert.ToInt32(dtGoalSteps.Rows[RowNo]["Sequence"]);
            goalStep.taskInfo = DALTask.GetTaskByID((long)Convert.ToDecimal(dtGoalSteps.Rows[RowNo]["TaskID"]));
            return goalStep;
        }

        private static int getNextSequence(int GoalID)
        {
            int nextID = 1;
            DataTable dtGoalSteps = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_GoalSteps", FieldNames="Max(Sequence)", FilterCondition = "GoalID = " + GoalID.ToString() });
            if (dtGoalSteps.Rows.Count > 0)
            {
                if (dtGoalSteps.Rows[0][0] != DBNull.Value)
                {
                    nextID = Convert.ToInt32(dtGoalSteps.Rows[0][0]) + 1;
                }
            }
            return nextID;

        }


        #endregion

    }
}
