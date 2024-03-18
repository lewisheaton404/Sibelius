using Sibelius.Business.Services.Abstract;
using Sibelius.Business.Services.Concrete;
using Umbraco.Cms.Core.Composing;

namespace Sibelius.Business.Compositions
{
    public class ServiceComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddSingleton<IBlogHelper, BlogHelper>();
        }
    }
}
