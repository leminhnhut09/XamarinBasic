using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class ConnectivityViewModel : BindableBase, IPageLifecycleAware
    {
        protected IPageDialogService _pageDialogService;
        private int _opacity;
        public int Opacity
        {
            get { return _opacity; }
            set { SetProperty(ref _opacity, value); }
        }

        private string _connectionProfile;
        public string ConnectionProfile
        {
            get { return _connectionProfile; }
            set { SetProperty(ref _connectionProfile, value); }
        }
        public DelegateCommand OnConnectionCommand { get; set; }
        public ConnectivityViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            OnConnectionCommand = new DelegateCommand(HandleConnection);
        }

        private async void HandleConnection()
        {
            //ConnectionProfile = Connectivity.ConnectionProfiles.ToString();
            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await _pageDialogService.DisplayAlertAsync("Noti", "No internet", "Try Connect");
                return;
            }
            await _pageDialogService.DisplayAlertAsync("Noti", "Login success", "Login success");
        }

        public void OnAppearing()
        {
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if(e.NetworkAccess == NetworkAccess.Internet)
            {
                Opacity = 0;
                //ConnectionProfile = e.ConnectionProfiles.ToString();
            }
            else
            {
                Opacity = 1;
                //ConnectionProfile = e.ConnectionProfiles.ToString();
            }
        }

        public void OnDisappearing()
        {
            Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        }
    }
}
