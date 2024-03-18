using Umbraco.Cms.Core.Models.PublishedContent;

namespace Sibelius.Business.Extensions
{
    public static class PublishedContentExtensions
    {
        public static IPublishedContent? GetHomePage(this IPublishedContent? content)
        {
            if (content == null)
            {
                return null;
            }

            return content.AncestorsOrSelf().FirstOrDefault(x => x.ContentType.Alias.Equals(SiteConstants.Aliases.HomePage));
        }

        public static IPublishedContent? GetSiteSettings(this IPublishedContent? content)
        {
            if (content == null)
            {
                return null;
            }

            return GetHomePage(content)?.SiblingsOfType(SiteConstants.Aliases.Settings)?.FirstOrDefault();
        }

        public static string? GetImageAlt(this IPublishedContent? image)
        {
            return image?.Value<string>("alt") ?? image?.Name;
        }

        public static string? GetImageTitle(this IPublishedContent? image)
        {
            return image?.Value<string>("imageTitle") ?? image?.Name;
        }

        public static string? GetNavigationTitle(this IPublishedContent? item)
        {
            return !string.IsNullOrWhiteSpace(item?.Value<string>("navigationTitle")) ? item?.Value<string>("navigationTitle") : item?.Name;
        }
    }
}
