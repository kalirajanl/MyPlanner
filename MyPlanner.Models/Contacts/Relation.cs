﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Models
{
    [Serializable]
    public class Relation
    {
        public int RelationID { get; set; }
        public int Sequence { get; set; }
        public DisplayName Person { get; set; }
        public ContactRelations RelationWithPerson { get; set; }
        public string OtherRelationName { get; set; }
    }
}
