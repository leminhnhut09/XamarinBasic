using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace BlogApp.ViewModels
{
    public class ConnectivityViewModel : ViewModelBase
    {
        private bool _isInternet;
        public bool IsInternet
        {
            get { return _isInternet; }
            set { SetProperty(ref _isInternet, value); }
        }

        private int _blurRatio;
        public int BlurRatio
        {
            get { return _blurRatio; }
            set { SetProperty(ref _blurRatio, value); }
        }

        public ConnectivityViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            GetStatusInternet();
        }

        private void GetStatusInternet()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                BlurRatio = 0;
                IsInternet = true;
            }
            else
            {
                BlurRatio = 1;
                IsInternet = false;
            }
        }

        public override void OnAppearing()
        {
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                BlurRatio = 0;
                IsInternet = true;
            }
            else
            {
                BlurRatio = 1;
                IsInternet = false;
            }
        }
        public override void OnDisappearing()
        {
            Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        }
    }
}
