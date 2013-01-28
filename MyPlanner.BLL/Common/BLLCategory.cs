using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.DAL;
using MyPlanner.Models;

namespace MyPlanner.BLL
{
    public class BLLCategory
    {
        public static List<Category> GetCategoriesByUserID(int UserID)
        {
            return DALCategory.GetCategoriesByUserID(UserID);
        }

        public static Category GetCategoryByID(int CategoryID)
        {
            return DALCategory.GetCategoryByID(CategoryID);
        }
    }
}
