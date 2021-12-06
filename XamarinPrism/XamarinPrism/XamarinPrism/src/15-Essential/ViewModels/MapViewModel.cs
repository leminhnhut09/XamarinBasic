using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class MapViewModel : BindableBase
    {
        private float _latitude = 47.673988f;
        public float Latitude
        {
            get { return _latitude; }
            set { SetProperty(ref _latitude, value); }
        }

        private float _longtitude = -122.121513f;
        public float Longtitude
        {
            get { return _longtitude; }
            set { SetProperty(ref _longtitude, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private DelegateCommand _onMapCommand;
        public DelegateCommand OnMapCommand =>
            _onMapCommand ?? (_onMapCommand = new DelegateCommand(HandleMap));

        async void HandleMap()
        {
            await Map.OpenAsync(Latitude, Longtitude, new MapLaunchOptions
            {
                Name = Name,
                NavigationMode = NavigationMode.Driving
            });
        }

    }
}
