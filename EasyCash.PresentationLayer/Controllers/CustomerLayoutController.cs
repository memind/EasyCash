using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
