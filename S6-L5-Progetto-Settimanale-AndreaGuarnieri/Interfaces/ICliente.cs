using S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models;
using System.Collections.Generic;

namespace S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models.Interfaces
{
    public interface ICliente
    {
        IEnumerable<Cliente> GetAllClienti();
        Cliente GetCliente(string codiceFiscale);
        void AddCliente(Cliente cliente);
    }
}
