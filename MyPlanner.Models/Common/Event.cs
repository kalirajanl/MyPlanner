using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class Event
    {
        public Event()
        {
            Categories = new List<Category>();
        }

        public int EventID { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartsFrom { get; set; }
        public DateTime EndsAt { get; set; }
        public bool IsAllDayEvent { get; set; }     
        public bool IsRecurring { get; set; }
        public ISchedule Recurrence { get; set; }

        public AppUser ForUser { get; set; }
        public List<Category> Categories { get; set; }
    }

}
