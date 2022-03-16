using Microsoft.AspNetCore.Mvc;

namespace Amadiere.Website.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
