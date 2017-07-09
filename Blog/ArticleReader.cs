using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Amadiere.Blog.Model;
using Amadiere.Blog.Repositories;

namespace Amadiere.Blog
{
    public class ArticleReader
    {
        private IBlogRepository BlogRepository { get; set; }

        public ArticleReader(IBlogRepository blogRepository)
        {
            BlogRepository = blogRepository;
        }

        private IQueryable<BlogArticle> GetAllActiveArticles()
        {
            return BlogRepository.Articles.Where(x => x.DeletedOn == null);
        } 

        public BlogArticle Get(int id)
        {
            return GetAllActiveArticles().FirstOrDefault(x => x.Id == id);
        }

        public BlogArticle Get(int year, int month, string slug)
        {
            return GetAllActiveArticles().FirstOrDefault(x =>
                x.Year == year && x.Month == month && x.Slug == slug);
        }

        public IEnumerable<BlogArticle> GetAllByTag(string tag)
        {
            return GetAllActiveArticles().Where(x => x.Tags.Contains(tag));
        }
    }
}
