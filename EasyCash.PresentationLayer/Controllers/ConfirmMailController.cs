using EasyCash.EntityLayer.Concrete;
using EasyCash.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index()
		{
			var mail = TempData["Mail"];
			return View(new ConfirmMailVM { Email = (string)mail});
		}

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email.ToString());

            if(user.TwoFactorCode == model.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }
    }
}
