using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Opdracht_3_1.Pages
{
    public class BestelModel : PageModel
    {
        public string BankNaam { get; set; } = "";
        public string BankBeschrijving { get; set; } = "";

        public void OnGet(string bank)
        {
            if (!string.IsNullOrEmpty(bank))
            {
                BankNaam = bank;
                BankBeschrijving = GetBankBeschrijving(bank);
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

        private string GetBankBeschrijving(string bankNaam)
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "bank.txt");
                if (System.IO.File.Exists(filePath))
                {
                    string[] lines = System.IO.File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        if (line.StartsWith(bankNaam + ":"))
                        {
                            return line.Substring(bankNaam.Length + 1).Trim();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            
            return $"Luxe {bankNaam} bank - Zeer comfortabel en stijlvol.";
        }
    }
}