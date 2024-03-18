using Sibelius.Models.ViewModels.Partials;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Sibelius.Models.ViewModels.Base
{
	public class BaseViewModel<T> : ContentModel where T : PublishedContentModel
    {
		public BaseViewModel(IPublishedContent? content, IPublishedValueFallback publishedValueFallback) : base(content)
		{
			if(content == null)
			{
				throw new NullReferenceException("content is null");
			}

			if(content is T c)
			{
				CurrentPage = c;
			}

			Meta = new MetaPartialViewModel(CurrentPage, publishedValueFallback);
		}

		public T CurrentPage { get; }

		public MetaPartialViewModel Meta { get; }
	}
}
