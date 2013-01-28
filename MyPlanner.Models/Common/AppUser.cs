using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class AppUser
    {
        public int UserID { get; set; }
        public DisplayName UserName {get;set;}
       
    }
}
