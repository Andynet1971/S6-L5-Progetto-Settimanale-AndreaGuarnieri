namespace S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models
{
    public class Utente
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }  // Aggiungi questa proprietà
    }
}
