using LiveTrafficProject.Areas.Identity.Data;
using LiveTrafficProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LiveTrafficProject.Data
{
    public class SeedDatacontext
    {
    public static void Initialize(IServiceProvider serviceProvider, UserManager<LiveTrafficProjectUser> userManager)
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
                LiveTrafficProjectUser user = null;

                if (!context.Users.Any())
                {
                    LiveTrafficProjectUser dummy = new LiveTrafficProjectUser { Id = "-", FirstName = "-", LastName = "-", UserName = "-", Email = "?@?.?", LanguageId = "-" };
                    context.Users.Add(dummy);
                    context.SaveChanges();
                    user = new LiveTrafficProjectUser
                    {
                        FirstName = "System",
                        LastName = "Administrator",
                        UserName = "Admin",
                        Email = "System.Administrator@traffic.be",
                        LanguageId = "nl",
                        EmailConfirmed = true
                    };
                    userManager.CreateAsync(user, "Abc!12345");
                }

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new IdentityRole { Id = "User", Name = "User", NormalizedName = "user" },
                        new IdentityRole { Id = "SystemAdministrator", Name = "SystemAdmninistrator", NormalizedName = "systemadministrator" },
                        new IdentityRole { Id = "UserAdministrator", Name = "UserAdministrator", NormalizedName = "useradministrator" });
                    context.SaveChanges();
                }

                //if (user != null)
                //{
                //    context.UserRoles.AddRange(
                //        new IdentityUserRole<string> { UserId = user.Id, RoleId = "UserAdministrator" },
                //        new IdentityUserRole<string> { UserId = user.Id, RoleId = "SystemAdministrator" },
                //        new IdentityUserRole<string> { UserId = user.Id, RoleId = "User" });
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
