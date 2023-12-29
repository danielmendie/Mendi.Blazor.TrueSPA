using Mendi.Blazor.TrueSPA.Engine.Utils;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Mendi.Blazor.TrueSPA.Engine
{
    internal class TrueSPADBAccessorExtension
    {
        public static async Task BuildNavigatorAccessor(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped<IndexedDbAccessor>();

            var host = builder.Build();

            using var scope = host.Services.CreateScope();
            var navigatorAccessor = scope.ServiceProvider.GetService<IndexedDbAccessor>();

            if (navigatorAccessor is not null)
                await navigatorAccessor.InitializeAsync();
        }
    }
}
