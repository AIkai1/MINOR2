using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            return RedirectToPage("Index", new { 
                param1 = bank, 
                param2 = naam, 
                param3 = email, 
                param4 = telefoon,
                param5 = adres
            });
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