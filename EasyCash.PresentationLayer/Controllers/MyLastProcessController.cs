using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
    public class MyLastProcessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
