using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using System.Data;

namespace MyPlanner.DAL
{
    public class DALGoal
    {
        public static List<Goal> GetGoalsForUser(int forUserID, List<Category> forCategories)
        {
            List<Goal> Goals = new List<Goal>();

            DataTable dtGoals = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_Goals", FilterCondition = "UserID = " + forUserID.ToString() , OrderBy = "Sequence" });

            for (int i = 0; i <= dtGoals.Rows.Count - 1; i++)
            {
                Goals.Add(loadGoal(dtGoals, i));
            }
            return Goals;
        }

        public static Goal GetGoalByID(int goalID)
        {
            Goal goal = null;
            DataTable dtGoals = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_Goals", FilterCondition = "GoalID = " + goalID.ToString()});
            if (dtGoals.Rows.Count > 0)
            {
                goal = loadGoal (dtGoals, 0);
            }
            return goal;
        }

        public static bool AddGoal(Goal goal)
        {
            bool returnValue = false;

            int goalID = getNextGoalID();

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new InsertQueryData();
            queryData.TableName = "PLN_Goals";
            queryData.Fields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = goalID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = goal.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "IsCompleted", FieldType = SqlDbType.Bit, FieldValue = goal.IsCompleted ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "GoalSubject", FieldType = SqlDbType.NVarChar, FieldValue = goal.GoalSubject.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "GoalReason", FieldType = SqlDbType.NVarChar, FieldValue = goal.GoalReason.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "GoalNotes", FieldType = SqlDbType.NVarChar, FieldValue = goal.GoalNotes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "DueOn", FieldType = SqlDbType.Date, FieldValue = goal.DueOn.ToString(Constants.DATE_FORMAT_SQL) });
            if (goal.Sequence <= 0)
            {
                goal.Sequence = GetGoalsForUser(goal.ForUser.UserID, null).Count + 1;
            }
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = goal.Sequence.ToString() });

            queryDatum.Add(queryData);

            for (int i = 0; i <= goal.Categories.Count - 1; i++)
            {
                queryData = new InsertQueryData();

                queryData.TableName = "PLN_GoalCategories";
                queryData.Fields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = goalID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "CategoryID", FieldType = SqlDbType.Int, FieldValue = goal.Categories[i].CategoryID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = (i + 1).ToString() });
                queryDatum.Add(queryData);
            }

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool SetGoalAsCompleted(int goalID)
        {
            bool returnValue = false;
            IBaseQueryData queryData = new UpdateQueryData();
            queryData.TableName = "PLN_Goals";

            queryData.Fields.Add(new FieldData { FieldName = "IsCompleted", FieldType = SqlDbType.Bit, FieldValue = "1" });
            queryData.KeyFields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = goalID.ToString() });

            returnValue = SQLWrapper.ExecuteQuery(queryData);

            if (returnValue)
            {
                Goal goal = GetGoalByID(goalID);
                for (int i = 0; i <= goal.Steps.Count - 1; i++)
                {
                    goal.Steps[i].taskInfo.Status = TaskStatuses.Completed;
                    DALGoalStep.UpdateGoalStep(goalID, goal.Steps[i]);
                }
            }

            return returnValue;
        }

        public static bool SetGoalDueDate(int goalID)
        {
            bool returnValue = false;

            DateTime goalDueDate = DALGoalStep.GetGoalDueDate(goalID);

            IBaseQueryData queryData = new UpdateQueryData();
            queryData.TableName = "PLN_Goals";

            queryData.Fields.Add(new FieldData { FieldName = "DueOn", FieldType = SqlDbType.Date, FieldValue = goalDueDate.ToString(Constants.DATE_FORMAT_SQL) });
            queryData.KeyFields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = goalID.ToString() });

            returnValue = SQLWrapper.ExecuteQuery(queryData);

            return returnValue;
        }

        public static bool UpdateGoal(Goal goal)
        {
            bool returnValue = false;
            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new UpdateQueryData();
            queryData.TableName = "PLN_Goals";
            queryData.Fields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = goal.GoalID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = goal.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "IsCompleted", FieldType = SqlDbType.Bit, FieldValue = goal.IsCompleted ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "GoalSubject", FieldType = SqlDbType.NVarChar, FieldValue = goal.GoalSubject.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "GoalReason", FieldType = SqlDbType.NVarChar, FieldValue = goal.GoalReason.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "GoalNotes", FieldType = SqlDbType.NVarChar, FieldValue = goal.GoalNotes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "DueOn", FieldType = SqlDbType.Date, FieldValue = goal.DueOn.ToString(Constants.DATE_FORMAT_SQL) });
            if (goal.Sequence <= 0)
            {
                goal.Sequence = GetGoalsForUser(goal.ForUser.UserID, null).Count + 1;
            }
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = goal.Sequence.ToString() });

            queryData.KeyFields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = goal.GoalID.ToString() });

            queryDatum.Add(queryData);

            queryData = new DeleteQueryData();
            queryData.TableName = "PLN_GoalCategories";
            queryData.KeyFields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = goal.GoalID.ToString() });

            queryDatum.Add(queryData);

            for (int i = 0; i <= goal.Categories.Count - 1; i++)
            {
                queryData = new InsertQueryData();

                queryData.TableName = "PLN_GoalCategories";
                queryData.Fields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = goal.GoalID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "CategoryID", FieldType = SqlDbType.Int, FieldValue = goal.Categories[i].CategoryID.ToString() });
                queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = (i + 1).ToString() });
                queryDatum.Add(queryData);
            }

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteGoal(Goal goal)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new DeleteQueryData();
            queryData.TableName = "PLN_GoalCategories";
            queryData.KeyFields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = goal.GoalID.ToString() });
            queryDatum.Add(queryData);

            queryData = new DeleteQueryData();
            queryData.TableName = "PLN_GoalSteps";
            queryData.KeyFields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = goal.GoalID.ToString() });
            queryDatum.Add(queryData);

            queryData = new DeleteQueryData();
            queryData.TableName = "PLN_Goals";
            queryData.KeyFields.Add(new FieldData { FieldName = "GoalID", FieldType = SqlDbType.Int, FieldValue = goal.GoalID.ToString() });
            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            if (goal.Steps != null)
            {
                for (int i = 0; i <= goal.Steps.Count - 1; i++)
                {
                    DALTask.DeleteTask(goal.Steps[i].taskInfo);
                }
            }

            return returnValue;
        }

        public static bool DeleteGoal(int GoalID)
        {
            return DeleteGoal(GetGoalByID(GoalID));
        }

        #region Private Methods

        private static Goal loadGoal(DataTable dtGoals, int RowNo)
        {
            Goal goal = new Goal();
            goal.GoalID = Convert.ToInt32(dtGoals.Rows[RowNo]["GoalID"]);
            goal.GoalSubject = dtGoals.Rows[RowNo]["GoalSubject"].ToString();
            goal.GoalReason = dtGoals.Rows[RowNo]["GoalReason"].ToString();
            goal.GoalNotes = dtGoals.Rows[RowNo]["GoalNotes"].ToString();
            goal.IsCompleted = Convert.ToBoolean(dtGoals.Rows[RowNo]["IsCompleted"]);
            goal.Sequence = Convert.ToInt32(dtGoals.Rows[RowNo]["Sequence"]);
            goal.ForUser = DALAppUser.GetUserByID(Convert.ToInt32(dtGoals.Rows[RowNo]["UserID"]));
            goal.DueOn = Convert.ToDateTime(dtGoals.Rows[RowNo]["DueOn"]);

            goal.Categories = loadGoalCategories(goal.GoalID);

            goal.Steps = DALGoalStep.GetGoalStepsByGoalID(goal.GoalID);

            //for (int k = 0; k <= goal.Steps.Count - 1; k++)
            //{
            //    if (goal.Steps[k].taskInfo != null)
            //    {
            //        if (goal.DueOn == null)
            //        {
            //            goal.DueOn = goal.Steps[k].taskInfo.TaskDate;
            //        }
            //        else
            //        {
            //            if (goal.Steps[k].taskInfo.TaskDate > goal.DueOn)
            //            {
            //                goal.DueOn = goal.Steps[k].taskInfo.TaskDate;
            //            }
            //        }
            //    }
            //}

            return goal;
        }

        private static List<Category> loadGoalCategories(int GoalID)
        {
            List<Category> GoalCategories = new List<Category>();
            DataTable dtGoalCategories = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_GoalCategories", FilterCondition = "GoalID = " + GoalID.ToString(), OrderBy = "Sequence" });
            for (int i = 0; i <= dtGoalCategories.Rows.Count - 1; i++)
            {
                GoalCategories.Add(DALCategory.GetCategoryByID(Convert.ToInt32(dtGoalCategories.Rows[i]["CategoryID"])));
            }
            return GoalCategories;
        }

        private static int getNextGoalID()
        {
            int nextID = 1;
            DataTable dtGoals = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_Goals", FieldNames = "Max(GoalID)" });
            if (dtGoals.Rows.Count > 0)
            {
                if (dtGoals.Rows[0][0] != DBNull.Value)
                {
                    nextID = (Convert.ToInt32(dtGoals.Rows[0][0])) + 1;
                }
            }
            return nextID;
        }

        #endregion
    }
}
