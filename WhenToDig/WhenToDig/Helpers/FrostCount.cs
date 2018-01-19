using System;
using System.Collections.Generic;
using System.Text;

namespace WhenToDig.Helpers
{
    public class FrostCount
    {
        public string Month { get; set; }
        public int Count { get; set; }
        public int MaxFrostCount { get; set; }
        public int CountWidth
        {
            get
            {
                return (MaxFrostCount + 1) - Count;
            }
        }

        public int StartSpan
        {
            get
            {
                return Count + 1;
            }
        }
        
    }
}