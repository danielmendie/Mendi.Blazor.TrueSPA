using Mendi.Blazor.TrueSPA.Common.Decorators;
using Microsoft.AspNetCore.Components;

namespace TestSample.Pages.Ecommerce
{
    [MarkAsSinglePageRoutableComponent(appName: "Ecommerce", isDefault: false, appId: 2)]
    public partial class BookStoreDetails
    {
        [Parameter] public string Title { get; set; } = null!;
        [Parameter] public string BookId { get; set; } = null!;

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
