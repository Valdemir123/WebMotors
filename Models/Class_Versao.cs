using Newtonsoft.Json;

namespace AnuncioWebMotors.Models
{
    public class Class_Versao
    {
        [JsonProperty("ModelID")]
        public int ModelID { get; set; }
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }

        public Class_Versao(int _ModelID, int _ID, string _Name)
        {
            ModelID = _ModelID;
            ID = _ID;
            Name = _Name;
        }
    }
}
