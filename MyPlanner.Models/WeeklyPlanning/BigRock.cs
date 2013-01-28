using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class BigRock
    {
        public DateTime ForWeek { get; set; }
        public long BigRockID { get; set; }
        public string BigRockName { get; set; }
        public int Sequence { get; set; }
        public CompassRole AsCompassRole { get; set; }
        public AppUser ForUser { get; set; }
    }
}
