using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA_NH.Models;
using DA_NH.Utilities;

namespace DA_NH.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly DemoContext _context;

        public UsersController(DemoContext context)
        {
           
            _context = context;
        }

        // GET: Admin/Users
        public async Task<IActionResult> Index()
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(await _context.User.ToListAsync());
        }

        // GET: Admin/Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            var users = new List<User> {user};
            return View(users);
        }

		// GET: Admin/Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,Email,Password,IsActive")] User user)
        {
            if (ModelState.IsValid)
            {
                user.UserName = DA_NH.Utilities.Function.TitleSlugGenerationAlias(user.FullName);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Admin/Users/Locout/5
        public async Task<IActionResult> Locout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.User.FirstOrDefault(c => c.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult>Locout(User user)
        {
            var userInfo = _context.User.FirstOrDefault(c => c.UserId == user.UserId);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.LockoutEnabled = true;
            userInfo.LockoutEnd = DateTime.Now.AddYears(100);
            _context.User.Update(userInfo); 
            int rowAffected = _context.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["save"] = "khoa thanh cong";
                return RedirectToAction(nameof(Index));
            }
           
            return View(userInfo);
        }
		
        
		

        // GET: Admin/Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
