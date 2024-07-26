﻿using S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models.Interfaces;

namespace S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models.Services
{
    public class ServizioService
    {
        private readonly IServizio _servizioDataAccess;

        // Costruttore che inizializza il data access per i servizi
        public ServizioService(IServizio servizioDataAccess)
        {
            _servizioDataAccess = servizioDataAccess;
        }

        // Metodo per ottenere tutti i servizi
        public IEnumerable<Servizio> GetAllServizi()
        {
            // Chiama il metodo dal data access per ottenere tutti i servizi
            return _servizioDataAccess.GetAllServizi();
        }
    }
}
