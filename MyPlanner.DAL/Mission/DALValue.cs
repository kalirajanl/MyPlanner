using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyPlanner.Models;

namespace MyPlanner.DAL
{
    public class DALValue
    {
        public static List<Value> GetValues(int ForUserID, List<Category> ForCategories, bool addblanks)
        {
            List<Value> Values = new List<Value>();

            DataTable dtValues = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_Values", FilterCondition = "UserID = " + ForUserID, OrderBy = "Sequence" });

            for (int i = 0; i <= dtValues.Rows.Count - 1; i++)
            {
                Values.Add(loadValue(dtValues, i));
            }
            if (addblanks)
            {
                if (dtValues.Rows.Count < 6)
                {
                    for (int i = dtValues.Rows.Count; i < 13; i++)
                    {
                        Values.Add(new Value { ValueID = (0 - (i + 1)), ValueNotes = "", ValueTitle = "" });
                    }
                }
            }
            return Values;
        }

        public static Value GetValueByID(int ValueID)
        {
            Value value = null;
            DataTable dtValues = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_Values", FilterCondition = "ValueID = " + ValueID.ToString(), OrderBy = "Sequence" });
            if (dtValues.Rows.Count > 0)
            {
                value = loadValue(dtValues, 0);
            }
            return value;
        }

        public static bool AddValue(Value value)
        {
            bool returnValue = false;

            int ValueID = getNextValueID();

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new InsertQueryData();
            queryData.TableName = "PLN_Values";
            queryData.Fields.Add(new FieldData { FieldName = "ValueID", FieldType = SqlDbType.Int, FieldValue = ValueID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "ValueTitle", FieldType = SqlDbType.NVarChar, FieldValue = value.ValueTitle.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "ValueNotes", FieldType = SqlDbType.NVarChar, FieldValue = value.ValueNotes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = value.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = getNextSequenceID(value.ForUser.UserID).ToString() });
            queryDatum.Add(queryData);

            if (value.Categories != null)
            {
                for (int i = 0; i <= value.Categories.Count - 1; i++)
                {
                    queryData = new InsertQueryData();

                    queryData.TableName = "PLN_ValueCategories";
                    queryData.Fields.Add(new FieldData { FieldName = "ValueID", FieldType = SqlDbType.Int, FieldValue = ValueID.ToString() });
                    queryData.Fields.Add(new FieldData { FieldName = "CategoryID", FieldType = SqlDbType.Int, FieldValue = value.Categories[i].CategoryID.ToString() });
                    queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = (i + 1).ToString() });
                    queryDatum.Add(queryData);
                }

            }
            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool UpdateValue(Value value)
        {
            bool returnValue = false;


            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();
            IBaseQueryData queryData = new UpdateQueryData();

            queryData.TableName = "PLN_Values";
            queryData.Fields.Add(new FieldData { FieldName = "ValueTitle", FieldType = SqlDbType.NVarChar, FieldValue = value.ValueTitle.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "ValueNotes", FieldType = SqlDbType.NVarChar, FieldValue = value.ValueNotes.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = value.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = ((int)value.Sequence).ToString() });

            queryData.KeyFields.Add(new FieldData { FieldName = "ValueID", FieldType = SqlDbType.Int, FieldValue = value.ValueID.ToString() });

            queryDatum.Add(queryData);

            queryData = new DeleteQueryData();
            queryData.TableName = "PLN_ValueCategories";
            queryData.KeyFields.Add(new FieldData { FieldName = "ValueID", FieldType = SqlDbType.Int, FieldValue = value.ValueID.ToString() });

            queryDatum.Add(queryData);

            if (value.Categories != null)
            {
                for (int i = 0; i <= value.Categories.Count - 1; i++)
                {
                    queryData = new InsertQueryData();

                    queryData.TableName = "PLN_ValueCategories";
                    queryData.Fields.Add(new FieldData { FieldName = "ValueID", FieldType = SqlDbType.Int, FieldValue = value.ValueID.ToString() });
                    queryData.Fields.Add(new FieldData { FieldName = "CategoryID", FieldType = SqlDbType.Int, FieldValue = value.Categories[i].CategoryID.ToString() });
                    queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = (i + 1).ToString() });
                    queryDatum.Add(queryData);
                }
            }

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteValue(Value value)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            DeleteQueryData queryData = new DeleteQueryData();
            queryData.TableName = "PLN_ValueCategories";
            queryData.KeyFields.Add(new FieldData { FieldName = "ValueID", FieldType = SqlDbType.Int, FieldValue = value.ValueID.ToString() });
            queryDatum.Add(queryData);

            queryData = new DeleteQueryData();
            queryData.TableName = "PLN_Values";
            queryData.KeyFields.Add(new FieldData { FieldName = "ValueID", FieldType = SqlDbType.Int, FieldValue = value.ValueID.ToString() });
            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteValue(int ValueID)
        {
            Value value = new Value();
            value.ValueID = ValueID;
            return DeleteValue(value);
        }

        #region Private Methods

        private static Value loadValue(DataTable dtValues, int RowNo)
        {
            Value value = new Value();
            value.ValueID = Convert.ToInt32(dtValues.Rows[RowNo]["ValueID"]);
            value.ValueTitle = dtValues.Rows[RowNo]["ValueTitle"].ToString();
            value.ValueNotes = dtValues.Rows[RowNo]["ValueNotes"].ToString();
            value.Sequence = Convert.ToInt32(dtValues.Rows[RowNo]["Sequence"]);
            value.Categories = loadValueCategories(value.ValueID);
            value.ForUser = DALAppUser.GetUserByID(Convert.ToInt32(dtValues.Rows[RowNo]["UserID"]));
            return value;
        }

        private static List<Category> loadValueCategories(int ValueID)
        {
            List<Category> ValueCategories = new List<Category>();
            DataTable dtValueCategories = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_ValueCategories", FilterCondition = "ValueID = " + ValueID.ToString(), OrderBy = "Sequence" });
            for (int i = 0; i <= dtValueCategories.Rows.Count - 1; i++)
            {
                ValueCategories.Add(DALCategory.GetCategoryByID(Convert.ToInt32(dtValueCategories.Rows[i]["CategoryID"])));
            }
            return ValueCategories;
        }

        private static int getNextValueID()
        {
            int nextID = 1;
            DataTable dtValues = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_Values", FieldNames = "Max(ValueID)" });
            if (dtValues.Rows.Count > 0)
            {
                if (dtValues.Rows[0][0] != DBNull.Value)
                {
                    nextID = Convert.ToInt32(dtValues.Rows[0][0]) + 1;
                }
            }
            return nextID;
        }

        private static int getNextSequenceID(int ForUserID)
        {
            int nextID = 1;
            DataTable dtValues = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_Values", FieldNames = "Max(Sequence)", FilterCondition = "UserID = " + ForUserID });
            if (dtValues.Rows.Count > 0)
            {
                if (dtValues.Rows[0][0] != DBNull.Value)
                {
                    nextID = Convert.ToInt32(dtValues.Rows[0][0]) + 1;
                }
            }
            return nextID;
        }

        #endregion

    }


}
