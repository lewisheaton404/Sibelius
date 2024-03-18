using Sibelius.Business.Services.Concrete;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Sibelius.Business.Services.Abstract
{
    public class BlogHelper : IBlogHelper
    {
        private readonly IPublishedValueFallback _publishedValueFallback;

        public BlogHelper(IPublishedValueFallback publishedValueFallback)
        {
            _publishedValueFallback = publishedValueFallback;
        }

        public List<BlogPage> GetRelatedBlogPosts(IPublishedContent? currentPage)
        {
            if (currentPage == null)
            {
                return [];
            }

            var blogPage = new BlogPage(currentPage, _publishedValueFallback);
            var tags = blogPage.Tags?.ToList();
            if (tags?.Count == 0)
            {
                return [];
            }

            var allBlogPosts = currentPage.Parent<BlogListingPage>()?.Children.Where(x => x.IsVisible() && !x.Id.Equals(currentPage.Id)).ToList();
            if (allBlogPosts == null)
            {
                return [];
            }
            if (allBlogPosts.Count == 0)
            {
                return [];
            }

            var rankedPosts = new Dictionary<IPublishedContent, int?>();
            foreach (var item in allBlogPosts)
            {
                var blog = new BlogPage(item, _publishedValueFallback);
                var blogTags = blog.Tags?.ToList();
                if (blogTags == null)
                {
                    continue;
                }
                if (blogTags.Count == 0)
                {
                    continue;
                }

                var hs = new HashSet<string>(blogTags);
                var total = tags?.Count(hs.Contains);
                rankedPosts.Add(item, total);
            }

            return rankedPosts.OrderBy(x => x.Value).Select(x => new BlogPage(x.Key, _publishedValueFallback)).Take(3).ToList();
        }
    }
}
