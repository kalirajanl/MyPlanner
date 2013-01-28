using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using System.Data;

namespace MyPlanner.DAL
{
    public class DALCategory
    {
        public static List<Category> GetCategoriesByUserID(int UserID)
        {
            List<Category> Categories = new List<Category>();

            DataTable dtCategories = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "CMN_Categories",  FilterCondition = "UserID = " + UserID.ToString(), OrderBy = "Sequence" });
            for (int i = 0; i <= dtCategories.Rows.Count - 1; i++)
            {
                Categories.Add(new Category { CategoryID = Convert.ToInt32(dtCategories.Rows[i]["CategoryID"]), CategoryName = dtCategories.Rows[i]["CategoryName"].ToString(), Sequence = Convert.ToInt32(dtCategories.Rows[i]["Sequence"]) });
            }

            return Categories;
        }

        public static Category GetCategoryByID(int CategoryID)
        {
            Category category = null;

            DataTable dtCategories = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "CMN_Categories",  FilterCondition = "CategoryID = " + CategoryID.ToString(), OrderBy = "Sequence" });
            if (dtCategories.Rows.Count > 0)
            {
                category = new Category();
                category.CategoryID = Convert.ToInt32(dtCategories.Rows[0]["CategoryID"]);
                category.CategoryName = dtCategories.Rows[0]["CategoryName"].ToString();
                category.ForUser = DALAppUser.GetUserByID(Convert.ToInt32(dtCategories.Rows[0]["UserID"]));
                category.Sequence = Convert.ToInt32(dtCategories.Rows[0]["Sequence"]);
            }
            return category;
        }
    }
}
