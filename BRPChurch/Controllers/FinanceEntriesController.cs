using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BRPChurch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;


namespace BRPChurch.Controllers
{
    [Authorize]
    public class FinanceEntriesController : Controller
    {
        private readonly BRPChurchContext _context;

        public FinanceEntriesController(BRPChurchContext context)
        {
            _context = context;
        }

        // GET: FinanceEntries
        public async Task<IActionResult> Index()
        {
            var bRPChurchContext = _context.FinanceEntry.Include(f => f.FinanceType);
            double balance = 0;
            foreach(var Item in bRPChurchContext)
            {
                if (Item.FinanceType.Type)
                {
                    balance += Item.Amount;
                }else if (!Item.FinanceType.Type)
                {
                    balance -= Item.Amount;
                }

            }
            ViewData["Balance"] = balance;
            return View(await bRPChurchContext.ToListAsync());
        }
        [Authorize(Roles ="Admin, Treasurer")]
        public async Task<IActionResult> SelectedDate(DateRange dr)
        {
            
            HttpContext.Session.SetString("start", dr.start.ToShortDateString());
            HttpContext.Session.SetString("end", dr.end.ToShortDateString());
            return RedirectToAction(nameof(IndexFiltered));
        }
        [Authorize(Roles = "Admin, Treasurer")]
        public IActionResult SelectDate()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Treasurer")]
        public async  Task<IActionResult> IndexFiltered()
        {

            if (HttpContext.Session.GetString("start") != "" && HttpContext.Session.GetString("end") != "")
            {
                DateTime start = Convert.ToDateTime(HttpContext.Session.GetString("start"));
                DateTime end = Convert.ToDateTime(HttpContext.Session.GetString("end"));

                var bRPChurchContext = _context.FinanceEntry.Where(f => f.Date >= start && f.Date <= end).Include(f => f.FinanceType);
                double balance = 0;
                foreach (var Item in bRPChurchContext)
                {
                    if (Item.FinanceType.Type)
                    {
                        balance += Item.Amount;
                    }
                    else if (!Item.FinanceType.Type)
                    {
                        balance -= Item.Amount;
                    }

                }
                ViewData["Balance"] = balance;
                return View(await bRPChurchContext.ToListAsync());
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult FinanceEntriesPartialView(DateTime start, DateTime end)
        {
            return PartialView(_context.FinanceEntry.Where(x=>x.Date>=start && x.Date<=end).ToList());
             
        }

        // GET: FinanceEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeEntry = await _context.FinanceEntry
                .Include(f => f.FinanceType)
                .SingleOrDefaultAsync(m => m.FinanceEntryId == id);
            if (financeEntry == null)
            {
                return NotFound();
            }

            return View(financeEntry);
        }

        // GET: FinanceEntries/Create
        public IActionResult Create()
        {
            ViewData["FinanceTypeId"] = new SelectList(_context.FinanceType, "FinanceTypeId", "Title");
            return View();
        }

        // POST: FinanceEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinanceEntryId,FinanceTypeId,Description,Date,Amount")] FinanceEntry financeEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financeEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FinanceTypeId"] = new SelectList(_context.FinanceType, "FinanceTypeId", "Title", financeEntry.FinanceTypeId);
            return View(financeEntry);
        }

        // GET: FinanceEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeEntry = await _context.FinanceEntry.SingleOrDefaultAsync(m => m.FinanceEntryId == id);
            if (financeEntry == null)
            {
                return NotFound();
            }
            ViewData["FinanceTypeId"] = new SelectList(_context.FinanceType, "FinanceTypeId", "Title", financeEntry.FinanceTypeId);
            return View(financeEntry);
        }

        // POST: FinanceEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinanceEntryId,FinanceTypeId,Description,Date,Amount")] FinanceEntry financeEntry)
        {
            if (id != financeEntry.FinanceEntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financeEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanceEntryExists(financeEntry.FinanceEntryId))
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
            ViewData["FinanceTypeId"] = new SelectList(_context.FinanceType, "FinanceTypeId", "Title", financeEntry.FinanceTypeId);
            return View(financeEntry);
        }

        // GET: FinanceEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeEntry = await _context.FinanceEntry
                .Include(f => f.FinanceType)
                .SingleOrDefaultAsync(m => m.FinanceEntryId == id);
            if (financeEntry == null)
            {
                return NotFound();
            }

            return View(financeEntry);
        }

        // POST: FinanceEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var financeEntry = await _context.FinanceEntry.SingleOrDefaultAsync(m => m.FinanceEntryId == id);
            _context.FinanceEntry.Remove(financeEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanceEntryExists(int id)
        {
            return _context.FinanceEntry.Any(e => e.FinanceEntryId == id);
        }
        [Authorize(Roles = "Admin, Treasurer")]
        public async Task<IActionResult> IndexPdf()
        {

            var bRPChurchContext = _context.FinanceEntry.Include(f => f.FinanceType);
            ViewData["exists"] = "false";
            if (HttpContext.Session.GetString("start") != "" && HttpContext.Session.GetString("end") != "")
            {
                DateTime start = Convert.ToDateTime(HttpContext.Session.GetString("start"));
                DateTime end = Convert.ToDateTime(HttpContext.Session.GetString("end"));
                ViewData["start"] = HttpContext.Session.GetString("start");
                ViewData["end"] = HttpContext.Session.GetString("end");
                ViewData["exists"] = "true";

                 bRPChurchContext = _context.FinanceEntry.Where(f => f.Date >= start && f.Date <= end).Include(f => f.FinanceType);
            }
                double balance = 0;
            foreach (var Item in bRPChurchContext)
            {
                if (Item.FinanceType.Type)
                {
                    balance += Item.Amount;
                }
                else if (!Item.FinanceType.Type)
                {
                    balance -= Item.Amount;
                }

            }
            ViewData["Balance"] = balance;
            return View(await bRPChurchContext.ToListAsync());
            
        }

        public async Task<IActionResult> ResetDates()
        {
            HttpContext.Session.SetString("start","");
            HttpContext.Session.SetString("end", "");

            return RedirectToAction("IndexFiltered");
        }
    }
}
