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
    }
}
