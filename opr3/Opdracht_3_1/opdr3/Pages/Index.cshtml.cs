using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

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

        public void OnGet(string? param1, string? param2, string? param3, string? param4, string? param5)
        {
            if (!string.IsNullOrEmpty(param1))
            {
                BankNaam = param1;
                KlantNaam = param2 ?? "";
                Email = param3 ?? "";
                Telefoon = param4 ?? "";
                Adres = param5 ?? "";
            }
        }
    }
}
