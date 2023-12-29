using Blazored.LocalStorage;
using Mendi.Blazor.TrueSPA.Engine.Interfaces;
using Mendi.Blazor.TrueSPA.Engine.Model;
using Microsoft.AspNetCore.Components;

namespace Mendi.Blazor.TrueSPA.Engine
{
    /// <summary>
    /// Optional base class for components. Alternatively, components may
    /// implement <see cref="IComponent"/> directly.
    /// </summary>
    public abstract class TrueSPAEngineBase : ComponentBase
    {
        [Inject] protected private NavigationManager TrueSPANavigationManager { get; set; } = null!;
        [Inject] protected private ISyncLocalStorageService LocalStorageService { get; set; } = null!;
        [Inject] protected private ITrueSPAProviderService TrueSPAProviderService { get; set; } = null!;

        [Inject] public virtual SinglePageRouteContainer PageRouteContainer { get; set; } = null!;
        [Inject] public virtual SinglePageRouteRegistry PageRouteRegistry { get; set; } = null!;
        public SinglePageRoute SinglePageRoute { get; set; } = null!;

        /// <summary>
        /// Constructs an instance of <see cref="TrueSPAEngineBase"/>.
        /// </summary>
        public TrueSPAEngineBase() { }

        /// <summary>
        /// Method invoked when scaffolding the page routes of applications
        /// base on page component configurations done
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void GetPageRoutes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method invoked when scaffolding the build routes for application.
        /// This looks at the app route tree and builds a navigation point for the 
        /// app
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void BuildPageRoutes()
        {
            SinglePageRoute = GetCurrentPage();
            PageRouteRegistry = GetApplicationPageRoutes();
        }

        /// <summary>
        /// Method invoked to switch between multiple app routes base on appId type
        /// </summary>
        /// <param name="page"></param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void OnSwitchPageCliked(int page)
        {
            try
            {
                SinglePageRoute = GetCurrentPage();
                PageRouteRegistry = GetApplicationPageRoutes();
                var component = PageRouteRegistry.DefaultsRoutes[page];
                var pageRoute = PageRouteRegistry.ApplicationRoutes.FirstOrDefault(v => v.Value.ComponentPath.Equals(component));

                var data = new SinglePageRoute
                {
                    AppId = pageRoute.Value.AppId,
                    AppName = pageRoute.Value.AppName,
                    Component = nameof(pageRoute.Value.ComponentName)
                };
                SaveCurrentPage(data);
                TrueSPANavigationManager.NavigateTo("/", forceLoad: true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Method invoked to return the previous page to the current screen.
        /// This is intended to behave like a browser's back button feature
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void OnBackToPreviousPageClicked()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method invoked when a page components item is clicked and a callback
        /// event is fired for action passing back the required params
        /// for navigation and data consumption
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="page"></param>
        /// <param name="callingComponent"></param>
        public virtual void OnPageItemClicked(Dictionary<string, string> parameters, string page, Type callingComponent)
        {
            try
            {
                if (parameters.Any())
                {
                    foreach (var item in parameters)
                    {
                        PageRouteRegistry.ApplicationRoutes[$"{page}"].ComponentParameters[item.Key] = item.Value;
                    }
                }

                PageRouteRegistry = GetApplicationPageRoutes();
                var comInfo = PageRouteRegistry.ApplicationRoutes[$"{page}"];
                PageRouteContainer.CurrentPageRoute = callingComponent.Assembly.GetType(comInfo.ComponentPath);
                SinglePageRoute = new() { AppId = comInfo.AppId, AppName = comInfo.AppName, Component = page, Params = parameters };
                SaveCurrentPage(SinglePageRoute);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        /// <summary>
        /// Method invoked when a nav menu item is clicked and a callback event
        /// is fired for the action
        /// </summary>
        /// <param name="pageComponentName"></param>
        /// <param name="callingComponent"></param>
        public virtual void OnNavMenuItemCliked(string pageComponentName, Type callingComponent)
        {
            if (!string.IsNullOrWhiteSpace(pageComponentName) && callingComponent is not null)
            {
                try
                {
                    PageRouteRegistry = GetApplicationPageRoutes();
                    var comInfo = PageRouteRegistry.ApplicationRoutes[$"{pageComponentName}"];
                    PageRouteContainer.CurrentPageRoute = callingComponent.Assembly.GetType(comInfo.ComponentPath);
                    SinglePageRoute = new() { AppId = comInfo.AppId, AppName = comInfo.AppName, Component = pageComponentName };
                    SaveCurrentPage(SinglePageRoute);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        /// <summary>
        /// Method invoked to persist page route across app life time
        /// </summary>
        /// <param name="route"></param>
        public void SaveCurrentPage(SinglePageRoute route) => TrueSPAProviderService.SaveCurrentPage(LocalStorageService, route);
        /// <summary>
        /// Method invoked to persist page routes across app life time
        /// </summary>
        /// <param name="routes"></param>
        public void SaveApplicationRoutes(SinglePageRouteRegistry routes) => TrueSPAProviderService.SavePageRoutes(LocalStorageService, routes);
        /// <summary>
        /// Method invoked to get persisited page route for app navigation
        /// </summary>
        /// <returns></returns>
        public SinglePageRoute GetCurrentPage() => TrueSPAProviderService.GetCurrentPage(LocalStorageService);
        /// <summary>
        /// Method invoked to get persisited page routes for app navigation
        /// </summary>
        /// <returns></returns>
        public SinglePageRouteRegistry GetApplicationPageRoutes() => TrueSPAProviderService.GetPageRoutes(LocalStorageService);

    }
}
