using Realms;

namespace WhenToDig.Models
{
    public class Plant : RealmObject
    {
        [PrimaryKey]
        public int PlantId { get; set; }
        public string Name { get; set; }
        public string Variety { get; set; }
        public string Notes { get; set; }
    }
}