using Newtonsoft.Json;

namespace AnuncioWebMotors.Models
{
    public class Class_Marca
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }

        public Class_Marca(int _ID, string _Name)
        {
            ID = _ID;
            Name = _Name;
        }
    }
}
