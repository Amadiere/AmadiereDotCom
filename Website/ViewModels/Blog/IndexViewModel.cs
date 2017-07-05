using System.Collections.Generic;

namespace Amadiere.Website.ViewModels.Blog
{
    public class IndexViewModel
    {
        public IEnumerable<BlogViewItem> Articles { get; set; }
    }
}
