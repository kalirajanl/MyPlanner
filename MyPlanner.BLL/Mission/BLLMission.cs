using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using MyPlanner.DAL;

namespace MyPlanner.BLL
{
    public class BLLMission
    {
        public static List<Mission> GetMissions(int ForUserID, List<Category> ForCategories, bool addblanks)
        {
            return DALMission.GetMissions(ForUserID, ForCategories, addblanks);
        }

        public static Mission GetMissionByID(int MissionID)
        {
            return DALMission.GetMissionByID(MissionID);
        }

        public static bool AddMission(Mission mission)
        {
            return DALMission.AddMission(mission);
        }

        public static bool UpdateMission(Mission mission)
        {
            return DALMission.UpdateMission(mission);
        }

        public static bool DeleteMission(int MissionID)
        {
            return DALMission.DeleteMission(MissionID);
        }
    }
}
