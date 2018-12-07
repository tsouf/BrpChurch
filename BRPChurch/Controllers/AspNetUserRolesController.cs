using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BRPChurch.Models;
using Microsoft.AspNetCore.Identity;

namespace BRPChurch.Controllers
{
    public class AspNetUserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly BRPChurchContext _context;

        public AspNetUserRolesController(BRPChurchContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

            _context = context;
        }

        // GET: AspNetUserRoles
        public async Task<IActionResult> Index()
        {
            var bRPChurchContext = _context.AspNetUserRoles.Include(a => a.Role).Include(a => a.User);
            return View(await bRPChurchContext.ToListAsync());
        }
        

        // GET: AspNetUserRoles/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.AspNetRoles, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: AspNetUserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleId")] AspNetUserRoles aspNetUserRoles)
        {
            var user = await _userManager.FindByIdAsync(aspNetUserRoles.UserId);
            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUserRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.AspNetRoles, "Id", "Name", aspNetUserRoles.RoleId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Email", aspNetUserRoles.UserId);
            return View(aspNetUserRoles);
        }
    }
}
