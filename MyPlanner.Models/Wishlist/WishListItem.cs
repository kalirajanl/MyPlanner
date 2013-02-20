using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace MyPlanner.Models
{
    [Serializable]
    public class WishListItem
    {
        public long WishListItemID { get; set; }
        public string ItemDescription { get; set; }
        public string ItemNotes { get; set; }
        public bool IsCompleted { get; set; }
        public int Sequence { get; set; }

        public AppUser ForUser { get; set; }
    }
}
