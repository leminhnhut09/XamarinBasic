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


        private int _opacity;
        public int Opacity
        {
            get { return _opacity; }
            set { SetProperty(ref _opacity, value); }
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
                Opacity = 0;
                IsInternet = true;
            }
            else
            {
                Opacity = 1;
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
                Opacity = 0;
                IsInternet = true;
            }
            else
            {
                Opacity = 1;
                IsInternet = false;
            }
        }
        public void OnDisappearing()
        {
            Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        }
    }
}
