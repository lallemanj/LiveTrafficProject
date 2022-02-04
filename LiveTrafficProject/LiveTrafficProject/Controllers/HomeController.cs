using LiveTrafficProject.Areas.Identity.Data;
using LiveTrafficProject.Data;
using LiveTrafficProject.Models;
using LiveTrafficProject.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Text;
using static LiveTrafficProject.Models.Root;

namespace LiveTrafficProject.Controllers
{
    public class HomeController : ApplicationController
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(IdentityContext context, IHttpContextAccessor httpContextAccessor, ILogger<ApplicationController> logger, IStringLocalizer<HomeController> localizer)
            : base(context, httpContextAccessor, logger)
        {
            _localizer = localizer;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangeLanguage(string id, string returnUrl)
        {
            string culture = Thread.CurrentThread.CurrentCulture.ToString();
            string cultureUI = Thread.CurrentThread.CurrentUICulture.ToString();

            culture = id + "-" + culture.Substring(2);
            cultureUI = cultureUI.Substring(2);

            if (culture.Length != 5) culture = cultureUI = id;

            Response.Cookies.Append(

                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return LocalRedirect(returnUrl);
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