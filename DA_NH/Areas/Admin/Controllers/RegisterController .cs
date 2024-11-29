using DA_NH.Areas.Admin.Models;
using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using DA_NH.Utilities;

namespace DA_NH.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        
            private readonly DemoContext _context;

            public RegisterController(DemoContext context)
            {
                _context = context;
            }
            public IActionResult Index()
            {

                return View();
            }

            [HttpPost]
            public IActionResult Index(AdminUser user)
            {
                if (user == null)
                {
                    return NotFound();
                }
                var check = _context.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
                if (check != null)
                {
                    Function._MessageEmail = "Duplicate Email";
                    return RedirectToAction("Index", "Register");
                }
                Function._MessageEmail = string.Empty;

                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "Login");

            }
        
    }
}
