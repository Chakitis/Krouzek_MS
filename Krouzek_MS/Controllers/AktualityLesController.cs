using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Krouzek_MS.Data;
using Krouzek_MS.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Krouzek_MS.Controllers
{
    [Authorize(Roles = "admin")]
    public class AktualityLesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AktualityLesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AktualityLes
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
              return View(await _context.AktualityLes.ToListAsync());
        }

        // GET: AktualityLes/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AktualityLes == null)
            {
                return NotFound();
            }

            var aktualityLes = await _context.AktualityLes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aktualityLes == null)
            {
                return NotFound();
            }

            return View(aktualityLes);
        }

        // GET: AktualityLes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AktualityLes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Title,Description")] AktualityLes aktualityLes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aktualityLes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aktualityLes);
        }

        // GET: AktualityLes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AktualityLes == null)
            {
                return NotFound();
            }

            var aktualityLes = await _context.AktualityLes.FindAsync(id);
            if (aktualityLes == null)
            {
                return NotFound();
            }
            return View(aktualityLes);
        }

        // POST: AktualityLes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Title,Description")] AktualityLes aktualityLes)
        {
            if (id != aktualityLes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aktualityLes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AktualityLesExists(aktualityLes.Id))
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
            return View(aktualityLes);
        }

        // GET: AktualityLes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AktualityLes == null)
            {
                return NotFound();
            }

            var aktualityLes = await _context.AktualityLes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aktualityLes == null)
            {
                return NotFound();
            }

            return View(aktualityLes);
        }

        // POST: AktualityLes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AktualityLes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AktualityLes'  is null.");
            }
            var aktualityLes = await _context.AktualityLes.FindAsync(id);
            if (aktualityLes != null)
            {
                _context.AktualityLes.Remove(aktualityLes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AktualityLesExists(int id)
        {
          return _context.AktualityLes.Any(e => e.Id == id);
        }
    }
}
