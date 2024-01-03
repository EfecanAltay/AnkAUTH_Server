using Microsoft.AspNetCore.Mvc;

namespace AnkAUTH_Server;

public class LoginDataModel
{
    [BindProperty]
    public string Username {get;set;}
    [BindProperty]
    public string Password {get;set;}
}
