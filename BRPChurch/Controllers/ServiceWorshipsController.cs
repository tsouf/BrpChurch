using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BRPChurch.Models;
using Microsoft.AspNetCore.Http;

namespace BRPChurch.Controllers
{
    public class ServiceWorshipsController : Controller
    {
        private readonly BRPChurchContext _context;

        public ServiceWorshipsController(BRPChurchContext context)
        {
            _context = context;
        }

        // GET: ServiceWorships
        public async Task<IActionResult> Index()
        {
            var bRPChurchContext = _context.ServiceWorship.Include(s => s.Service).Include(s => s.Worship);
            return View(await bRPChurchContext.ToListAsync());
        }

        // GET: ServiceWorships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceWorship = await _context.ServiceWorship
                .Include(s => s.Service)
                .Include(s => s.Worship)
                .SingleOrDefaultAsync(m => m.ServiceWorshipId == id);
            if (serviceWorship == null)
            {
                return NotFound();
            }

            return View(serviceWorship);
        }

        // GET: ServiceWorships/Create
        public IActionResult Create()
        {
            
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Date");
            ViewData["WorshipId"] = new SelectList(_context.Worship, "WorshipId", "Name");
          
            return View();
        }

        // POST: ServiceWorships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceWorshipId,WorshipId,ServiceId")] ServiceWorship serviceWorship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceWorship);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Leader", serviceWorship.ServiceId);
            ViewData["WorshipId"] = new SelectList(_context.Worship, "WorshipId", "Name", serviceWorship.WorshipId);
            return View(serviceWorship);
        }

        // GET: ServiceWorships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceWorship = await _context.ServiceWorship.SingleOrDefaultAsync(m => m.ServiceWorshipId == id);
            if (serviceWorship == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Date", serviceWorship.ServiceId);
            ViewData["WorshipId"] = new SelectList(_context.Worship, "WorshipId", "Name", serviceWorship.WorshipId);
            return View(serviceWorship);
        }

        // POST: ServiceWorships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceWorshipId,WorshipId,ServiceId")] ServiceWorship serviceWorship)
        {
            if (id != serviceWorship.ServiceWorshipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceWorship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceWorshipExists(serviceWorship.ServiceWorshipId))
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
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Leader", serviceWorship.ServiceId);
            ViewData["WorshipId"] = new SelectList(_context.Worship, "WorshipId", "Name", serviceWorship.WorshipId);
            return View(serviceWorship);
        }

        // GET: ServiceWorships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceWorship = await _context.ServiceWorship
                .Include(s => s.Service)
                .Include(s => s.Worship)
                .SingleOrDefaultAsync(m => m.ServiceWorshipId == id);
            if (serviceWorship == null)
            {
                return NotFound();
            }

            return View(serviceWorship);
        }

        // POST: ServiceWorships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceWorship = await _context.ServiceWorship.SingleOrDefaultAsync(m => m.ServiceWorshipId == id);
            _context.ServiceWorship.Remove(serviceWorship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceWorshipExists(int id)
        {
            return _context.ServiceWorship.Any(e => e.ServiceWorshipId == id);
        }
    }
}
