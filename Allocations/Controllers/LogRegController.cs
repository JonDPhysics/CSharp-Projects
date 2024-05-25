using System;
using System.Linq;
using Microsoft.Entity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Mircosoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Allocations.Models;

namespace Allocations.Controllers
{
    public class LogRegController : Controller
    private MyContext _context {get;}

    public LogRegController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpPost("register")]
    public IActionResult Register(User fromForm)
    {
        if (ModelState.IsValid)
        {
            // Check if email is already registered.
            if (_context.Any(u => u.Email == fromForm.Email))
            {
                // if it is, send back to Index.
                return Index();
            }

            // Otherwise, encrypt the password.
            PasswordHasher<User> hasher = new PasswordHasher<User>();

            fromForm.Password = hasher.HashPassword(fromForm, fromForm.Password);

            _context.Add(fromFrom);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserID", fromForm.UserID);
            return RedirectToAction("Placeholder");
        }
        else
        {
            return Index();
        }
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUser fromForm)
    {
        if(ModelState.IsValid)
        {
            User inDb = _context.Users.FirstOrDefault(u => u.Email == fromForm.Email);

            if(inDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return Index();
            }

            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

            var result = hasher.VerifyHashedPassword(fromForm, inDb.passwordHash, fromForm.LogPassword);
            if(result == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                return Index();
            }

            HttpContext.Session.SetInt32("UserId", inDb.UserID);
            return RedirectToAction("PlaceHolder");
        }
        else
        {
            return Index();
        }
    }

    [HttpGet("logout")]
    public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    )
}