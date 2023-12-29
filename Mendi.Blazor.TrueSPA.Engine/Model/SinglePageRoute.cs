namespace Mendi.Blazor.TrueSPA.Engine.Model
{
    //
    // Summary:
    //     Model class for instantiating a page route.
    //
    // Parameters:
    //   App:
    //     The current app to switched to, defaults to 0. This is used for switching
    //     between multiple apps in the same project.
    //
    //   Parent:
    //     Name of the parent page to route to(i.e page component).
    //
    //   Action:
    //     The default action to display for the parent route. This is useful for 
    //     controlling/displaying the last actions carried out on the page(e.g editing,
    //     creating, deleting or viewing). To use this, create an enum type and assign
    //     the integer value of that enum then retrieve it and use as needed.
    //
    //   Params:
    //     Parameters for the parent page
    public class SinglePageRoute
    {
        public int AppId { get; set; }
        public string AppName { get; set; } = null!;
        public string Component { get; set; } = null!;
        public int? Action { get; set; }
        public Dictionary<string, string> Params { get; set; } = new Dictionary<string, string>();
    }

}
