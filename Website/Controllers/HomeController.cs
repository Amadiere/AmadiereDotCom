﻿using Microsoft.AspNetCore.Mvc;

namespace Amadiere.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
