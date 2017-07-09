using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amadiere.Blog.Model;

namespace Amadiere.Blog
{
    public interface IArticleReader
    {
        BlogArticle Get(int id);
        BlogArticle Get(int year, int month, string slug);

        IEnumerable<BlogArticle> GetAllByTag(string tag);
        IEnumerable<BlogArticle> GetMostRecent();
    }
}
