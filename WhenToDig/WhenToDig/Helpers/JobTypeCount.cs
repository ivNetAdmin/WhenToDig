using System;
using System.Collections.Generic;
using System.Text;

namespace WhenToDig.Helpers
{
    public class JobTypeCount
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int CountWidth
        {
            get
            {
                return Convert.ToInt32(100 - Count);
            }
        }

        public int StartSpan
        {
            get
            {
                return Convert.ToInt32(Count + 1);
            }
        }
    }
}
