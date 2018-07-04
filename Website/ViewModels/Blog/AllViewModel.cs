using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amadiere.Website.ViewModels.Blog
{
    public class AllViewModel
    {
        public IEnumerable<BlogViewItem> Articles { get; set; }
    }
}
