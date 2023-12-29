namespace Mendi.Blazor.TrueSPA.Engine.Model
{
    //
    // Summary:
    //     Route registry for storing/registering routes in the application.
    //
    // Parameters:
    //   ApplicationRoutes:
    //     A dictionary list of available routes the app can route to.
    public class SinglePageRouteRegistry
    {
        public Dictionary<string, SinglePageComponentMetadata> ApplicationRoutes { get; set; } = new Dictionary<string, SinglePageComponentMetadata>();
        public Dictionary<int, string> DefaultsRoutes { get; set; } = new Dictionary<int, string>();
    }
}
