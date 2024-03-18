using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Sibelius.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Sibelius.Controllers
{
	public class ContentPageController : RenderController
	{
		private readonly IPublishedValueFallback _publishedValueFallback;

        public ContentPageController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IPublishedValueFallback publishedValueFallback) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _publishedValueFallback = publishedValueFallback;
        }

        public override IActionResult Index()
		{
			return CurrentTemplate(new ContentPageViewModel(CurrentPage, _publishedValueFallback));
		}
	}
}
