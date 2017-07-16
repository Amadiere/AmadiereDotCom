using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amadiere.Website.ViewModels.Sitemap
{
    public class IndexViewModel
    {
        public string DomainName { get; set; }
        public IEnumerable<string> BlogArticleUrls { get; set; }
    }
}
