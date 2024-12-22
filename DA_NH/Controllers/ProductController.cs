using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DA_NH.Models;
using System.Diagnostics;


namespace DA_NH.Controllers
{
    public class ProductController : Controller
    {
        private readonly DemoContext _demoContext;

        public ProductController(DemoContext context)
        {
            _demoContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/product/{alias}-{id}.html")]

        public async Task<IActionResult> Details    (int? id)
        {
            if (id == null || _demoContext.MenuItems == null)
            {
                return NotFound();
            }
            var product = await _demoContext.MenuItems.Include(i => i.Category).FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (product == null)

            {
                return NotFound();
            }
            ViewBag.productReView = _demoContext.MenuReviews
                    .Where(i => i.MenuItem == id && (bool)i.IsActive).ToList();
            ViewBag.productRelated = _demoContext.MenuItems
            .Where(predicate: i => i.MenuItemId != id && i.CategoryId == product.CategoryId).OrderByDescending(i => i.MenuItemId).Take(10).ToList();
           
            // Kiểm tra trạng thái đăng nhập
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            return View(product);
        }
    }
}
