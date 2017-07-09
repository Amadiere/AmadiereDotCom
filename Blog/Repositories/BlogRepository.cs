using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Amadiere.Blog.Model;
using Newtonsoft.Json;

namespace Amadiere.Blog.Repositories
{
    public class BlogRepository
    {
        const string BlogFilePath = "data/blog-articles.json";

        public BlogRepository()
        {
            var rawData = File.ReadAllText(BlogFilePath);
            Articles = (JsonConvert.DeserializeObject<List<BlogArticle>>(rawData)).AsQueryable();
        }
        
        public IQueryable<BlogArticle> Articles { get; set; }
    }
}
