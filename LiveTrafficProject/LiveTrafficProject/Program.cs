using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LiveTrafficProject.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LiveTrafficProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LiveTrafficProjectContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedDatacontext.Initialize(services);
}

app.Run();
