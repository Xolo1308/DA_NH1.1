using Microsoft.AspNetCore.Mvc;
using DA_NH.Utilities;
namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            return View();
        }
        public IActionResult Logout()
        {
            Function._UserId = 0;
            Function._UserName = string.Empty;
            Function._Email = string.Empty;
            Function._Message = string.Empty;
            Function._MessageEmail = string.Empty;

            return RedirectToAction("Index", "Login");

        }
    }
}
