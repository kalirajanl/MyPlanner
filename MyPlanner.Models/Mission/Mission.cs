using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class Mission
    {
        public int MissionID { get; set; }
        public string MissionTitle { get; set; }
        public string MissionNotes { get; set; }
        public int Sequence { get; set; }

        public AppUser ForUser { get; set; }
        public List<Category> Categories { get; set; }
    }
}
