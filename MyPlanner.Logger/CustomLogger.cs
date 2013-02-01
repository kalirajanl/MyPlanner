using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner.Logger
{
    public class CustomLogger
    {
        public static void WriteGeneralActivity(string message, bool async=true)
        {
            GeneralActivityLogEntry logEntry = new GeneralActivityLogEntry(message);
            if (!async)
            {
                writeLog(logEntry);
            }
            else
            {
                System.Threading.Tasks.Task.Factory.StartNew(() => writeLog(logEntry));
            }
        }

        public static void WriteUserActivity(AppUser currentUser, string message, bool async = false)
        {
            UserActivityLogEntry logEntry = new UserActivityLogEntry(currentUser, message);
            if (!async)
            {
                writeLog(logEntry);
            }
            else
            {
                System.Threading.Tasks.Task.Factory.StartNew(() => writeLog(logEntry));
            }
        }

        private static void writeLog(BaseLogEntry logEntry)
        {
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(logEntry);
        }
    }
}
