using Microsoft.AspNetCore.Mvc;

namespace Amadiere.Website.Controllers
{
    public class CVController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
