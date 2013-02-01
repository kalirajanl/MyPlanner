using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyPlanner.Common;

namespace MyPlanner.Models
{
    [Serializable]
    public class AddressInfo
    {
        public int AddressInfoID { get; set; }
        public int Sequence { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public ContactInfoTypes AddressInfoType { get; set; }
    }
}
