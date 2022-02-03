using LiveTrafficProject.Areas.Identity.Data;
using LiveTrafficProject.Data;
using LiveTrafficProject.Models;
using LiveTrafficProject.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using static LiveTrafficProject.Models.Root;

namespace LiveTrafficProject.Controllers
{
    public class HomeController : ApplicationController
    {
        public HomeController(IdentityContext context, IHttpContextAccessor httpContextAccessor, ILogger<ApplicationController> logger)
            : base(context, httpContextAccessor, logger)
        {
        }

        public IActionResult Index()
        {
            
                    return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}