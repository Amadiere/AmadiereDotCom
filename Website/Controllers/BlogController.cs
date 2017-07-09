using System;
using System.Collections.Generic;
using Amadiere.Blog;
using Amadiere.Blog.Repositories;
using Amadiere.Website.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;

namespace Amadiere.Website.Controllers
{
    public class BlogController : Controller
    {
        private IArticleReader Articles { get; set; }

        //awwww, tsk tsk. Do DI, Alex.
        public BlogController() : this(new ArticleReader(new BlogRepository())) { }

        public BlogController(IArticleReader articleReader)
        {
            Articles = articleReader;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Article(int? year, int? month, string slug)
        {
            if (!year.HasValue || !month.HasValue || string.IsNullOrEmpty(slug))
                return RedirectToAction("Index");

            var article = Articles.Get(year.Value, month.Value, slug);
            if (article == null)
                return RedirectToAction("Index");

            var viewModel = new ArticleViewModel();
            viewModel.Article = new BlogViewItem(article);

            return View(viewModel);
        }
    }
}