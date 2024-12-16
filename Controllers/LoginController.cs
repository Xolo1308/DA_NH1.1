using DA_NH.Models;
using DA_NH.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DA_NH.Controllers
{
    public class LoginController : Controller
    {
        private readonly DemoContext _demoContext;
        public LoginController(DemoContext context)
        {
            _demoContext = context;
        }
        public IActionResult Index()
        {
            
            if (HttpContext.Session.GetString("User") == null)
            {
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                return View();
               
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
          public IActionResult Index(User user)
          {
              if (user == null)
              {
                  return NotFound();
              }
            // Tìm kiếm tài khoản trong cơ sở dữ liệu
            var userInfo = _demoContext.User.FirstOrDefault(m => m.UserName == user.UserName);

            if (userInfo == null)
            {
                ViewBag.ErrorMessage = "Tài khoản không tồn tại.";
                return View();
            }

            // Kiểm tra trạng thái khóa tài khoản
            if (userInfo.LockoutEnd > DateTime.Now)
            {
                ViewBag.ErrorMessage = "Tài khoản đã bị khóa. Vui lòng thử lại sau.";
                return View();
            }
            if (HttpContext.Session.GetString("UserName") == null)
              {
                var check = _demoContext.User.Where(m => (m.UserName == user.UserName) && (m.Password == user.Password)).FirstOrDefault();
                Function._Message = " Thông báo có kẻ xuân nhập!";
               

                if(check != null)
                {
                    HttpContext.Session.SetString("UserName", check.UserName.ToString());
                   
                    return RedirectToAction("Index", "Home");
                }
              }
           

            return View();
          }
          public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Login");
        }

    }
}
