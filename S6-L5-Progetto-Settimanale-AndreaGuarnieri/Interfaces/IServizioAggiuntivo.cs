﻿using System.Collections.Generic;

namespace S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models.Interfaces
{
    public interface IServizioAggiuntivo
    {
        void AddServizioAggiuntivo(ServizioAggiuntivo servizioAggiuntivo);
        IEnumerable<ServizioAggiuntivo> GetServiziAggiuntiviByPrenotazioneId(int prenotazioneID);
        IEnumerable<Servizio> GetAllServizi(); // Aggiungi questo metodo all'interfaccia
    }
}
