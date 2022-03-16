using Microsoft.AspNetCore.Mvc;

namespace Amadiere.Website.Controllers
{
    public class AboutMeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}