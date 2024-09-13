using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ApiFutebol.Models
{
    [Table("JogadoresFutebol")]
    public class JogadorFutebol
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string? Time { get; set; }
        [Required]
        public int Idade { get; set; }
        public string? Posicao { get; set; }
        public string? Nacionalidade { get; set; }
        public int? NumeroCamisa { get; set; }
        [Required]
        public string Status { get; set; }

    }
}
