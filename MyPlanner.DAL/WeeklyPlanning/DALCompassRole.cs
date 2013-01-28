using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using System.Data;

namespace MyPlanner.DAL
{
    public class DALCompassRole
    {
        public static List<CompassRole> GetCompassRoles(int ForUserID, bool addblanks)
        {
            List<CompassRole> CompassRoles = new List<CompassRole>();

            DataTable dtCompassRoles = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_CompassRoles", FilterCondition = "UserID = " + ForUserID, OrderBy = "Sequence" });

            for (int i = 0; i <= dtCompassRoles.Rows.Count - 1; i++)
            {
                CompassRoles.Add(loadCompassRole(dtCompassRoles, i));
            }
            if (addblanks)
            {
                if (dtCompassRoles.Rows.Count < 6)
                {
                    for (int i = dtCompassRoles.Rows.Count; i < 13; i++)
                    {
                        CompassRoles.Add(new CompassRole { CompassRoleID = (0 - (i + 1)), Notes = "", CompassRoleName = "" });
                    }
                }
            }

            return CompassRoles;
        }

        public static CompassRole GetCompassRoleByID(int CompassRoleID)
        {
            CompassRole CompassRole = null;
            DataTable dtCompassRoles = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_CompassRoles", FilterCondition = "CompassRoleID = " + CompassRoleID.ToString(), OrderBy = "Sequence" });
            if (dtCompassRoles.Rows.Count > 0)
            {
                CompassRole = loadCompassRole(dtCompassRoles, 0);
            }
            return CompassRole;
        }

        public static bool AddCompassRole(CompassRole CompassRole)
        {
            bool returnValue = false;

            int CompassRoleID = getNextCompassRoleID();

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new InsertQueryData();
            queryData.TableName = "PLN_CompassRoles";
            queryData.Fields.Add(new FieldData { FieldName = "CompassRoleID", FieldType = SqlDbType.Int, FieldValue = CompassRoleID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "CompassRoleName", FieldType = SqlDbType.NVarChar, FieldValue = CompassRole.CompassRoleName.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "Notes", FieldType = SqlDbType.NVarChar, FieldValue = CompassRole.Notes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = CompassRole.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = getNextSequenceID(CompassRole.ForUser.UserID).ToString() });
            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool UpdateCompassRole(CompassRole CompassRole)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();
            IBaseQueryData queryData = new UpdateQueryData();

            queryData.TableName = "PLN_CompassRoles";
            queryData.Fields.Add(new FieldData { FieldName = "CompassRoleName", FieldType = SqlDbType.NVarChar, FieldValue = CompassRole.CompassRoleName.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "Notes", FieldType = SqlDbType.NVarChar, FieldValue = CompassRole.Notes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = CompassRole.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = ((int)CompassRole.Sequence).ToString() });

            queryData.KeyFields.Add(new FieldData { FieldName = "CompassRoleID", FieldType = SqlDbType.Int, FieldValue = CompassRole.CompassRoleID.ToString() });

            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteCompassRole(CompassRole CompassRole)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            DeleteQueryData queryData = new DeleteQueryData();
            queryData.TableName = "PLN_BigRocks";
            queryData.KeyFields.Add(new FieldData { FieldName = "CompassRoleID", FieldType = SqlDbType.Int, FieldValue = CompassRole.CompassRoleID.ToString() });
            queryDatum.Add(queryData);

            queryData = new DeleteQueryData();
            queryData.TableName = "PLN_CompassRoles";
            queryData.KeyFields.Add(new FieldData { FieldName = "CompassRoleID", FieldType = SqlDbType.Int, FieldValue = CompassRole.CompassRoleID.ToString() });
            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteCompassRole(int CompassRoleID)
        {
            CompassRole CompassRole = new CompassRole();
            CompassRole.CompassRoleID = CompassRoleID;
            return DeleteCompassRole(CompassRole);
        }

        #region Private Methods

        private static CompassRole loadCompassRole(DataTable dtCompassRoles, int RowNo)
        {
            CompassRole CompassRole = new CompassRole();
            CompassRole.CompassRoleID = Convert.ToInt32(dtCompassRoles.Rows[RowNo]["CompassRoleID"]);
            CompassRole.CompassRoleName = dtCompassRoles.Rows[RowNo]["CompassRoleName"].ToString();
            CompassRole.Notes = dtCompassRoles.Rows[RowNo]["Notes"].ToString();
            CompassRole.Sequence = Convert.ToInt32(dtCompassRoles.Rows[RowNo]["Sequence"]);
            return CompassRole;
        }

        private static int getNextCompassRoleID()
        {
            int nextID = 1;
            DataTable dtCompassRoles = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_CompassRoles", FieldNames = "Max(CompassRoleID)" });
            if (dtCompassRoles.Rows.Count > 0)
            {
                if (dtCompassRoles.Rows[0][0] != DBNull.Value)
                {
                    nextID = Convert.ToInt32(dtCompassRoles.Rows[0][0]) + 1;
                }
            }
            return nextID;
        }

        private static int getNextSequenceID(int ForUserID)
        {
            int nextID = 1;
            DataTable dtCompassRoles = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_CompassRoles", FieldNames = "Max(Sequence)", FilterCondition = "UserID = " + ForUserID });
            if (dtCompassRoles.Rows.Count > 0)
            {
                if (dtCompassRoles.Rows[0][0] != DBNull.Value)
                {
                    nextID = Convert.ToInt32(dtCompassRoles.Rows[0][0]) + 1;
                }
            }
            return nextID;
        }

        #endregion

    }
}
