using Mendi.Blazor.TrueSPA.Common.Decorators;

namespace TestSample.Pages.Intro
{
    [MarkAsSinglePageRoutableComponent(appName: "Intro", isDefault: true, appId: 0)]
    public partial class StartPage
    {

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
