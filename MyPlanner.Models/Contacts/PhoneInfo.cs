using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class PhoneInfo
    {
        public string PhoneInfoID { get; set; }
        public int Sequence { get; set; }
        public ContactPhoneTypes PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public string OtherPhoneType { get; set; }
    }
}
