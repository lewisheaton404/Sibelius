using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Sibelius.Business.Services.Concrete
{
    public interface IBlogHelper
    {
        List<BlogPage> GetRelatedBlogPosts(IPublishedContent? currentPage);
    }
}
