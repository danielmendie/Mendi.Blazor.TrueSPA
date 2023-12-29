using Blazored.LocalStorage;

namespace Mendi.Blazor.TrueSPA.Engine.Utils
{
    public class Common
    {
        public Common()
        { }

        public static bool IsAnyNullOrEmpty(object obj)
        {
            if (obj is null)
                return true;

#pragma warning disable CS8604 // Possible null reference argument.
            return obj.GetType().GetProperties()
                .Any(x => IsNullOrEmpty(x.GetValue(obj)));
#pragma warning restore CS8604 // Possible null reference argument.
        }

        private static bool IsNullOrEmpty(object value)
        {
            if (value is null)
                return true;

            var type = value.GetType();
            return type.IsValueType && Equals(value, Activator.CreateInstance(type));
        }

        public static void SetValue<T>(ISyncLocalStorageService localStorageService, string sessionName, T Value)
        {
            localStorageService.SetItem<T>(sessionName, Value);
        }

        public static T GetValue<T>(ISyncLocalStorageService localStorageService, string sessionName)
        {
            return localStorageService.GetItem<T>(sessionName);
        }

        public static void DeleteValue(ISyncLocalStorageService localStorageService, string sessionName)
        {
            localStorageService.RemoveItem(sessionName);
        }

        public static void ClearStorage(ISyncLocalStorageService localStorageService)
        {
            localStorageService.Clear();
        }

    }

}