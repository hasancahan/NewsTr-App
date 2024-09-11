using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsAppSite_Web.Context;
using NewsAppSite_Web.Models;
using NewsAppSite_Web.ViewModels;


namespace NewsAppSite_Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly DbContextNewsApp _db;

        public AccountController(DbContextNewsApp context)
        {
            _db = context;
        }

        // Register GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Register POST
        [HttpPost]
        public async Task<IActionResult> Register(Users model)
        {
            if (ModelState.IsValid)
            {
                var mevcutKullanici = _db.Users.SingleOrDefault(u => u.Username == model.Username);
                if (mevcutKullanici != null)
                {
                    ModelState.AddModelError("", "Bu kullanıcı adı ile kayıtlı bir kullanıcı zaten var.");
                    return View(model);
                }

                var yeniKullanici = new Users
                {
                    FullName = model.FullName,
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password // Not: Şifreyi doğrudan kaydetmek güvenli değil. Hashing kullanılması tavsiye edilir.
                };
                _db.Users.Add(yeniKullanici);
                await _db.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var kullanici = _db.Users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (kullanici != null)
                {
                    HttpContext.Session.SetString("Username", kullanici.Username);
                    return RedirectToAction("Index", "NewsApp");
                }

                ModelState.AddModelError("", "Geçersiz giriş denemesi.");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserEmail");
            return RedirectToAction("Index", "Home");
        }

    }
}
