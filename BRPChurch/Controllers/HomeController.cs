using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BRPChurch.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BRPChurch.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly BRPChurchContext _context;
        private readonly IHostingEnvironment _env;
        public HomeController(IHostingEnvironment env, BRPChurchContext context, UserManager<ApplicationUser> userManager)
        {
            _env = env;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Constitution()
        {

            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }
        public IActionResult History()
        {

            return View();
        }
        public IActionResult Children()
        {

            return View();
        }
        public IActionResult Youth()
        {

            return View();
        }
        [Authorize]
        public async Task<IActionResult> Media(string description, string title, IFormFile pic)
        {
            ViewData["desc"] = description;
            if (pic != null)
            {
                var fileName = Path.Combine(_env.WebRootPath + "/Uploads/", Path.GetFileName(pic.FileName));
                pic.CopyTo(new FileStream(fileName, FileMode.Create));
                var filePath = "/Uploads/" + Path.GetFileName(pic.FileName);
                ViewData["fileLocation"] = filePath;

                System.Security.Claims.ClaimsPrincipal currentClaim = this.User;
                var currentUser = await _userManager.GetUserAsync(currentClaim);
                var currentEmail = currentUser.Email;
                var picture = new Picture
                {
                    title = title,
                    description = description,
                    date = DateTime.Now,
                    email = currentEmail,
                    path = filePath
                };
                _context.Add(picture);
                await _context.SaveChangesAsync();
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SlideShow()
        {
            List<string> uploads = new List<string>();
            List<string> picTypes = new List<string> { "*.jpg", "*.png", "*.jpeg", "*.gif" };
            foreach (var type in picTypes)
            { 
                string[] typeUploads = Directory.GetFiles(_env.WebRootPath + "\\Uploads\\", type).Select(Path.GetFileName).ToArray();
                foreach (var pic in typeUploads)
                {
                    uploads.Add(pic);

                }
            }
            ViewData["paths"] = uploads.ToArray();
            return View(uploads.ToArray());
        }
    }
}

    

