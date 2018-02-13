using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserData _userData;

        public UserController(IUserData userData)
        {
            _userData = userData;
        }

        public IActionResult Index(int id)
       {
            var user = this._userData.Users.Where(x => x.UserId == id);
            return View(user);
       }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Add([FromForm]UserPost user)
        {
            if (user.Password == user.Verify && !String.IsNullOrEmpty(user.Username))
            {
                if (this._userData.Users.Count <= 0)
                    
                this._userData.AddUser((User)user);
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
