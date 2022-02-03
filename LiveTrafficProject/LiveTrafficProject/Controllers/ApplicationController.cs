using LiveTrafficProject.Areas.Identity.Data;
using LiveTrafficProject.Data;
using LiveTrafficProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveTrafficProject.Controllers
{
    public class ApplicationController : Controller
    {
        protected readonly LiveTrafficProjectUser _user;
        protected readonly IdentityContext _context;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ILogger<ApplicationController> _logger;

        protected ApplicationController(IdentityContext context,
                                        IHttpContextAccessor httpContextAccessor,
                                        ILogger<ApplicationController> logger)
        {
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            //string? userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            //if (userName == null)
            //    userName = "-";
            //_user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            _user = SessionUser.GetUser(httpContextAccessor.HttpContext);
        }
    }
}
