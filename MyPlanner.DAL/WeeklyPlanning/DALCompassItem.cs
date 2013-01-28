using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyPlanner.Models;

namespace MyPlanner.DAL
{
    public class DALCompassItem
    {
        public static List<CompassItem> GetCompassItems(int forUserID, DateTime forWeek, bool addblanks)
        {
            List<CompassItem> compassItems = new List<CompassItem>();

            List<BigRock> bigRocks = DALBigRock.GetBigRocks(forUserID, forWeek, addblanks);

            CompassRole compassRole=null;
            int blankCounter = 0;

            for (int i = 0; i <= bigRocks.Count - 1; i++)
            {
                if (compassRole == null)
                {
                    compassItems.Add(new CompassItem { CompassItemID = "CR" + bigRocks[i].AsCompassRole.CompassRoleID, CompassItemName = "Role : " + bigRocks[i].AsCompassRole.CompassRoleName });
                    compassRole = bigRocks[i].AsCompassRole;
                }
                else if (compassRole.CompassRoleID != bigRocks[i].AsCompassRole.CompassRoleID)
                {
                    compassItems.Add(new CompassItem { CompassItemID = "BL" + (blankCounter+1).ToString() , CompassItemName = "" });
                    blankCounter++;
                    compassItems.Add(new CompassItem { CompassItemID = "CR" + bigRocks[i].AsCompassRole.CompassRoleID, CompassItemName = "Role : " + bigRocks[i].AsCompassRole.CompassRoleName });
                    compassRole = bigRocks[i].AsCompassRole;
                }
                compassItems.Add(new CompassItem { CompassItemID = "BR" + bigRocks[i].BigRockID, CompassItemName = bigRocks[i].BigRockName });
            }
            if (bigRocks.Count > 0)
            {
                compassItems.Add(new CompassItem { CompassItemID = "BL" + (blankCounter + 1).ToString(), CompassItemName = "" });
                blankCounter++;
            }
            return compassItems;
        }
    }
}
