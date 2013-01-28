using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using MyPlanner.DAL;
namespace MyPlanner.BLL
{
    public class BLLCompassItem
    {
        public static List<CompassItem> GetCompassItems(int forUserID, DateTime forWeek, bool addblanks)
        {
            return DALCompassItem.GetCompassItems(forUserID, forWeek, addblanks);
        }
    }
}
