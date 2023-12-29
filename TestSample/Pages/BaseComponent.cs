using Mendi.Blazor.TrueSPA.Common.Decorators;
using Mendi.Blazor.TrueSPA.Engine;
using Mendi.Blazor.TrueSPA.Engine.Model;
using Microsoft.AspNetCore.Components;
using TestSample.Pages.Ecommerce;
using TestSample.Pages.Intro;
using TestSample.Pages.StudentMgt;

namespace TestSample.Pages;
[MarkAsSinglePageBaseComponent]
public class BaseComponent : TrueSPAEngineBase
{
    [Inject]
    public HttpClient Http { get; set; } = null!;

    public override void BuildPageRoutes()
    {
        base.BuildPageRoutes();
        if (SinglePageRoute is null || string.IsNullOrWhiteSpace(SinglePageRoute?.Component))
        {
            try
            {
                var componentPath = SinglePageRoute != null ? PageRouteRegistry.DefaultsRoutes[SinglePageRoute.AppId] : PageRouteRegistry.DefaultsRoutes.FirstOrDefault().Value;
                PageRouteContainer.CurrentPageRoute = Type.GetType(componentPath);
                var getPage = PageRouteRegistry.ApplicationRoutes.FirstOrDefault(v => v.Value.ComponentPath.Equals(componentPath));
                var singlePageRoute = new SinglePageRoute
                {
                    AppId = getPage.Value.AppId,
                    AppName = getPage.Value.AppName,
                    Component = getPage.Value.ComponentName
                };
                SaveCurrentPage(singlePageRoute);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        else
        {
            try
            {
                if (SinglePageRoute.Params.Any())
                {
                    foreach (var item in SinglePageRoute.Params)
                    {
                        PageRouteRegistry.ApplicationRoutes[$"{SinglePageRoute.Component}"].ComponentParameters[item.Key] = item.Value;
                    }
                }

                var comInfo = PageRouteRegistry.ApplicationRoutes[$"{SinglePageRoute.Component}"];
                Type? page = Type.GetType(comInfo.ComponentPath);
                PageRouteContainer.CurrentPageRoute = page;
            }
            catch (Exception)
            {
                PageRouteContainer.CurrentPageRoute = Type.GetType(PageRouteRegistry.DefaultsRoutes[SinglePageRoute.AppId]);
            }
        }
    }

    public override void GetPageRoutes()
    {
        PageRouteRegistry = new SinglePageRouteRegistry
        {
            ApplicationRoutes = new()
            {
                {
                    nameof(BookStore),
                    new SinglePageComponentMetadata
                    {
                        AppId = 2,
                        AppName = "Ecommerce",
                        ComponentName = nameof(BookStore),
                        ComponentPath = "TestSample.Pages.Ecommerce.BookStore",
                        ComponentParameters = new()
                        {
                            {
                                "OnBookGetMoreInfoClicked",
                                EventCallback.Factory.Create<Dictionary<string, string>>(this, e => OnMapPageItemClicked(e, nameof(BookStoreDetails)))
                            }
                        }
                    }
                },
                {
                    nameof(BookStoreDetails),
                    new SinglePageComponentMetadata
                    {
                        AppId = 2,
                        AppName = "Ecommerce",
                        ComponentName = nameof(BookStoreDetails),
                        ComponentPath = "TestSample.Pages.Ecommerce.BookStoreDetails",
                        ComponentParameters = new()
                        {
                            {
                                "Title",
                                "Id" //value for Id will be auto substituted during navigation.
                            },
                            {
                                "BookId",
                                "Id" //value for Id will be auto substituted during navigation.
                            }
                        }
                    }
                },
                {
                    nameof(StartPage),
                    new SinglePageComponentMetadata
                    {
                        AppId = 0,
                        AppName = "Intro",
                        ComponentName = nameof(StartPage),
                        ComponentPath = "TestSample.Pages.Intro.StartPage"
                    }
                },
                {
                    nameof(Support),
                    new SinglePageComponentMetadata
                    {
                        AppId = 0,
                        AppName = "Intro",
                        ComponentName = nameof(Support),
                        ComponentPath = "TestSample.Pages.Intro.Support"
                    }
                },
                {
                    nameof(SwitchApps),
                    new SinglePageComponentMetadata
                    {
                        AppId = 0,
                        AppName = "Intro",
                        ComponentName = nameof(SwitchApps),
                        ComponentPath = "TestSample.Pages.Intro.SwitchApps"
                    }
                },
                {
                    nameof(CalculatorEmulator),
                    new SinglePageComponentMetadata
                    {
                        AppId = 1,
                        AppName = "Student MGT",
                        ComponentName = nameof(CalculatorEmulator),
                        ComponentPath = "TestSample.Pages.StudentMgt.CalculatorEmulator"
                    }
                }
            },
            DefaultsRoutes = new()
            {
                {
                    2,
                    "TestSample.Pages.Ecommerce.BookStore"
                },
                {
                    1,
                    "TestSample.Pages.StudentMgt.CalculatorEmulator"
                },
                {
                    0,
                    "TestSample.Pages.Intro.StartPage"
                }
            }
        };
        SaveApplicationRoutes(PageRouteRegistry);
        BuildPageRoutes();
    }

    public void OnMapNavMenuClicked(string page)
    {
        OnNavMenuItemCliked(page, typeof(BaseComponent));
    }

    public void OnMapPageItemClicked(Dictionary<string, string> parameters, string nextPage)
    {
        OnPageItemClicked(parameters, nextPage, typeof(BaseComponent));
    }
}