using AnkAUTH_Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnkaAUTH_Server.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger,SignInManager<ApplicationUser> signInManager)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {   
        // TODO : add Auth token control 
        return RedirectToPage("/login");
    }
}