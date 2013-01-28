using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPlanner.AppPages
{
    public static class MyPlannerValidators
    {

        public static bool IsValidDateText(string dateText)
        {
            bool returnValue = true;
            try
            {
                DateTime date = Convert.ToDateTime(dateText);
            }
            catch
            {
                returnValue = false;
            }
            return returnValue;
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }
    }
}