using System;
using System.Collections.Generic;
using Amadiere.Website.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;

namespace Amadiere.Website.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Article(int? year, int? month, string slug)
        {
            var viewModel = new ArticleViewModel();
            viewModel.Article = new BlogViewItem()
            {
                // Incoming parameters
                Year = year,
                Month = month,
                Slug = slug,

                // Made up stuff.
                Title = "ASP.NET MVC 3: Drop Down Lists / SelectLists",
                CreatedOn = new DateTime(2011, 08, 30, 10, 42, 0),
                PublishedOn = new DateTime(2011, 08, 30, 10, 42, 0),
                LastModifiedOn = new DateTime(2011, 08, 30, 10, 42, 0),
                DeletedOn = null,
                ViewName = "AMA00001_AspNetMvc3DropdownLists",
                Tags = new List<string>() { "JQuery", "ASP.NET MVC" }
            };

            return View(viewModel);
        }
    }
}