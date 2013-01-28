using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using MyPlanner.DAL;

namespace MyPlanner.BLL
{
    public class BLLValue
    {
        public static List<Value> GetValues(int ForUserID, List<Category> ForCategories, bool addblanks)
        {
            return DALValue.GetValues(ForUserID, ForCategories, addblanks);
        }

        public static Value GetValueByID(int ValueID)
        {
            return MyPlanner.DAL.DALValue.GetValueByID(ValueID);
        }

        public static bool AddValue(Value value)
        {
            return MyPlanner.DAL.DALValue.AddValue(value);
        }

        public static bool UpdateValue(Value value)
        {
            return MyPlanner.DAL.DALValue.UpdateValue(value);
        }

        public static bool DeleteValue(int ValueID)
        {
            return MyPlanner.DAL.DALValue.DeleteValue(ValueID);
        }

    }
}
