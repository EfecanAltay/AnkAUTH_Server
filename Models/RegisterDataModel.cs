using Microsoft.AspNetCore.Mvc;

namespace AnkAUTH_Server;

public class RegisterDataModel
{
    [BindProperty]
    public string Email {get;set;}
    [BindProperty]
    public string Password {get;set;}
    [BindProperty]
    public string RePassword {get;set;}
    [BindProperty]
    public string FirstName {get;set;}
    [BindProperty]
    public string LastName {get;set;}
}
