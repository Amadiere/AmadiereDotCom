using System.Net;

namespace Amadiere.Website.ViewModels.Blog
{
    public class ArticleViewModel
    {
        public BlogViewItem Article { get; set; }

        public string PublishedOn
        {
            get { return Article?.PublishedOn?.ToString("F"); }
        }

        public string FullUrl
        {
            get { return $"http://amadiere.com/blog/{Article.Year}/{Article.Month}/{Article.Slug}"; }
        }

        public string EncodedTitle
        {
            get { return WebUtility.UrlEncode(Article.Title); }
        }

        public string EncodedDescription
        {
            get { return WebUtility.UrlEncode(Article.Description); }
        }

        public string EncodedHattip
        {
            get { return WebUtility.UrlEncode($"Hi, Thought this article entitled I found at Amadiere.com would be interesting."); }
        }
    }
}
