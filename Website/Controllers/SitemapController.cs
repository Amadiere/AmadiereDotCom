using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amadiere.Blog;
using Amadiere.Website.ViewModels.Sitemap;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Amadiere.Website.Controllers
{
    public class SitemapController : Controller
    {
        private IArticleReader Articles { get; set; }

        public SitemapController(IArticleReader articleReader)
        {
            Articles = articleReader;
        }

        [Produces("application/xml")]
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.DomainName = $"{Request.Scheme}://{Request.Host}";
            viewModel.BlogArticleUrls = Articles.GetAll().Select(x => $"blog/{x.Year}/{x.Month}/{x.Slug}");

            return View(viewModel);
        }
    }
}
