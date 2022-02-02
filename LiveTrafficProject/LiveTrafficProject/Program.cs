using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LiveTrafficProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using LiveTrafficProject.Areas.Identity.Data;
using LiveTrafficProject.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using NETCore.MailKit.Infrastructure.Internal;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection");
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<LiveTrafficProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IdentityContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IEmailSender, MailKitEmailSender>();
builder.Services.Configure<MailKitOptions>(options =>
{
    options.Server = builder.Configuration["ExternalProviders:MailKit:SMTP:Address"];
    options.Port = Convert.ToInt32(builder.Configuration["ExternalProviders:MailKit:SMTP:Port"]);
    options.Account = builder.Configuration["ExternalProviders:MailKit:SMTP:Account"];
    options.Password = builder.Configuration["ExternalProviders:MailKit:SMTP:Password"];
    options.SenderEmail = builder.Configuration["ExternalProviders:MailKit:SMTP:SenderEmail"];
    options.SenderName = builder.Configuration["ExternalProviders:MailKit:SMTP:SenderName"];

    // Set it to TRUE to enable ssl or tls, FALSE otherwise
    options.Security = false;  // true zet ssl or tls aan
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedDatacontext.Initialize(services);
}

app.MapRazorPages();

app.Run();
