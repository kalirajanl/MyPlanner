using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MyPlanner.Models;
using MyPlanner.Common;

namespace MyPlanner.DAL
{
    public class DALBigRock
    {

        public static List<BigRock> GetBigRocks(int ForUserID, DateTime forWeek, bool addblanks)
        {
            List<BigRock> BigRocks = new List<BigRock>();

            DataTable dtBigRocks = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_BigRocks", FilterCondition = "UserID = " + ForUserID + " And ForWeek = '" + forWeek.ToString(Constants.DATE_FORMAT_SQL) + "'" , OrderBy = "CompassRoleID,Sequence" });

            for (int i = 0; i <= dtBigRocks.Rows.Count - 1; i++)
            {
                BigRocks.Add(loadBigRock(dtBigRocks, i));
            }
            if (addblanks)
            {
                if (dtBigRocks.Rows.Count < 6)
                {
                    for (int i = dtBigRocks.Rows.Count; i < 13; i++)
                    {
                        BigRocks.Add(new BigRock { BigRockID = (0 - (i + 1)), });
                    }
                }
            }

            return BigRocks;
        }

        public static List<BigRock> GetBigRocks(int forUserID, DateTime forWeek, int forCompassRoleID , bool addblanks)
        {
            List<BigRock> BigRocks = new List<BigRock>();

            DataTable dtBigRocks = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_BigRocks", FilterCondition = "UserID = " + forUserID + " And ForWeek = '" + forWeek.ToString(Constants.DATE_FORMAT_SQL) + "' And CompassRoleID = " + forCompassRoleID.ToString() , OrderBy = "CompassRoleID,Sequence" });

            for (int i = 0; i <= dtBigRocks.Rows.Count - 1; i++)
            {
                BigRocks.Add(loadBigRock(dtBigRocks, i));
            }
            if (addblanks)
            {
                if (dtBigRocks.Rows.Count < 6)
                {
                    for (int i = dtBigRocks.Rows.Count; i < 13; i++)
                    {
                        BigRocks.Add(new BigRock { BigRockID = (0 - (i + 1)), });
                    }
                }
            }

            return BigRocks;
        }

        public static BigRock GetBigRockByID(long BigRockID)
        {
            BigRock BigRock = null;
            DataTable dtBigRocks = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_BigRocks", FilterCondition = "BigRockID = " + BigRockID.ToString(), OrderBy = "Sequence" });
            if (dtBigRocks.Rows.Count > 0)
            {
                BigRock = loadBigRock(dtBigRocks, 0);
            }
            return BigRock;
        }

        public static bool AddBigRock(BigRock bigRock)
        {
            bool returnValue = false;

            long BigRockID = getNextBigRockID();

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new InsertQueryData();
            queryData.TableName = "PLN_BigRocks";
            queryData.Fields.Add(new FieldData { FieldName = "CompassRoleID", FieldType = SqlDbType.Int, FieldValue = bigRock.AsCompassRole.CompassRoleID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = bigRock.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "ForWeek", FieldType = SqlDbType.Date, FieldValue = bigRock.ForWeek.ToString(Constants.DATE_FORMAT_SQL) });
            queryData.Fields.Add(new FieldData { FieldName = "BigRockName", FieldType = SqlDbType.NVarChar, FieldValue = bigRock.BigRockName.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = getNextSequenceID(bigRock.ForUser.UserID).ToString() });
            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool UpdateBigRock(BigRock bigRock)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();
            IBaseQueryData queryData = new UpdateQueryData();

            queryData.TableName = "PLN_BigRocks";
            queryData.Fields.Add(new FieldData { FieldName = "CompassRoleID", FieldType = SqlDbType.Int, FieldValue = bigRock.AsCompassRole.CompassRoleID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = bigRock.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "ForWeek", FieldType = SqlDbType.Date, FieldValue = bigRock.ForWeek.ToString(Constants.DATE_FORMAT_SQL) });
            queryData.Fields.Add(new FieldData { FieldName = "BigRockName", FieldType = SqlDbType.NVarChar, FieldValue = bigRock.BigRockName.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = getNextSequenceID(bigRock.ForUser.UserID).ToString() });

            queryData.KeyFields.Add(new FieldData { FieldName = "BigRockID", FieldType = SqlDbType.Decimal, FieldValue = bigRock.BigRockID.ToString() });

            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteBigRock(BigRock bigRock)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            DeleteQueryData queryData = new DeleteQueryData();
            queryData.TableName = "PLN_BigRocks";
            queryData.KeyFields.Add(new FieldData { FieldName = "BigRockID", FieldType = SqlDbType.Decimal, FieldValue = bigRock.BigRockID.ToString() });
            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteBigRock(long BigRockID)
        {
            BigRock BigRock = new BigRock();
            BigRock.BigRockID = BigRockID;
            return DeleteBigRock(BigRock);
        }

        #region Private Methods

        private static BigRock loadBigRock(DataTable dtBigRocks, int RowNo)
        {
            BigRock bigRock = new BigRock();
            bigRock.BigRockID = (long)Convert.ToDecimal(dtBigRocks.Rows[RowNo]["BigRockID"]);
            bigRock.BigRockName = dtBigRocks.Rows[RowNo]["BigRockName"].ToString();
            bigRock.ForWeek = Convert.ToDateTime(dtBigRocks.Rows[RowNo]["Forweek"].ToString());
            bigRock.Sequence = Convert.ToInt32(dtBigRocks.Rows[RowNo]["Sequence"]);
            bigRock.AsCompassRole = DALCompassRole.GetCompassRoleByID(Convert.ToInt32(dtBigRocks.Rows[RowNo]["CompassRoleID"]));
            bigRock.ForUser = DALAppUser.GetUserByID(Convert.ToInt32(dtBigRocks.Rows[RowNo]["UserID"]));
            return bigRock;
        }

        private static long getNextBigRockID()
        {
            long nextID = 1;
            DataTable dtBigRocks = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_BigRocks", FieldNames = "Max(BigRockID)" });
            if (dtBigRocks.Rows.Count > 0)
            {
                if (dtBigRocks.Rows[0][0] != DBNull.Value)
                {
                    nextID = (long)Convert.ToDecimal(dtBigRocks.Rows[0][0]) + 1;
                }
            }
            return nextID;
        }

        private static int getNextSequenceID(int ForUserID)
        {
            int nextID = 1;
            DataTable dtBigRocks = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_BigRocks", FieldNames = "Max(Sequence)", FilterCondition = "UserID = " + ForUserID });
            if (dtBigRocks.Rows.Count > 0)
            {
                if (dtBigRocks.Rows[0][0] != DBNull.Value)
                {
                    nextID = Convert.ToInt32(dtBigRocks.Rows[0][0]) + 1;
                }
            }
            return nextID;
        }

        #endregion


    }
}
