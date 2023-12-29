using Blazored.LocalStorage;
using Mendi.Blazor.TrueSPA.Engine.Model;

namespace Mendi.Blazor.TrueSPA.Engine.Interfaces
{
    public interface ITrueSPAProviderService
    {
        SinglePageRoute GetCurrentPage(ISyncLocalStorageService syncLocalStorage);
        SinglePageRouteRegistry GetPageRoutes(ISyncLocalStorageService syncLocalStorage);
        void SaveCurrentPage(ISyncLocalStorageService syncLocalStorage, SinglePageRoute pageRoute);
        void SavePageRoutes(ISyncLocalStorageService syncLocalStorage, SinglePageRouteRegistry pageRoutes);
    }
}
