using Mendi.Blazor.TrueSPA.Common.Decorators;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TestSample.Models;

namespace TestSample.Pages.Ecommerce
{
    [MarkAsSinglePageRoutableComponent(appName: "Ecommerce", isDefault: true, appId: 2)]
    public partial class BookStore
    {
        [Parameter]
        [MarkForPageItemClicked(nextRoutablePage: nameof(BookStoreDetails))]
        public EventCallback<Dictionary<string, string>> OnBookGetMoreInfoClicked { get; set; }


        List<StoryBook>? Books;

        protected override async Task OnInitializedAsync()
        {
            Books = await Http.GetFromJsonAsync<List<StoryBook>>("sample-data/bookstore.json");
        }

        async Task OnBookClicked(StoryBook book)
        {
            Dictionary<string, string> data = new()
            {
                { "Title" , book.BookName },
                { "BookId", book.BookId.ToString() }
            };

            await OnBookGetMoreInfoClicked.InvokeAsync(data);
        }
    }
}
