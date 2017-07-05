using System;
using System.Collections.Generic;

namespace Amadiere.Website.ViewModels.Blog
{
    public class BlogViewItem
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
        public DateTime? PublishedOn { get; set; }

        public string ViewName { get; set; }
    }
}
