using System.Collections.Generic;

namespace S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models.Interfaces
{
    public interface IServizio
    {
        IEnumerable<Servizio> GetAllServizi();
    }
}
