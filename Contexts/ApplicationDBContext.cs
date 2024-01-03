using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnkAUTH_Server;

public class ApplicationDBContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> context): base(context)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
    }
}
