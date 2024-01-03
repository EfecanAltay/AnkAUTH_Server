using Microsoft.AspNetCore.Identity;

namespace AnkAUTH_Server;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole() : base()
    {
    }
}
