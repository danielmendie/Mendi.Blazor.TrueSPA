using Mendi.Blazor.TrueSPA.Engine.Model;
using Microsoft.AspNetCore.Components;

namespace TestSample.Shared
{
    public partial class NavMenu
    {
        [Parameter] public EventCallback<string> OnNavMenuClicked { get; set; }

        async Task OnMenuItemClicked(string page) => await OnNavMenuClicked.InvokeAsync(page);

        SinglePageRoute Route { get; set; } = new();

        protected override void OnInitialized()
        {
            Route = GetCurrentPage();
        }
    }
}
