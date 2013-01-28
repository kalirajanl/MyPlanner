using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class Contact
    {
        public Contact()
        {
            Addresses = new List<AddressInfo>();
            Phones = new List<PhoneInfo>();
            MessengerIDs = new List<MessengerInfo>();
            Relations = new List<Relation>();
            Events = new List<ContactEvent>();
            Categories = new List<Category>();
        }

        public long ContactID { get; set; }
        public DisplayName ContactName { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<AddressInfo> Addresses { get; set; }
        public List<PhoneInfo> Phones { get; set; }
        public List<MessengerInfo> MessengerIDs { get; set; }
        public List<Relation> Relations { get; set; }
        public List<ContactEvent> Events { get; set; }

        public AppUser ForUser { get; set; }
        public List<Category> Categories { get; set; }

    }
}
