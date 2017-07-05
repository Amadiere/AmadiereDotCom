namespace Amadiere.Website.ViewModels.Blog
{
    public class ArticleViewModel
    {
        public BlogViewItem Article { get; set; }

        public string PublishedOn
        {
            get { return Article?.PublishedOn?.ToString("F"); }
        }
    }
}
