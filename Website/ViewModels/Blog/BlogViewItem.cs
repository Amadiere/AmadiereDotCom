using System;
using System.Collections.Generic;
using Amadiere.Blog.Model;

namespace Amadiere.Website.ViewModels.Blog
{
    public class BlogViewItem
    {
        public BlogViewItem() { }

        public BlogViewItem(BlogArticle article)
        {
            Year = article.Year;
            Month = article.Month;
            Slug = article.Slug;
            Title = article.Title;
            CreatedOn = article.CreatedOn;
            PublishedOn = article.PublishedOn;
            LastModifiedOn = article.LastModifiedOn;
            DeletedOn = article.DeletedOn;
            ViewName = article.ViewName;
            Tags = article.Tags;
            Description = article.Description;
        }

        public string Title { get; set; }
        public string Slug { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public string Description { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
        public DateTime? PublishedOn { get; set; }

        public string ViewName { get; set; }
    }
}
