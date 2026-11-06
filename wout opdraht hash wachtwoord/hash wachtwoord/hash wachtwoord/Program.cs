using System;
// Zorg dat je BCrypt.Net hebt geïnstalleerd via NuGet (BCrypt.Net-Next)
using BCrypt.Net;

namespace login_en_registratiesysteem_wout_vullings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Wachtwoord Invoer
                Console.WriteLine("Stap 1: Voer een wachtwoord in om te registreren:");
                string wachtwoord = Console.ReadLine();

                // Controleer op lege invoer
                if (string.IsNullOrWhiteSpace(wachtwoord))
                {
                    Console.WriteLine("Fout: Het wachtwoord mag niet leeg zijn.");
                    return;
                }

                // 2. Het Wachtwoord Hashen (BCrypt genereert automatisch een veilige salt)
                Console.WriteLine("\nBezig met hashen van het wachtwoord...");
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(wachtwoord);
                Console.WriteLine($"Gegenereerde hash: {hashedPassword}");

                // 3. Het Wachtwoord Verifiëren
                Console.WriteLine("\nStap 3: Voer het wachtwoord opnieuw in om te verifiëren:");
                string invoerCheck = Console.ReadLine();

                // Controleer of de ingevoerde invoer overeenkomt met de opgeslagen hash
                bool isGelijk = BCrypt.Net.BCrypt.Verify(invoerCheck, hashedPassword);

                if (isGelijk)
                {
                    Console.WriteLine("\nSucces! Het ingevoerde wachtwoord komt overeen met de hash.");
                }
                else
                {
                    Console.WriteLine("\nFout: Het wachtwoord komt niet overeen!");
                }
            }
            catch (Exception ex)
            {
                // Vang onverwachte hash- of systeemfouten op
                Console.WriteLine($"Er is een fout opgetreden: {ex.Message}");
            }
        }
    }
}