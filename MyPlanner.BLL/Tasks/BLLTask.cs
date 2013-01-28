using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.DAL;
using MyPlanner.Models;

namespace MyPlanner.BLL
{
    public class BLLTask
    {
        public static List<Task> GetTasks(int ForUserID, List<Category> ForCategories, DateTime forDate, bool addBlank =true)
        {
            return MyPlanner.DAL.DALTask.GetTasks(ForUserID, ForCategories, forDate,addBlank);
        }

        public static Task GetTaskByID(long TaskID)
        {
            return MyPlanner.DAL.DALTask.GetTaskByID(TaskID);
        }

        public static long AddTask(Task task)
        {
            return MyPlanner.DAL.DALTask.AddTask(task);
        }

        public static bool UpdateTask(Task task)
        {
            return MyPlanner.DAL.DALTask.UpdateTask(task);
        }

        public static bool UpdateTaskStatus(long taskID, TaskStatuses withStatus)
        {
            return DALTask.UpdateTaskStatus(taskID, withStatus);
        }

        public static bool ForwardTask(long taskID, DateTime toDate)
        {
            bool returnValue = false;

            Task task = DALTask.GetTaskByID(taskID);
            task.Status = TaskStatuses.Normal;
            task.StatusText = task.Status.ToString();
            task.TaskDate = toDate;
            DALTask.AddTask(task);
            returnValue = DALTask.UpdateTaskStatus(taskID, TaskStatuses.Forwarded);
            return returnValue;
        }

        public static bool DeleteTask(long TaskID)
        {
            return MyPlanner.DAL.DALTask.DeleteTask(TaskID);
        }
    }
}
