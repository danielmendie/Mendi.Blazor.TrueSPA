using System.Reflection;

namespace Mendi.Blazor.TrueSPA.Common.Decorators
{
    //
    // Summary:
    //     Denotes the target property as an event callback candidate for OnPageItemClicked.
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    [Obfuscation(Exclude = true)]
    public class MarkForPageItemClickedAttribute : Attribute
    {
        //
        // Summary:
        //     Gets or sets the next page to route from this current page
        private readonly string nextRoutablePage;

        public MarkForPageItemClickedAttribute(string nextRoutablePage)
        {
            this.nextRoutablePage = nextRoutablePage;
        }

        public string NextRoutablePage => nextRoutablePage;
    }
}
