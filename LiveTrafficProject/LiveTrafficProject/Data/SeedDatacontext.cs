using LiveTrafficProject.Areas.Identity.Data;
using LiveTrafficProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LiveTrafficProject.Data
{
    public class SeedDatacontext
    {
    public static async Task InitializeAsync(IServiceProvider serviceProvider, UserManager<LiveTrafficProjectUser> userManager)
    {
        using (var context = new IdentityContext(serviceProvider.GetRequiredService
                                                          <DbContextOptions<IdentityContext>>()))
        {
            context.Database.EnsureCreated();    // Zorg dat de databank bestaat

                if (!context.Language.Any())
                {
                    context.Language.AddRange(
                        new Language() { Id = "-", Name = "-", Cultures = "-", IsSystemLanguage = false },
                        new Language() { Id = "de", Name = "Deutsch", Cultures = "DE", IsSystemLanguage = false },
                        new Language() { Id = "en", Name = "English", Cultures = "UK;US", IsSystemLanguage = true },
                        new Language() { Id = "es", Name = "Español", Cultures = "ES", IsSystemLanguage = false },
                        new Language() { Id = "fr", Name = "français", Cultures = "BE;FR", IsSystemLanguage = true },
                        new Language() { Id = "nl", Name = "Nederlands", Cultures = "BE;NL", IsSystemLanguage = true }
                    );
                    context.SaveChanges();
                }

                LiveTrafficProjectUser dummy = null;
                LiveTrafficProjectUser dummy2 = null;

                if (!context.Users.Any())
                {
                    dummy = new LiveTrafficProjectUser { FirstName = "Admin", LastName = "Admin", UserName = "Admin", Email = "admin@traffic.be", LanguageId = "nl", EmailConfirmed = true};
                    userManager.CreateAsync(dummy, "@Admin12345");
                    context.Users.Add(dummy);
                    context.SaveChanges();
                   
                }


                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new IdentityRole { Id = "User", Name = "User", NormalizedName = "user" },
                        new IdentityRole { Id = "Admin", Name = "Admin", NormalizedName = "admin" }
                        );
                    context.SaveChanges();
                }

                //if (dummy != null)
                //{
                //    context.UserRoles.AddRange(
                //        new IdentityUserRole<string> { UserId = dummy.Id, RoleId = "Admin" }
                //        );
                //    context.SaveChanges();
                //}


                // Start initialisatie talen op basis van databank

                List<string> supportedLanguages = new List<string>();
                Language.AllLanguages = context.Language.ToList();
                Language.LanguageDictionary = new Dictionary<string, Language>();
                Language.SystemLanguages = new List<Language>();

                supportedLanguages.Add("nl-BE");
                foreach (Language l in Language.AllLanguages)
                {
                    Language.LanguageDictionary[l.Id] = l;
                    if (l.Id != "-")
                    {
                        if (l.IsSystemLanguage)
                            Language.SystemLanguages.Add(l);
                        supportedLanguages.Add(l.Id);
                        string[] even = l.Cultures.Split(";");
                        foreach (string e in even)
                        {
                            supportedLanguages.Add(l.Id + "-" + e);
                        }
                    }
                }
                Language.SupportedLanguages = supportedLanguages.ToArray();

            }
        }
    }
}
