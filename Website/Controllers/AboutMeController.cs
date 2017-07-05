using Microsoft.AspNetCore.Mvc;

namespace Amadiere.Website.Controllers
{
    public class AboutMeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}