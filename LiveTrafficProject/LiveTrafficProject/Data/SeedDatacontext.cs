using Microsoft.EntityFrameworkCore;

namespace LiveTrafficProject.Data
{
    public class SeedDatacontext
    {
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new IdentityContext(serviceProvider.GetRequiredService
                                                          <DbContextOptions<IdentityContext>>()))
        {
            context.Database.EnsureCreated();    // Zorg dat de databank bestaat

           
        }
    }
}
}
