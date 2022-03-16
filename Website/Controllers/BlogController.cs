using System;
using System.Collections.Generic;
using System.Linq;
using Amadiere.Blog;
using Amadiere.Blog.Repositories;
using Amadiere.Website.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;

namespace Amadiere.Website.Controllers
{
    public class BlogController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IArticleReader Articles { get; set; }

        public BlogController(IArticleReader articleReader)
        {
            Articles = articleReader;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Articles = Articles.GetMostRecent().Select(x => new BlogViewItem(x));

            return View(viewModel);
        }

        public IActionResult Article(int? year, int? month, string slug)
        {
            if (!year.HasValue || !month.HasValue || string.IsNullOrEmpty(slug))
                return NotFound();

            var article = Articles.Get(year.Value, month.Value, slug);
            if (article == null)
                return NotFound();

            var viewModel = new ArticleViewModel();
            viewModel.Article = new BlogViewItem(article);

            return View(viewModel);
        }

        public IActionResult All()
        {
            var viewModel = new AllViewModel();
            viewModel.Articles = Articles.GetAll().Select(x => new BlogViewItem(x));

            return View(viewModel);
        }
    }
}