namespace Mendi.Blazor.TrueSPA.Engine.Model
{
    public class SinglePageRouteContainer
    {
        private Type? _currentPageRoute;

        public Type? CurrentPageRoute
        {
            get => _currentPageRoute;
            set
            {
                _currentPageRoute = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
