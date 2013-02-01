using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner.Logger
{
    public class UserActivityLogEntry : BaseLogEntry 
    {
        public UserActivityLogEntry(AppUser CurrentUser , string message)
            : base(CurrentUser)
        {
            this.Categories = new string[] { "User Activity" };
            this.Priority = 1;
            this.Severity = System.Diagnostics.TraceEventType.Information;
            this.Message = message;
        }

    }
}
