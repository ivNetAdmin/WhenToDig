using Realms;
using System;

namespace WhenToDig.Models
{
    public class Job : RealmObject
    {
        [PrimaryKey]
        public string JobId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}