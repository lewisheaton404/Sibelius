using Sibelius.Business.Extensions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Sibelius.Models.ViewModels.Partials
{
    public class MetaPartialViewModel : MetaComposition
    {
        public MetaPartialViewModel(IPublishedContent? currentPage, IPublishedValueFallback publishedValueFallback) : base(currentPage, publishedValueFallback)
        {
            var settingsNode = currentPage?.GetSiteSettings();
            var settings = new SiteSettings(settingsNode, publishedValueFallback);
            var noIndexValue = settings?.NoIndex ?? false ? "noindex" : "index";
            var noFollowValue = settings?.NoFollow ?? false ? "nofollow" : "follow";

            PageTitle = settings?.PageTitlePrefix?.Replace("{0}", !string.IsNullOrWhiteSpace(MetaTitle) ? MetaTitle : currentPage?.Name);
            NoIndexNoFollowValue = $"{noIndexValue}, {noFollowValue}";
        }

        public string? PageTitle { get; }
        public string? NoIndexNoFollowValue { get; }
    }
}
