using Microsoft.AspNetCore.Identity;

namespace AnkAUTH_Server;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName {get;set;}
    public string LastName {get;set;}   

    public ApplicationUser() : base()
    {
        FirstName = "";
        LastName = ""; 
    }
}
