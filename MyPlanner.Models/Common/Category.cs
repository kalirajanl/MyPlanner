using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int Sequence { get; set; }
        public AppUser ForUser { get; set; }
    }
}
