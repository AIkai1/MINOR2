using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Microsoft.Data.Sqlite;

namespace Opdracht_3_1.Pages
{
    public class BestelModel : PageModel
    {
        public string BankNaam { get; set; } = "";
        public string BankType { get; set; } = "";
        public string BankBeschrijving { get; set; } = "";
        public string BankPrijs { get; set; } = "";

        public void OnGet(string bank)
        {
            if (!string.IsNullOrEmpty(bank))
            {
                GetBankFromDatabase(bank);
            }
        }

        public IActionResult OnPost(string bank, string naam, string email, string telefoon, string adres)
        {
            // Maak een List aan met alle gegevens
            List<string> bestelling = new List<string>();
            bestelling.Add(bank);
            bestelling.Add(naam);
            bestelling.Add(email);
            bestelling.Add(telefoon);
            bestelling.Add(adres);
            
            // Zet de List in een sessie variabele met JSON
            string json = JsonSerializer.Serialize(bestelling);
            HttpContext.Session.SetString("Bestelling", json);
            
            return RedirectToPage("Index");
        }

        private void GetBankFromDatabase(string bankNaam)
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "banken.db");
            string connectionString = $"Data Source={dbPath}";
            
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Naam, Type, Beschrijving, Prijs FROM Bank WHERE Naam = $naam";
                command.Parameters.AddWithValue("$naam", bankNaam);
                
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        BankNaam = reader.GetString(0);
                        BankType = reader.GetString(1);
                        BankBeschrijving = reader.GetString(2);
                        BankPrijs = reader.GetString(3);
                    }
                }
            }
        }
    }
}