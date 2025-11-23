using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Opdracht_3_1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string BankNaam { get; set; } = "";
        public string KlantNaam { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefoon { get; set; } = "";
        public string Adres { get; set; } = "";

        public void OnGet()
        {
            // Lees de sessie variabele uit
            string? json = HttpContext.Session.GetString("Bestelling");
            
            if (!string.IsNullOrEmpty(json))
            {
                List<string>? bestelling = JsonSerializer.Deserialize<List<string>>(json);
                
                if (bestelling != null && bestelling.Count >= 5)
                {
                    BankNaam = bestelling[0];
                    KlantNaam = bestelling[1];
                    Email = bestelling[2];
                    Telefoon = bestelling[3];
                    Adres = bestelling[4];
                }
                
                // Maak de sessie variabele leeg
                HttpContext.Session.Remove("Bestelling");
            }
        }
    }
}
