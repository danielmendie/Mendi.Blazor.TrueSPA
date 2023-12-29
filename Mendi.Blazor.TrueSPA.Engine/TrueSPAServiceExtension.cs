using Blazored.LocalStorage;
using Mendi.Blazor.TrueSPA.Engine.Interfaces;
using Mendi.Blazor.TrueSPA.Engine.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Mendi.Blazor.TrueSPA.Engine
{
    public static class TrueSPAServiceExtension
    {
        public static void AddBlazorTrueSPA(this IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddScoped<ITrueSPAProviderService, TrueSPAProviderService>();
            services.AddSingleton<SinglePageRouteContainer>();
            services.AddSingleton<SinglePageRouteRegistry>();
        }
    }
}
