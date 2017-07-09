using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amadiere.Blog.Model;

namespace Blog.Tests.Builders
{
    internal class ArticleListBuilder
    {
        public IQueryable<BlogArticle> Object { get; private set; }

        public ArticleListBuilder()
        {
            Object = GetCollectionOfArticles().AsQueryable();
        }

        public ArticleListBuilder Build()
        {
            return this;
        }

        private IEnumerable<BlogArticle> GetCollectionOfArticles()
        {
            yield return GetArticle(1);
            yield return GetArticle(2, new []{ "ASP.NET MVC" });
            yield return GetArticle(3);
            yield return GetArticle(4, new []{ "PHP"}, isDeleted:true);
            yield return GetArticle(5, isDeleted:true);
            yield return GetArticle(6, new[] { "ASP.NET MVC" });
            yield return GetArticle(7);
            yield return GetArticle(8);
            yield return GetArticle(9);
        }

        private BlogArticle GetArticle(int id, string[] tags = null, bool isDeleted = false)
        {
            if (tags == null)
                tags = new[] {"Elixir", "Erlang"};

            var dateOfPost = DateTime.Now.AddDays(-id).AddDays(id);
            return new BlogArticle()
            {
                Id = id,
                PublishedOn = dateOfPost,
                CreatedOn = dateOfPost,
                DeletedOn = (isDeleted ? DateTime.Now.AddMinutes(-10) : (DateTime?)null),
                LastModifiedOn = dateOfPost,
                ViewName = $"AMA0000{id}-ViewName",
                Month = dateOfPost.Month,
                Year = dateOfPost.Year,
                Slug = $"slug-{id}-goes-here",
                Tags = tags,
                Title = $"My Blog Title {id}"
            };
        }
    }
}
