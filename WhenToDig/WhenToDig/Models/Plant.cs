using Realms;
using System;

namespace WhenToDig.Models
{
    public class Plant : RealmObject
    {
        [PrimaryKey]
        public string PlantId { get; set; }
        public string Name { get; set; }
        public string Variety { get; set; }
        public string Notes { get; set; }
    }
}