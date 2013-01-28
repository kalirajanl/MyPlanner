using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using MyPlanner.DAL;

namespace MyPlanner.BLL
{
    public class BLLCompassRole
    {
        public static List<CompassRole> GetCompassRoles(int ForUserID, bool addblanks)
        {
            return DALCompassRole.GetCompassRoles(ForUserID, addblanks);
        }

        public static CompassRole GetCompassRoleByID(int CompassRoleID)
        {
            return DALCompassRole.GetCompassRoleByID(CompassRoleID);
        }

        public static bool AddCompassRole(CompassRole CompassRole)
        {
            return DALCompassRole.AddCompassRole(CompassRole);
        }

        public static bool UpdateCompassRole(CompassRole CompassRole)
        {
            return DALCompassRole.UpdateCompassRole(CompassRole);
        }

        public static bool DeleteCompassRole(int CompassRoleID)
        {
            return DALCompassRole.DeleteCompassRole(CompassRoleID);
        }

    }
}
