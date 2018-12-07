using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BRPChurch.Models;
using System.Collections;

namespace BRPChurch.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly BRPChurchContext _context;

        public ActivitiesController(BRPChurchContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            var act = _context.Activities.Include(t => t.ActivityTag);

            var list = new List<ActivitiesViewModel>();
            foreach(var item in act.ToList())
            {
                var activityTags = _context.ActivityTag.Where(t => t.ActivityId == item.ActivityId).ToList();
                var tags = new List<string>();
                foreach(var actTag in activityTags)
                {
                    foreach(var tag in _context.ActivityType.Where(k => k.ActivityTypeId == actTag.ActivityTypeId))
                    {
                        
                    tags.Add(tag.Name);
                    }
                }
                string stringTag = "";

                for(int i = 0; i < tags.Count; i++)
                {
                    stringTag += tags[i];
                    if(i+1 < tags.Count)
                    {
                        stringTag += ", ";
                    }

                    
                }

                var vm = new ActivitiesViewModel
                {
                    Description = item.Description,
                    Date = item.Date,
                    ActivityType = stringTag,
                    ActivityId = item.ActivityId
                    
                };

                list.Add(vm);
            }


            return View(list);
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities
                .SingleOrDefaultAsync(m => m.ActivityId == id);
            if (activities == null)
            {
                return NotFound();
            }

            return View(activities);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            ViewData["Type"] = new SelectList(_context.ActivityType, "ActivityTypeId", "Name");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityId,Description,Date,Tag")] ActivitiesViewModel activities)
        {
            if (ModelState.IsValid)
            {
                var acti = new Activities { ActivityId = activities.ActivityId, Date = activities.Date, Description = activities.Description };
                _context.Add(acti);
                await _context.SaveChangesAsync();
                var act = _context.Activities.Where(m => m.Date == activities.Date).SingleOrDefault(m => m.Description == activities.Description);
                var actTag = new ActivityTag { ActivityId = act.ActivityId, ActivityTypeId = activities.Tag};
                _context.Add(actTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activities);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities.SingleOrDefaultAsync(m => m.ActivityId == id);
            if (activities == null)
            {
                return NotFound();
            }
            return View(activities);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityId,Description,Date")] Activities activities)
        {
            if (id != activities.ActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivitiesExists(activities.ActivityId))
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
           // ViewData["ActivityId"] = new SelectList(_context.ActivityType, "ActivityTypeId", "Name");

            return View(activities);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities
                .SingleOrDefaultAsync(m => m.ActivityId == id);
            if (activities == null)
            {
                return NotFound();
            }

            return View(activities);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activities = await _context.Activities.SingleOrDefaultAsync(m => m.ActivityId == id);
            _context.Activities.Remove(activities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivitiesExists(int id)
        {
            return _context.Activities.Any(e => e.ActivityId == id);
        }
    }
}
