using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MyPlanner.DAL;
using MyPlanner.Models;
using MyPlanner.Common;

namespace MyPlanner.BLL
{
    public class BLLGoalStep
    {

        public static List<GoalStep> GetGoalStepsByGoalID(int goalID)
        {
            return DALGoalStep.GetGoalStepsByGoalID(goalID);
        }

        public static GoalStep GetGoalStepByID(int GoalID)
        {
            return DALGoalStep.GetGoalStepByID(GoalID);
        }

        public static bool AddGoalStep(int goalID, GoalStep Goal)
        {
            return DALGoalStep.AddGoalStep(goalID, Goal);
        }

        public static bool SetGoalStepAsCompleted(int goalID, int goalStepID)
        {
            GoalStep goal = DALGoalStep.GetGoalStepByID(goalStepID);
            goal.taskInfo.Status = TaskStatuses.Completed;
            return DALGoalStep.UpdateGoalStep(goalID, goal);
        }

        public static bool UpdateGoalStep(int goalID, GoalStep Goal)
        {
            return DALGoalStep.UpdateGoalStep(goalID,Goal);
        }

        public static bool DeleteGoalStep(int goalStepID)
        {
            return DALGoalStep.DeleteGoalStep(goalStepID);
        }
    }
}
