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
    public class FinanceTypesController : Controller
    {
        private readonly BRPChurchContext _context;

        public FinanceTypesController(BRPChurchContext context)
        {
            _context = context;
        }

        // GET: FinanceTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FinanceType.ToListAsync());
        }

        // GET: FinanceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeType = await _context.FinanceType
                .SingleOrDefaultAsync(m => m.FinanceTypeId == id);
            if (financeType == null)
            {
                return NotFound();
            }

            return View(financeType);
        }

        // GET: FinanceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinanceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinanceTypeId,Title,Type")] FinanceType financeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(financeType);
        }

        // GET: FinanceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeType = await _context.FinanceType.SingleOrDefaultAsync(m => m.FinanceTypeId == id);
            if (financeType == null)
            {
                return NotFound();
            }
            return View(financeType);
        }

        // POST: FinanceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinanceTypeId,Title,Type")] FinanceType financeType)
        {
            if (id != financeType.FinanceTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanceTypeExists(financeType.FinanceTypeId))
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
            return View(financeType);
        }

        // GET: FinanceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeType = await _context.FinanceType
                .SingleOrDefaultAsync(m => m.FinanceTypeId == id);
            if (financeType == null)
            {
                return NotFound();
            }

            return View(financeType);
        }

        // POST: FinanceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var financeType = await _context.FinanceType.SingleOrDefaultAsync(m => m.FinanceTypeId == id);
            _context.FinanceType.Remove(financeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanceTypeExists(int id)
        {
            return _context.FinanceType.Any(e => e.FinanceTypeId == id);
        }
    }
}
