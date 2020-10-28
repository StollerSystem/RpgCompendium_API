using Microsoft.AspNetCore.Mvc;

namespace RpgCompendium.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
