using Blazored.LocalStorage;
using Mendi.Blazor.TrueSPA.Engine.Helpers;
using Mendi.Blazor.TrueSPA.Engine.Model;

namespace Mendi.Blazor.TrueSPA.Engine.Interfaces
{
    public class TrueSPAProviderService : ITrueSPAProviderService
    {
        public void SaveCurrentPage(ISyncLocalStorageService syncLocalStorage, SinglePageRoute pageRoute) => Utils.Common.SetValue(syncLocalStorage, Constants.CurrentPage, pageRoute);

        public void SavePageRoutes(ISyncLocalStorageService syncLocalStorage, SinglePageRouteRegistry pageRoutes) => Utils.Common.SetValue(syncLocalStorage, Constants.PageRoutes, pageRoutes);

        public SinglePageRoute GetCurrentPage(ISyncLocalStorageService syncLocalStorage) => Utils.Common.GetValue<SinglePageRoute>(syncLocalStorage, Constants.CurrentPage);

        public SinglePageRouteRegistry GetPageRoutes(ISyncLocalStorageService syncLocalStorage) => Utils.Common.GetValue<SinglePageRouteRegistry>(syncLocalStorage, Constants.PageRoutes);


    }
}
