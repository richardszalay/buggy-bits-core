using Microsoft.AspNetCore.Html;

namespace BuggyBits.ViewModels
{
    public class ReviewsViewModel
    {
        public IHtmlContent Review1 { get; set; }
        public IHtmlContent Source1 { get; set; }

        public IHtmlContent Review2 { get; set; }
        public IHtmlContent Source2 { get; set; }
    }
}
