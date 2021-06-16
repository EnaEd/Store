using System;

namespace Store.BlazorClient.Providers
{
    public class StateContainer//state managment
    {
        private bool _isAuthenticated;
        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set
            {
                _isAuthenticated = value;
                NotifayStateChanged();
            }
        }




        public event Action OnChange;
        private void NotifayStateChanged() => OnChange?.Invoke();
    }
}
