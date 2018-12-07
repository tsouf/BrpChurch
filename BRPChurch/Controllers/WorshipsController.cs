using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BRPChurch.Models;

namespace BRPChurch.Controllers
{
    public class WorshipsController : Controller
    {
        private readonly BRPChurchContext _context;

        public WorshipsController(BRPChurchContext context)
        {
            _context = context;
        }

        // GET: Worships
        public async Task<IActionResult> Index()
        {
            var bRPChurchContext = _context.Worship.Include(w => w.WorshipType);
            return View(await bRPChurchContext.ToListAsync());
        }

        // GET: Worships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worship = await _context.Worship
                .Include(w => w.WorshipType)
                .SingleOrDefaultAsync(m => m.WorshipId == id);
            if (worship == null)
            {
                return NotFound();
            }

            return View(worship);
        }

        // GET: Worships/Create
        public IActionResult Create()
        {
            ViewData["WorshipTypeId"] = new SelectList(_context.WorshipType, "WorshipTypeId", "Type");
            return View();
        }

        // POST: Worships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorshipId,WorshipTypeId,Name,Text")] Worship worship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorshipTypeId"] = new SelectList(_context.WorshipType, "WorshipTypeId", "Type", worship.WorshipTypeId);
            return View(worship);
        }

        // GET: Worships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worship = await _context.Worship.SingleOrDefaultAsync(m => m.WorshipId == id);
            if (worship == null)
            {
                return NotFound();
            }
            ViewData["WorshipTypeId"] = new SelectList(_context.WorshipType, "WorshipTypeId", "Type", worship.WorshipTypeId);
            return View(worship);
        }

        // POST: Worships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorshipId,WorshipTypeId,Name,Text")] Worship worship)
        {
            if (id != worship.WorshipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(worship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorshipExists(worship.WorshipId))
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
            ViewData["WorshipTypeId"] = new SelectList(_context.WorshipType, "WorshipTypeId", "Type", worship.WorshipTypeId);
            return View(worship);
        }

        // GET: Worships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worship = await _context.Worship
                .Include(w => w.WorshipType)
                .SingleOrDefaultAsync(m => m.WorshipId == id);
            if (worship == null)
            {
                return NotFound();
            }

            return View(worship);
        }

        // POST: Worships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worship = await _context.Worship.SingleOrDefaultAsync(m => m.WorshipId == id);
            _context.Worship.Remove(worship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorshipExists(int id)
        {
            return _context.Worship.Any(e => e.WorshipId == id);
        }
    }
}
