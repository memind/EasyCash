using EasyCash.DtoLayer.Dtos.AppUserDTOs;
using EasyCash.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDto dto = new AppUserEditDto()
            {
                Name = values.Name,
                Surname = values.Surname,
                District = values.District,
                City = values.City,
                ImageUrl = values.ImageUrl,
                Email = values.Email,
                PhoneNumber = values.PhoneNumber
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = model.PhoneNumber;
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.City = model.City;
                user.District = model.District;
                user.ImageUrl = "UpdateTest";

                if (model.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                }

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                    RedirectToAction("Index", "Login");
            }

            return View(model);
        }
    }
}
