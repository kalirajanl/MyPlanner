using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyPlanner.Common;

namespace MyPlanner.Models
{
    [Serializable]
    public class MessengerInfo
    {
        public string MessengerID { get; set; }
        public int Sequence { get; set; }
        public ContactMessengerTypes MessengerType { get; set; }
        public string OtherMessengerName { get; set; }
        public string MessengerUserName { get; set; }
    }
}
