using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner.Logger
{
    public class GeneralActivityLogEntry : BaseLogEntry
    {

        public GeneralActivityLogEntry(string message)
            : base(null)
        {
            this.Categories = new string[] { "General Activity" };
            this.Priority = 1;
            this.Severity = System.Diagnostics.TraceEventType.Information;
            this.Message = message;
        }
    }
}
