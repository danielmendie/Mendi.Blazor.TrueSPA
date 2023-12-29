namespace Mendi.Blazor.TrueSPA.Engine.Model
{
    //
    // Summary:
    //     A single page component metadata.
    //
    // Parameters:
    //   PageName:
    //     Name of the page component.
    //
    // PageParameters:
    //     Parameters the specified page component needs
    public class SinglePageComponentMetadata
    {
        public int AppId { get; set; }
        public string AppName { get; set; } = null!;
        public string ComponentName { get; set; } = null!;
        public string ComponentPath { get; set; } = null!;
        public Dictionary<string, object> ComponentParameters { get; set; } = new Dictionary<string, object>();
    }
}
