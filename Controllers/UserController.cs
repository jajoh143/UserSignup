using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserSignup.ApplicationContext;
using UserSignup.Models;

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
       
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
       {
            var users = this._context.Users;
            ViewBag.Users = users;
            return View();
       }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Add([FromForm]UserPost user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User()
                {
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password
                };
                this._context.Users.Add(newUser);
                return RedirectToAction("Index",
                    new
                    {
                      id = user.UserId
                    });
            }
            else
            {
                ViewBag.PasswordError = user.Password != user.Verify ? "Your passwords must match" : "";
                ViewBag.UsernameError = String.IsNullOrEmpty(user.Username) ? "You must enter a username." : "";
                return View(user);
            }
        }
    }
}
