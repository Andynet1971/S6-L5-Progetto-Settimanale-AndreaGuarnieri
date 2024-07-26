using System.ComponentModel.DataAnnotations;

namespace S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public IEnumerable<PrenotazioneViewModel> Prenotazioni { get; set; }
    }
}
