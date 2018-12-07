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
    public class WorshipTypesController : Controller
    {
        private readonly BRPChurchContext _context;

        public WorshipTypesController(BRPChurchContext context)
        {
            _context = context;
        }

        // GET: WorshipTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorshipType.ToListAsync());
        }

        // GET: WorshipTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worshipType = await _context.WorshipType
                .SingleOrDefaultAsync(m => m.WorshipTypeId == id);
            if (worshipType == null)
            {
                return NotFound();
            }

            return View(worshipType);
        }

        // GET: WorshipTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorshipTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorshipTypeId,Type")] WorshipType worshipType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worshipType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(worshipType);
        }

        // GET: WorshipTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worshipType = await _context.WorshipType.SingleOrDefaultAsync(m => m.WorshipTypeId == id);
            if (worshipType == null)
            {
                return NotFound();
            }
            return View(worshipType);
        }

        // POST: WorshipTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorshipTypeId,Type")] WorshipType worshipType)
        {
            if (id != worshipType.WorshipTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(worshipType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorshipTypeExists(worshipType.WorshipTypeId))
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
            return View(worshipType);
        }

        // GET: WorshipTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worshipType = await _context.WorshipType
                .SingleOrDefaultAsync(m => m.WorshipTypeId == id);
            if (worshipType == null)
            {
                return NotFound();
            }

            return View(worshipType);
        }

        // POST: WorshipTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worshipType = await _context.WorshipType.SingleOrDefaultAsync(m => m.WorshipTypeId == id);
            _context.WorshipType.Remove(worshipType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorshipTypeExists(int id)
        {
            return _context.WorshipType.Any(e => e.WorshipTypeId == id);
        }
    }
}
