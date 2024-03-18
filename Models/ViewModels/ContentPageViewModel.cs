using Sibelius.Models.ViewModels.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Sibelius.Models.ViewModels
{
	public class ContentPageViewModel : BaseViewModel<ContentPage>
	{
		public ContentPageViewModel(IPublishedContent? content, IPublishedValueFallback publishedValueFallback) 
			: base(content, publishedValueFallback)
		{
		}

	}
}
