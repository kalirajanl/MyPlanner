using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyPlanner.DAL
{
    public class DALMission
    {
        public static List<Mission> GetMissions(int ForUserID, List<Category> ForCategories, bool addblanks)
        {
            List<Mission> Missions = new List<Mission>();

            DataTable dtMissions = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_Missions", FilterCondition = "UserID = " + ForUserID, OrderBy = "Sequence" });

            for (int i = 0; i <= dtMissions.Rows.Count - 1; i++)
            {
                Missions.Add(loadMission(dtMissions, i));
            }
            if (addblanks)
            {
                if (dtMissions.Rows.Count < 6)
                {
                    for (int i = dtMissions.Rows.Count; i < 13; i++)
                    {
                        Missions.Add(new Mission { MissionID = (0 - (i + 1)), MissionNotes = "", MissionTitle = "" });
                    }
                }
            }

            return Missions;
        }

        public static Mission GetMissionByID(int MissionID)
        {
            Mission mission = null;
            DataTable dtMissions = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_Missions", FilterCondition = "MissionID = " + MissionID.ToString(), OrderBy = "Sequence" });
            if (dtMissions.Rows.Count > 0)
            {
                mission = loadMission(dtMissions, 0);
            }
            return mission;
        }

        public static bool AddMission(Mission mission)
        {
            bool returnValue = false;

            int missionID = getNextMissionID();

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new InsertQueryData();
            queryData.TableName = "PLN_Missions";
            queryData.Fields.Add(new FieldData { FieldName = "MissionID", FieldType = SqlDbType.Int, FieldValue= missionID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "MissionTitle", FieldType = SqlDbType.NVarChar, FieldValue = mission.MissionTitle.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "MissionNotes", FieldType = SqlDbType.NVarChar, FieldValue = mission.MissionNotes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = mission.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = getNextSequenceID(mission.ForUser.UserID).ToString() });
            queryDatum.Add(queryData);

            if (mission.Categories != null)
            {
                for (int i = 0; i <= mission.Categories.Count - 1; i++)
                {
                    queryData = new InsertQueryData();

                    queryData.TableName = "PLN_MissionCategories";
                    queryData.Fields.Add(new FieldData { FieldName = "MissionID", FieldType = SqlDbType.Int, FieldValue = missionID.ToString() });
                    queryData.Fields.Add(new FieldData { FieldName = "CategoryID", FieldType = SqlDbType.Int, FieldValue = mission.Categories[i].CategoryID.ToString() });
                    queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = (i + 1).ToString() });
                    queryDatum.Add(queryData);
                }
            }

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool UpdateMission(Mission mission)
        {
            bool returnValue = false;


            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();
            IBaseQueryData queryData = new UpdateQueryData();

            queryData.TableName = "PLN_Missions";
            queryData.Fields.Add(new FieldData { FieldName = "MissionTitle", FieldType = SqlDbType.NVarChar, FieldValue = mission.MissionTitle.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "MissionNotes", FieldType = SqlDbType.NVarChar, FieldValue = mission.MissionNotes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = mission.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = ((int)mission.Sequence).ToString() });

            queryData.KeyFields.Add(new FieldData { FieldName = "MissionID", FieldType = SqlDbType.Int, FieldValue = mission.MissionID.ToString() });

            queryDatum.Add(queryData);

            queryData = new DeleteQueryData();
            queryData.TableName = "PLN_MissionCategories";
            queryData.KeyFields.Add(new FieldData { FieldName = "MissionID", FieldType = SqlDbType.Int, FieldValue = mission.MissionID.ToString() });

            queryDatum.Add(queryData);

            if (mission.Categories != null)
            {
                for (int i = 0; i <= mission.Categories.Count - 1; i++)
                {
                    queryData = new InsertQueryData();

                    queryData.TableName = "PLN_MissionCategories";
                    queryData.Fields.Add(new FieldData { FieldName = "MissionID", FieldType = SqlDbType.Int, FieldValue = mission.MissionID.ToString() });
                    queryData.Fields.Add(new FieldData { FieldName = "CategoryID", FieldType = SqlDbType.Int, FieldValue = mission.Categories[i].CategoryID.ToString() });
                    queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = (i + 1).ToString() });
                    queryDatum.Add(queryData);
                }
            }
            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteMission(Mission mission)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            DeleteQueryData queryData = new DeleteQueryData();
            queryData.TableName = "PLN_MissionCategories";
            queryData.KeyFields.Add(new FieldData { FieldName = "MissionID", FieldType = SqlDbType.Int, FieldValue = mission.MissionID.ToString() });
            queryDatum.Add(queryData);

            queryData = new DeleteQueryData();
            queryData.TableName = "PLN_Missions";
            queryData.KeyFields.Add(new FieldData { FieldName = "MissionID", FieldType = SqlDbType.Int, FieldValue = mission.MissionID.ToString() });
            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteMission(int MissionID)
        {
            Mission mission = new Mission();
            mission.MissionID = MissionID;
            return DeleteMission(mission);
        }

        #region Private Methods

        private static Mission loadMission(DataTable dtMissions, int RowNo)
        {
            Mission mission = new Mission();
            mission.MissionID = Convert.ToInt32(dtMissions.Rows[RowNo]["MissionID"]);
            mission.MissionTitle = dtMissions.Rows[RowNo]["MissionTitle"].ToString();
            mission.MissionNotes = dtMissions.Rows[RowNo]["MissionNotes"].ToString();
            mission.Sequence = Convert.ToInt32(dtMissions.Rows[RowNo]["Sequence"]);
            mission.Categories = loadMissionCategories(mission.MissionID);
            mission.ForUser = DALAppUser.GetUserByID(Convert.ToInt32(dtMissions.Rows[RowNo]["UserID"]));
            return mission;
        }

        private static List<Category> loadMissionCategories(int missionID)
        {
            List<Category> missionCategories = new List<Category>();
            DataTable dtMissionCategories = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_MissionCategories", FilterCondition = "MissionID = " + missionID.ToString(), OrderBy = "Sequence" });
            for (int i = 0; i <= dtMissionCategories.Rows.Count - 1; i++)
            {
                missionCategories.Add(DALCategory.GetCategoryByID(Convert.ToInt32(dtMissionCategories.Rows[i]["CategoryID"])));
            }
            return missionCategories;
        }

        private static int getNextMissionID()
        {
            int nextID = 1;
            DataTable dtMissions = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_Missions", FieldNames = "Max(MissionID)" });
            if (dtMissions.Rows.Count > 0)
            {
                if (dtMissions.Rows[0][0] != DBNull.Value)
                {
                    nextID = Convert.ToInt32(dtMissions.Rows[0][0]) + 1;
                }
            }
            return nextID;
        }

        private static int getNextSequenceID(int ForUserID)
        {
            int nextID = 1;
            DataTable dtMissions = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_Missions", FieldNames = "Max(Sequence)", FilterCondition = "UserID = " + ForUserID });
            if (dtMissions.Rows.Count > 0)
            {
                if (dtMissions.Rows[0][0] != DBNull.Value)
                {
                    nextID = Convert.ToInt32(dtMissions.Rows[0][0]) + 1;
                }
            }
            return nextID;
        }

        #endregion

    }
}
