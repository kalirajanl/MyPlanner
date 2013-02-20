using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using MyPlanner.DAL;

namespace MyPlanner.BLL
{
    public class BLLWishList
    {
        public static List<WishListItem> GetWishListForUser(int forUserID, bool completedOnly = false)
        {
            return DALWishListItem.GetWishListItemsForUser(forUserID, completedOnly);
        }

        public static WishListItem GetWishListItemByID(long wishListItemID)
        {
            return DALWishListItem.GetWishListItemByID(wishListItemID);
        }

        public static bool AddWishListItem(WishListItem wishListItem)
        {
            return DALWishListItem.AddWishListItem(wishListItem);
        }

        public static bool SetWishListItemAsCompleted(long wishListItemID)
        {
            return DALWishListItem.SetWishListItemAsCompleted(wishListItemID);
        }

        public static bool UpdateWishListItem(WishListItem wishListItem)
        {
            return DALWishListItem.UpdateWishListItem(wishListItem);
        }

        public static bool DeleteWishListItem(WishListItem wishListItem)
        {
            return DALWishListItem.DeleteWishListItem(wishListItem);
        }

        public static bool DeleteWishListItem(long wishListItemID)
        {
            return DALWishListItem.DeleteWishListItem(wishListItemID);
        }
    }
}
