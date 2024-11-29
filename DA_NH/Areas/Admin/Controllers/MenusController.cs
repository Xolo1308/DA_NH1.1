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
    public class MenusController : Controller
    {
        private readonly DemoContext _context;

        public MenusController(DemoContext context)
        {
            _context = context;
        }

        // GET: Admin/Menus
        public async Task<IActionResult> Index()
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(await _context.TblMenus.ToListAsync());
        }

        // GET: Admin/Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMenu = await _context.TblMenus
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (tblMenu == null)
            {
                return NotFound();
            }

            return View(tblMenu);
        }

        // GET: Admin/Menus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,Title,Alias,Description,Levels,Position,ParentId,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] TblMenu tblMenu)
        {
            if (ModelState.IsValid)
            {
                tblMenu.Alias = DA_NH.Utilities.Function.TitleSlugGenerationAlias(tblMenu.Title);
                _context.Add(tblMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblMenu);
        }

        // GET: Admin/Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMenu = await _context.TblMenus.FindAsync(id);
            if (tblMenu == null)
            {
                return NotFound();
            }
            return View(tblMenu);
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuId,Title,Alias,Description,Levels,Position,ParentId,CreateDate,CreateBy,ModifiedDate,ModifiedBy,IsActive")] TblMenu tblMenu)
        {
            if (id != tblMenu.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMenuExists(tblMenu.MenuId))
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
            return View(tblMenu);
        }

        // GET: Admin/Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMenu = await _context.TblMenus
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (tblMenu == null)
            {
                return NotFound();
            }

            return View(tblMenu);
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblMenu = await _context.TblMenus.FindAsync(id);
            if (tblMenu != null)
            {
                _context.TblMenus.Remove(tblMenu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMenuExists(int id)
        {
            return _context.TblMenus.Any(e => e.MenuId == id);
        }
    }
}
