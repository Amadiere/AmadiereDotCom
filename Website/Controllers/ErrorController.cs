using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class ErrorController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index(string httpStatusCode)
        {
            ViewData["HttpStatusCode"] = (httpStatusCode == "404" ? 404 : 500);
            return View($"~/Views/Error/Http{ViewData["HttpStatusCode"]}.cshtml");
        }
    }
}