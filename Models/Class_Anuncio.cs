using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnuncioWebMotors.Models
{
    [Table("tb_AnuncioWebmotors")]
    public class Class_Anuncio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(45)]
        [DisplayName("Marca")]
        public string Marca { get; set; }

        [Required]
        [StringLength(45)]
        [DisplayName("Modelo")]
        public string Modelo { get; set; }

        [Required]
        [StringLength(45)]
        [DisplayName("Versão")]
        public string Versao { get; set; }

        [Required]
        [DisplayName("Ano")]
        [Range(1885, 2021, ErrorMessage = "{0} deve ser maior que {1}, até {2} !")]
        public int Ano { get; set; }

        [Required]
        [DisplayName("Quilometragem")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} deve ser maior que {1} !")]
        public int Quilometragem { get; set; }

        [Required]
        [DisplayName("Observação")]
        [DataType(DataType.MultilineText)]
        public string Observacao { get; set; }
    }
}
