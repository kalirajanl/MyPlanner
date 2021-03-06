﻿using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MyPlanner.DAL;
using MyPlanner.Models;
using MyPlanner.Common;

namespace MyPlanner.BLL
{
    public class BLLTask
    {
        public static List<Task> GetTasks(int ForUserID, List<Category> ForCategories, DateTime forDate, bool addAsOfDateOverDueTasks, bool addBlank)
        {
            return MyPlanner.DAL.DALTask.GetTasks(ForUserID, ForCategories, forDate, addAsOfDateOverDueTasks, addBlank);
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

        public static bool CopyTask(long taskID)
        {
            bool returnValue = false;

            Task task = DALTask.GetTaskByID(taskID);
            task.Status = TaskStatuses.Normal;
            long newTaskID = DALTask.AddTask(task);
            if (newTaskID > 0)
            {
                returnValue = true;
            }
            return returnValue;
        }

        public static bool ForwardTask(long taskID, DateTime toDate, TaskStatuses currentTaskStatus = TaskStatuses.Forwarded, string taskNotes="")
        {
            bool returnValue = false;

            Task task = DALTask.GetTaskByID(taskID);
            task.Status = TaskStatuses.Normal;
            task.StatusText = task.Status.ToString();
            task.TaskDate = toDate;
            task.TaskNotes = taskNotes;
            long newTaskID = DALTask.AddTask(task);
            if (newTaskID > 0)
            {
                returnValue = true;
                if (currentTaskStatus == TaskStatuses.Deleted)
                {
                    returnValue = DALTask.DeleteTask(taskID);
                }
                else
                {
                    returnValue = DALTask.UpdateTaskStatus(taskID, currentTaskStatus);
                }
            }
            return returnValue;
        }

        public static bool DeleteTask(long TaskID)
        {
            return MyPlanner.DAL.DALTask.DeleteTask(TaskID);
        }
    }
}
