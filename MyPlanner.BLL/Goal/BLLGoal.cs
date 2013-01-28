using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using MyPlanner.DAL;

namespace MyPlanner.BLL
{
    public class BLLGoal
    {
        public static List<Goal> GetGoalsForUser(int forUserID, List<Category> forCategories)
        {
            return DALGoal.GetGoalsForUser(forUserID, forCategories);
        }

        public static Goal GetGoalByID(int goalID)
        {
            return DALGoal.GetGoalByID(goalID);
        }

        public static bool SetGoalAsCompleted(int goalID)
        {
            return DALGoal.SetGoalAsCompleted(goalID);
        }

        public static bool AddGoal(Goal goal)
        {
            return DALGoal.AddGoal(goal);
        }

        public static bool UpdateGoal(Goal goal)
        {
            return DALGoal.UpdateGoal(goal);
        }

        public static bool DeleteGoal(int goalID)
        {
            return DALGoal.DeleteGoal(goalID);
        }
    }
}
