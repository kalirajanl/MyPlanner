using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyPlanner.Models;

namespace MyPlanner.DAL
{
    public class DALDailyNotes
    {
        public static List<DailyNote> GetDailyNotes(int ForUserID)
        {
            List<DailyNote> DailyNotes = new List<DailyNote>();

            DataTable dtDailyNotes = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "CMN_DailyNotes", FilterCondition = "UserID = " + ForUserID.ToString()});

            for (int i = 0; i <= dtDailyNotes.Rows.Count - 1; i++)
            {
                DailyNotes.Add(loadDailyNote(dtDailyNotes, i));
            }
            return DailyNotes;
        }

        public static DailyNote GetDailyNoteByID(int DailyNoteID)
        {
            DailyNote DailyNote = null;
            DataTable dtDailyNotes = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "CMN_DailyNotes", FilterCondition = "DailyNoteID = " + DailyNoteID.ToString() });
            if (dtDailyNotes.Rows.Count > 0)
            {
                DailyNote = loadDailyNote(dtDailyNotes, 0);
            }
            return DailyNote;
        }

        public static DailyNote GetDailyNote(int ForUserID,DateTime forDate)
        {
            DailyNote DailyNote = null;
            DataTable dtDailyNotes = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "CMN_DailyNotes", FilterCondition = "UserID = " + ForUserID.ToString() + " And ForDate = '" + forDate.ToString(Constants.DATE_FORMAT_SQL) +"'" });
            if (dtDailyNotes.Rows.Count > 0)
            {
                DailyNote = loadDailyNote(dtDailyNotes, 0);
            }
            else
            {
                DailyNote = new DailyNote { DailyNoteID = 0, ForDate = forDate, ForUser = DALAppUser.GetUserByID(ForUserID), Notes = "" };
            }
            return DailyNote;
        }

        public static bool AddDailyNote(DailyNote dailyNote)
        {
            bool returnValue = false;

            int dailyNoteID = getNextDailyNoteID();

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new InsertQueryData();
            queryData.TableName = "CMN_DailyNotes";
            queryData.Fields.Add(new FieldData { FieldName = "DailyNoteID", FieldType = SqlDbType.Int, FieldValue = dailyNoteID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "DailyNote", FieldType = SqlDbType.NVarChar, FieldValue = dailyNote.Notes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "ForDate", FieldType = SqlDbType.Date, FieldValue = dailyNote.ForDate.ToString(Constants.DATE_FORMAT_SQL) });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = dailyNote.ForUser.UserID.ToString() });
            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool UpdateDailyNote(DailyNote dailyNote)
        {
            bool returnValue = false;


            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();
            IBaseQueryData queryData = new UpdateQueryData();

            queryData.TableName = "CMN_DailyNotes";
            queryData.Fields.Add(new FieldData { FieldName = "DailyNote", FieldType = SqlDbType.NVarChar, FieldValue = dailyNote.Notes.Trim() });

            queryData.KeyFields.Add(new FieldData { FieldName = "ForDate", FieldType = SqlDbType.Date, FieldValue = dailyNote.ForDate.ToString(Constants.DATE_FORMAT_SQL) });
            queryData.KeyFields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = dailyNote.ForUser.UserID.ToString() });

            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteDailyNote(DailyNote dailyNote)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            DeleteQueryData queryData =  new DeleteQueryData();
            queryData.TableName = "CMN_DailyNotes";
            queryData.KeyFields.Add(new FieldData { FieldName = "ForDate", FieldType = SqlDbType.Date, FieldValue = dailyNote.ForDate.ToString(Constants.DATE_FORMAT_SQL) });
            queryData.KeyFields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = dailyNote.ForUser.UserID.ToString() });
            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteDailyNote(int DailyNoteID)
        {
            return DeleteDailyNote(GetDailyNoteByID(DailyNoteID));
        }

        public static bool DeleteDailyNote(int ForUserID, DateTime forDate)
        {
            return DeleteDailyNote(GetDailyNote(ForUserID, forDate));
        }

        #region Private Methods

        private static DailyNote loadDailyNote(DataTable dtDailyNotes, int RowNo)
        {
            DailyNote dailyNote = new DailyNote();
            dailyNote.DailyNoteID = Convert.ToInt32(dtDailyNotes.Rows[RowNo]["DailyNoteID"]);
            dailyNote.Notes = dtDailyNotes.Rows[RowNo]["DailyNote"].ToString();
            dailyNote.ForDate = Convert.ToDateTime(dtDailyNotes.Rows[RowNo]["ForDate"]);
            dailyNote.ForUser = DALAppUser.GetUserByID(Convert.ToInt32(dtDailyNotes.Rows[RowNo]["UserID"]));
            return dailyNote;
        }

        private static int getNextDailyNoteID()
        {
            int nextID = 1;
            DataTable dtDailyNotes = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "CMN_DailyNotes", FieldNames = "Max(DailyNoteID)" });
            if (dtDailyNotes.Rows.Count > 0)
            {
                if (dtDailyNotes.Rows[0][0] != DBNull.Value)
                {
                    nextID = Convert.ToInt32(dtDailyNotes.Rows[0][0]) + 1;
                }
            }
            return nextID;
        }
        
        #endregion
    }
}
