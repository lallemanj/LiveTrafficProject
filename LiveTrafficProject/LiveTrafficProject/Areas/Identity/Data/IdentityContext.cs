using LiveTrafficProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LiveTrafficProject.Models;

namespace LiveTrafficProject.Data;

public class IdentityContext : IdentityDbContext<LiveTrafficProjectUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }
    public DbSet<LiveTrafficProject.Models.Incident> Incident { get; set; }

    public DbSet<LiveTrafficProject.Models.Properties> Properties { get; set; }

    public DbSet<LiveTrafficProject.Models.Event> Event { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<LiveTrafficProject.Models.Language> Language { get; set; }

}
