using AnkAUTH_Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnkaAUTH_Server.Pages;

public class LoginModel : PageModel
{
    SignInManager<ApplicationUser> _signInManager;
    
    public string Message {get;set;}
    public string Password {get;set;}

    private readonly ILogger<LoginModel> _logger;

    public LoginModel(ILogger<LoginModel> logger, SignInManager<ApplicationUser> signInManager)
    {
        _logger = logger;
        Message = "";
        _signInManager = signInManager;
    }

    public void OnGet()
    {

    }

    public async Task OnPostSubmit(LoginDataModel loginModel)
    {
        var si = await _signInManager.PasswordSignInAsync(loginModel.Username,loginModel.Password,true,false);
        Console.WriteLine(loginModel.Username + ":" + loginModel.Password);
        if(si.Succeeded)
        {
            ViewData["Message"] = "Success";
        }else{;
            ViewData["Message"] = "Your Username or password incorrect !.";
        }
        
        var loginResponse = await _signInManager.PasswordSignInAsync("test","test",true,false);
    }

    public void ChangePassword(){
            //_userManager.GenerateUserTokenAsync()
    }
}

