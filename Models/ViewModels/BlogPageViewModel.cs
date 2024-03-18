using Sibelius.Models.ViewModels.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Sibelius.Models.ViewModels
{
	public class BlogPageViewModel : BaseViewModel<BlogPage>
	{
		public BlogPageViewModel(IPublishedContent? content, IPublishedValueFallback publishedValueFallback) 
			: base(content, publishedValueFallback)
		{
			const string dateForm = "d MMMM yyyy";
			var blogPage = new BlogPage(content, publishedValueFallback);
			PublishedDate = blogPage.PublishedDateOverride != default
				? blogPage.PublishedDateOverride.ToString(dateForm)
				: content!.CreateDate.ToString(dateForm);
		}

		public string PublishedDate { get; set; }
	}
}
