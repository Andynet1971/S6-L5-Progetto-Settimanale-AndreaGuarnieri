
namespace S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models.Interfaces
{
    public interface IUtente
    {
        Utente GetUtente(string username);
        void AddUtente(Utente utente);
    }
}
