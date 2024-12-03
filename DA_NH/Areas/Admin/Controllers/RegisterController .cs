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

            // Kiểm tra mật khẩu có đúng 8 ký tự
            if (!IsValidPassword(user.Password))
            {
                ViewBag.ErrorMessage = "Mật khẩu phải ít nhất 8 ký tự.";
                return View();
            }

            var check = _context.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
                if (check != null)
                {
                    Function._MessageEmail = "Duplicate Email";
                    return RedirectToAction("Index", "Register");
                }
                Function._MessageEmail = string.Empty;

            // Mã hóa mật khẩu bằng Bcrypt
            user.Password = Function.HashPassword(user.Password);

                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "Login");

            }

        // Hàm kiểm tra mật khẩu hợp lệ
        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length == 8;
        }
    }
}
