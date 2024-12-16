using DA_NH.Areas.Admin.Models;
using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using DA_NH.Utilities;
using Microsoft.EntityFrameworkCore;
using DA_NH.Services;

namespace DA_NH.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {

        private readonly DemoContext _context;
        private readonly LoginAttemptService _loginAttemptService;
        public LoginController(DemoContext context, LoginAttemptService loginAttemptService)
        {
            _context = context;
            _loginAttemptService = loginAttemptService;
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

            if (_loginAttemptService.IsLockedOut(user.UserName))
            {
                ViewBag.ErrorMessage = "Tài khoản đã bị khóa tạm thời do đăng nhập sai quá nhiều lần. Vui lòng thử lại sau. 1 phút";
                return View();
            }

            var check = _context.AdminUsers.Where(m => (m.UserName == user.UserName) && (m.Password == user.Password)).FirstOrDefault();

            if (check == null)
            {
                _loginAttemptService.RecordFailedAttempt(user.UserName);
                Function._Message = "Thông báo có kẻ xâm nhập hệ thống  ";
                return RedirectToAction("Index", "Login");
            }

            //đăth lại trại thái đăng nhập thất bại nếu thành công
            _loginAttemptService.ResetFailedAttempts(user.UserName); 

            // vào trang Admin nếu đúng user và pass
            Function._Message = string.Empty;
            Function._UserId = check.UserId;
            Function._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;

            return RedirectToAction("Index", "Home");
        }
    }
}
