using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhenToDig.Models
{
    public class Frost : RealmObject
    {
        [PrimaryKey]
        public string FrostId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}
