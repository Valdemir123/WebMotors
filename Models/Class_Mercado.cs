using Newtonsoft.Json;
using System.ComponentModel;

namespace AnuncioWebMotors.Models
{
    public class Class_Mercado
    {
        [JsonProperty("ID")]
        [DisplayName("Page")]
        public int ID { get; set; }

        [JsonProperty("Make")]
        [DisplayName("Marca")]
        public string Make { get; set; }

        [JsonProperty("Model")]
        [DisplayName("Modelo")]
        public string Model { get; set; }

        [JsonProperty("Version")]
        [DisplayName("Versão")]
        public string Version { get; set; }

        [JsonProperty("Image")]
        [DisplayName("Imagem")]
        public string ImageLink { get; set; }

        [JsonProperty("KM")]
        [DisplayName("Km")]
        public int KM { get; set; }

        [JsonProperty("Price")]
        [DisplayName("Preço")]
        public string Price { get; set; }

        [JsonProperty("YearModel")]
        [DisplayName("Ano Modelo")]
        public int YearModel { get; set; }

        [JsonProperty("YearFab")]
        [DisplayName("Ano Fabrica")]
        public int YearFab { get; set; }

        [JsonProperty("Color")]
        [DisplayName("Cor")]
        public string Color { get; set; }
    }
}
