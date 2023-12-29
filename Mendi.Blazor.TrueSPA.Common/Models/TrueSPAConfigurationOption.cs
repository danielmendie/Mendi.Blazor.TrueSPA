using System.Configuration;

namespace Mendi.Blazor.TrueSPA.Common.Models
{
    public class TrueSPAConfigurationOption : ConfigurationSection
    {
        [ConfigurationProperty("ProjectsTargetAssemblyPath", IsRequired = true)]
        public string ProjectsTargetAssemblyPath
        {
            get { return (string)this["ProjectsTargetAssemblyPath"]; }
            set { this["ProjectsTargetAssemblyPath"] = value; }
        }

    }
}
