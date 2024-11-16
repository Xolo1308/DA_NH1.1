using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DA_NH.Controllers
{
    public class HomeController : Controller
    {
        private readonly DemoContext _demoContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(DemoContext demoContext, ILogger<HomeController> logger)
        {
            _demoContext = demoContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.MenuCategories = _demoContext.MenuCategories.ToList();
            ViewBag.productNew = _demoContext.MenuItems.Where(m => (bool)m.IsNew).ToList();
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
