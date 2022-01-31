using Microsoft.EntityFrameworkCore;

namespace LiveTrafficProject.Data
{
    public class SeedDatacontext
    {
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new LiveTrafficProjectContext(serviceProvider.GetRequiredService
                                                          <DbContextOptions<LiveTrafficProjectContext>>()))
        {
            context.Database.EnsureCreated();    // Zorg dat de databank bestaat

           
        }
    }
}
}
