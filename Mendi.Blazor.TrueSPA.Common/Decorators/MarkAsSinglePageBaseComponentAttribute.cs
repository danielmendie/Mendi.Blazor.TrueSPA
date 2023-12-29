using System.Reflection;

namespace Mendi.Blazor.TrueSPA.Common.Decorators
{
    //
    // Summary:
    //     Denotes the target class as the base component class.
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    [Obfuscation(Exclude = true)]
    public class MarkAsSinglePageBaseComponentAttribute : Attribute
    {
    }
}
