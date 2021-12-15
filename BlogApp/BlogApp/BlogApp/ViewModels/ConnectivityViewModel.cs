using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace BlogApp.ViewModels
{
    public class ConnectivityViewModel : BindableBase, IPageLifecycleAware
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
        public ConnectivityViewModel()
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

        public virtual void OnAppearing()
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
        public void OnDisappearing()
        {
            Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        }
    }
}
