using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using DA_NH.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DA_NH.Controllers
{

    public class RegisterController : Controller
    {
        private readonly DemoContext _demoContext;
        public RegisterController(DemoContext context)
        {
            _demoContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            //
            var check = _demoContext.User.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                //
                Function._MessageEmail = "";
                return RedirectToAction("Index", "Register");


            }
            //

            Function._MessageEmail = string.Empty;
          //  user.Password = Function.HashPassword(user.Password);
            _demoContext.Add(user);
            _demoContext.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}
