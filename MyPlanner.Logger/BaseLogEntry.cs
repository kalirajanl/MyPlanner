using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner.Logger
{
    public class BaseLogEntry : LogEntry
    {
        public AppUser CurrentUser { get; set; }

        public BaseLogEntry(AppUser currentUser)
            : base()
        {
            CurrentUser = currentUser;
            if (CurrentUser != null)
            {
                this.ExtendedProperties.Add("UserID", CurrentUser.UserID);
                this.ExtendedProperties.Add("UserName", CurrentUser.UserName.FileAs);
            }
            else
            {
                this.ExtendedProperties.Add("UserID", 0);
                this.ExtendedProperties.Add("UserName", "Not Logged In");
            }
            this.TimeStamp = DateTime.Now;
        }
    }
}
