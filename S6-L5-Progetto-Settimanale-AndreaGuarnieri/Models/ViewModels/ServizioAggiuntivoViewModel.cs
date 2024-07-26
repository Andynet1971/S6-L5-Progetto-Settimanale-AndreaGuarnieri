﻿using System.ComponentModel.DataAnnotations;

namespace S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models.ViewModels
{
    public class ServizioAggiuntivoViewModel
    {
        [Required]
        public int PrenotazioneID { get; set; }

        [Required]
        public int ServizioID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        public int Quantita { get; set; }

        public List<Servizio> ServiziDisponibili { get; set; } = new List<Servizio>();
    }
}
