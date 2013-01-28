using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class DailyNote
    {
        public long DailyNoteID { get; set; }
        public DateTime ForDate { get; set; }
        public string Notes { get; set; }

        public AppUser ForUser { get; set; }
    }
}
