using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MINOR2.Pages;

public class Pagina3Model : PageModel
{
    public int EersteGetal { get; set; }
    public int TweedeGetal { get; set; }
    public int Resultaat { get; set; }

    public void OnGet(int eerste, int tweede)
    {
        EersteGetal = eerste;
        TweedeGetal = tweede;
        Resultaat = eerste + tweede;
    }
}