using Mendi.Blazor.TrueSPA.Common.Decorators;
using Mendi.Blazor.TrueSPA.Engine.Model;

namespace TestSample.Pages.Intro
{
    [MarkAsSinglePageRoutableComponent(appName: "Intro", isDefault: false, appId: 0)]
    public partial class SwitchApps
    {
        Dictionary<string, SinglePageComponentMetadata> Apps { get; set; } = null!;

        protected override void OnInitialized()
        {
            Apps = GetApplicationPageRoutes().ApplicationRoutes;
        }

        void OnAppClicked(int page) => OnSwitchPageCliked(page);

    }
}
