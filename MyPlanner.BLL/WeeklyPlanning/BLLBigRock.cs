using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using MyPlanner.DAL;

namespace MyPlanner.BLL
{
    public class BLLBigRock
    {
        public static List<BigRock> GetBigRocks(int ForUserID, DateTime forWeek, bool addblanks)
        {
            return DALBigRock.GetBigRocks(ForUserID,forWeek, addblanks);
        }

        public static List<BigRock> GetBigRocks(int forUserID, DateTime forWeek, int forCompassRoleID, bool addblanks)
        {
            return DALBigRock.GetBigRocks(forUserID, forWeek, forCompassRoleID, addblanks);
        }

        public static BigRock GetBigRockByID(long BigRockID)
        {
            return DALBigRock.GetBigRockByID(BigRockID);
        }

        public static bool AddBigRock(BigRock bigRock)
        {
            return DALBigRock.AddBigRock(bigRock);
        }

        public static bool UpdateBigRock(BigRock bigRock)
        {
            return DALBigRock.UpdateBigRock(bigRock);
        }

        public static bool DeleteBigRock(long BigRockID)
        {
            return DALBigRock.DeleteBigRock(BigRockID);
        }
    }
}
