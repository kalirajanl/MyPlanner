using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class CompassRole
    {
        public int CompassRoleID { get; set; }
        public string CompassRoleName { get; set; }
        public string Notes { get; set; }
        public int Sequence { get; set; }

        public AppUser ForUser { get; set; }
    }
}
