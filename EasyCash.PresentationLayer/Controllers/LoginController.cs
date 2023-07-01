using EasyCash.EntityLayer.Concrete;
using EasyCash.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);

            if(result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                if (user.EmailConfirmed == true)
                    return RedirectToAction("Index", "MyAccounts");

                // else mail adresini onayla
            }
            // else kullanici adi sifre hatali
            return View();
        }
    }
}
