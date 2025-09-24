using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MINOR2.Pages;

public class Pagina2Model : PageModel
{
    public int EersteGetal { get; set; }

    public void OnGet(int nummer)
    {
        EersteGetal = nummer;
    }
}