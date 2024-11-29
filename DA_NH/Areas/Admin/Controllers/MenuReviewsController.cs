using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA_NH.Models;
using System.Reflection.Metadata;
using DA_NH.Utilities;

namespace DA_NH.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuReviewsController : Controller
    {
        private readonly DemoContext _context;

        public MenuReviewsController(DemoContext context)
        {
            _context = context;
        }

        // GET: Admin/MenuReviews
        public async Task<IActionResult> Index()
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            var demoContext = _context.MenuReviews.Include(m => m.MenuItemNavigation);
            return View(await demoContext.ToListAsync());
        }

        // GET: Admin/MenuReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuReview = await _context.MenuReviews
                .Include(m => m.MenuItemNavigation)
                .FirstOrDefaultAsync(m => m.ProductReviewId == id);
            if (menuReview == null)
            {
                return NotFound();
            }

            return View(menuReview);
        }

        // GET: Admin/MenuReviews/Create
        public IActionResult Create()
        {
            ViewData["MenuItem"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemId");
            return View();
        }

        // POST: Admin/MenuReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductReviewId,Name,Description,Image,Phone,Position,Email,MenuItem,star,CreateDate,IsActive")] MenuReview menuReview)
        {
            if (ModelState.IsValid)
            {
                menuReview.Alias = DA_NH.Utilities.Function.TitleSlugGenerationAlias(menuReview.Name);
                _context.Add(menuReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuItem"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemId", menuReview.MenuItem);
            return View(menuReview);
        }

        // GET: Admin/MenuReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuReview = await _context.MenuReviews.FindAsync(id);
            if (menuReview == null)
            {
                return NotFound();
            }
            ViewData["MenuItem"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemId", menuReview.MenuItem);
            return View(menuReview);
        }

        // POST: Admin/MenuReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductReviewId,Name,Description,Image,Phone,Position,Email,MenuItem,star,CreateDate,IsActive")] MenuReview menuReview)
        {
            if (id != menuReview.ProductReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuReviewExists(menuReview.ProductReviewId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuItem"] = new SelectList(_context.MenuItems, "MenuItemId", "MenuItemId", menuReview.MenuItem);
            return View(menuReview);
        }

        // GET: Admin/MenuReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuReview = await _context.MenuReviews
                .Include(m => m.MenuItemNavigation)
                .FirstOrDefaultAsync(m => m.ProductReviewId == id);
            if (menuReview == null)
            {
                return NotFound();
            }

            return View(menuReview);
        }

        // POST: Admin/MenuReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuReview = await _context.MenuReviews.FindAsync(id);
            if (menuReview != null)
            {
                _context.MenuReviews.Remove(menuReview);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuReviewExists(int id)
        {
            return _context.MenuReviews.Any(e => e.ProductReviewId == id);
        }
    }
}
