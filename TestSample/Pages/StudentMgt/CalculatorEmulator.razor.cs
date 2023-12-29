using Mendi.Blazor.TrueSPA.Common.Decorators;

namespace TestSample.Pages.StudentMgt
{
    [MarkAsSinglePageRoutableComponent(appName: "Student MGT", isDefault: true, appId: 1)]
    public partial class CalculatorEmulator
    {

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
