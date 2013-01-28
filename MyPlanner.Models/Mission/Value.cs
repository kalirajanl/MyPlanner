using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class Value
    {
            public int ValueID { get; set; }
            public string ValueTitle { get; set; }
            public string ValueNotes { get; set; }
            public int Sequence { get; set; }

            public AppUser ForUser { get; set; }
            public List<Category> Categories { get; set; }
    }
}
