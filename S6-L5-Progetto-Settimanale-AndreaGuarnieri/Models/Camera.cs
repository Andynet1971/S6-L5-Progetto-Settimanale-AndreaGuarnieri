using System.ComponentModel.DataAnnotations;

namespace S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models
{
    public class Camera
    {
        [Key]
        public int Numero { get; set; }

        [Required]
        public string Descrizione { get; set; }

        [Required]
        public string Tipologia { get; set; }

        [Required]
        public decimal TariffaGiornaliera { get; set; }

        [Required]
        public bool Disponibile { get; set; }
    }
}
