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
