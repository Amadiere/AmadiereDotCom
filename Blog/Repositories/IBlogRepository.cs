using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amadiere.Blog.Model;

namespace Amadiere.Blog.Repositories
{
    public interface IBlogRepository
    {
        IQueryable<BlogArticle> Articles { get; set; }
    }
}
