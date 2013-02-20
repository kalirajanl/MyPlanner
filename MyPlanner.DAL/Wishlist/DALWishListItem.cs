using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MyPlanner.Models;
using MyPlanner.Common;

namespace MyPlanner.DAL
{
    public class DALWishListItem
    {
        public static List<WishListItem> GetWishListItemsForUser(int forUserID, bool showCompletedItems = false)
        {
            List<WishListItem> WishListItems = new List<WishListItem>();

            DataTable dtWishListItems = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_WishListItems", FilterCondition = "UserID = " + forUserID.ToString() + (showCompletedItems? "":" And IsCompleted = 0" ), OrderBy = "Sequence" });

            for (int i = 0; i <= dtWishListItems.Rows.Count - 1; i++)
            {
                WishListItems.Add(loadWishListItem(dtWishListItems, i));
            }
            return WishListItems;
        }

        public static WishListItem GetWishListItemByID(long wishListItemID)
        {
            WishListItem WishListItem = null;
            DataTable dtWishListItems = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_WishListItems", FilterCondition = "WishListItemID = " + wishListItemID.ToString() });
            if (dtWishListItems.Rows.Count > 0)
            {
                WishListItem = loadWishListItem(dtWishListItems, 0);
            }
            return WishListItem;
        }

        public static bool AddWishListItem(WishListItem wishListItem)
        {
            bool returnValue = false;

            long WishListItemID = getNextWishListItemID();

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new InsertQueryData();
            queryData.TableName = "PLN_WishListItems";
            queryData.Fields.Add(new FieldData { FieldName = "WishListItemID", FieldType = SqlDbType.Int, FieldValue = WishListItemID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = wishListItem.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "IsCompleted", FieldType = SqlDbType.Bit, FieldValue = wishListItem.IsCompleted ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "ItemDescription", FieldType = SqlDbType.NVarChar, FieldValue = wishListItem.ItemDescription.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "ItemNotes", FieldType = SqlDbType.NVarChar, FieldValue = wishListItem.ItemNotes.Trim() });
            if (wishListItem.Sequence <= 0)
            {
                wishListItem.Sequence = GetWishListItemsForUser(wishListItem.ForUser.UserID, false).Count + 1;
            }
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = wishListItem.Sequence.ToString() });

            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool SetWishListItemAsCompleted(long wishListItemID)
        {
            bool returnValue = false;
            IBaseQueryData queryData = new UpdateQueryData();
            queryData.TableName = "PLN_WishListItems";

            queryData.Fields.Add(new FieldData { FieldName = "IsCompleted", FieldType = SqlDbType.Bit, FieldValue = "1" });
            queryData.KeyFields.Add(new FieldData { FieldName = "WishListItemID", FieldType = SqlDbType.Int, FieldValue = wishListItemID.ToString() });

            returnValue = SQLWrapper.ExecuteQuery(queryData);

            return returnValue;
        }

        public static bool UpdateWishListItem(WishListItem wishListItem)
        {
            bool returnValue = false;
            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new UpdateQueryData();
            queryData.TableName = "PLN_WishListItems";
            queryData.Fields.Add(new FieldData { FieldName = "WishListItemID", FieldType = SqlDbType.Int, FieldValue = wishListItem.WishListItemID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "UserId", FieldType = SqlDbType.Int, FieldValue = wishListItem.ForUser.UserID.ToString() });
            queryData.Fields.Add(new FieldData { FieldName = "IsCompleted", FieldType = SqlDbType.Bit, FieldValue = wishListItem.IsCompleted ? "1" : "0" });
            queryData.Fields.Add(new FieldData { FieldName = "ItemDescription", FieldType = SqlDbType.NVarChar, FieldValue = wishListItem.ItemDescription.Trim() });
            queryData.Fields.Add(new FieldData { FieldName = "ItemNotes", FieldType = SqlDbType.NVarChar, FieldValue = wishListItem.ItemNotes.Trim() });
            if (wishListItem.Sequence <= 0)
            {
                wishListItem.Sequence = GetWishListItemsForUser(wishListItem.ForUser.UserID, false).Count + 1;
            }
            queryData.Fields.Add(new FieldData { FieldName = "Sequence", FieldType = SqlDbType.Int, FieldValue = wishListItem.Sequence.ToString() });

            queryData.KeyFields.Add(new FieldData { FieldName = "WishListItemID", FieldType = SqlDbType.Int, FieldValue = wishListItem.WishListItemID.ToString() });

            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteWishListItem(WishListItem wishListItem)
        {
            bool returnValue = false;

            List<IBaseQueryData> queryDatum = new List<IBaseQueryData>();

            IBaseQueryData queryData = new DeleteQueryData();
            queryData.TableName = "PLN_WishListItems";
            queryData.KeyFields.Add(new FieldData { FieldName = "WishListItemID", FieldType = SqlDbType.Int, FieldValue = wishListItem.WishListItemID.ToString() });
            queryDatum.Add(queryData);

            returnValue = SQLWrapper.ExecuteQuery(queryDatum);

            return returnValue;
        }

        public static bool DeleteWishListItem(long wishListItemID)
        {
            return DeleteWishListItem(GetWishListItemByID(wishListItemID));
        }

        #region Private Methods

        private static WishListItem loadWishListItem(DataTable dtWishListItems, int RowNo)
        {
            WishListItem WishListItem = new WishListItem();
            WishListItem.WishListItemID = Convert.ToInt32(dtWishListItems.Rows[RowNo]["WishListItemID"]);
            WishListItem.ItemDescription = dtWishListItems.Rows[RowNo]["ItemDescription"].ToString();
            WishListItem.ItemNotes = dtWishListItems.Rows[RowNo]["ItemNotes"].ToString();
            WishListItem.IsCompleted = Convert.ToBoolean(dtWishListItems.Rows[RowNo]["IsCompleted"]);
            WishListItem.Sequence = Convert.ToInt32(dtWishListItems.Rows[RowNo]["Sequence"]);
            WishListItem.ForUser = DALAppUser.GetUserByID(Convert.ToInt32(dtWishListItems.Rows[RowNo]["UserID"]));
            return WishListItem;
        }

        private static long getNextWishListItemID()
        {
            long nextID = 1;
            DataTable dtWishListItems = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "PLN_WishListItems", FieldNames = "Max(WishListItemID)" });
            if (dtWishListItems.Rows.Count > 0)
            {
                if (dtWishListItems.Rows[0][0] != DBNull.Value)
                {
                    nextID = (Convert.ToInt32(dtWishListItems.Rows[0][0])) + 1;
                }
            }
            return nextID;
        }

        #endregion

    }
}
