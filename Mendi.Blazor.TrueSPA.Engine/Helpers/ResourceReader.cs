using System.Reflection;

namespace Mendi.Blazor.TrueSPA.Engine.Helpers
{
    public class ResourceReader
    {
        public static string GetEmbeddedResourceContent(string resource)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = GetResourceName(resource, "Mendi.Blazor.TrueSPA.NavEngine.content.js");
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new Exception($"Resource '{resourceName}' not found in the assembly.");
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private static string GetResourceName(string resourcePath, string? prefix = null)
        {
            if (String.IsNullOrEmpty(prefix))
            {
                return $"{resourcePath}";
            }
            else
            {
                return $"{prefix}.{resourcePath}";
            }
        }

    }
}
