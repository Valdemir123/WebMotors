using Newtonsoft.Json;

namespace AnuncioWebMotors.Models
{
    public class Class_Modelo
    {
        [JsonProperty("MakeID")]
        public int MakeID { get; set; }
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }

        public Class_Modelo(int _MakeID,int _ID, string _Name)
        {
            MakeID = _MakeID;
            ID = _ID;
            Name = _Name;
        }
    }
}
