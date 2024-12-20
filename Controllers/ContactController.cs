using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DA_NH.Controllers
{
    public class ContactController : Controller
    {
        private readonly DemoContext _demoContext;
        public ContactController(DemoContext context)
        {
            _demoContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name,string phone,string email,string message)
        {
            try
            {
                TblContact contact = new TblContact();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Message = message;
                contact.CreateDate = DateTime.Now;

                _demoContext.Add(contact);
                _demoContext.SaveChanges();

                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}