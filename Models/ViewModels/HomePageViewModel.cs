using Sibelius.Models.ViewModels.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Sibelius.Models.ViewModels
{
	public class HomePageViewModel : BaseViewModel<HomePage>
    {
		public HomePageViewModel(IPublishedContent? content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
		{
		}
	}
}
