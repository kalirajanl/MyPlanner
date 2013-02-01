using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyPlanner.Common;

namespace MyPlanner.Models
{
    [Serializable]
    public class ContactEvent : Event
    {
        public ContactEventTypes EventType;
    }
}
