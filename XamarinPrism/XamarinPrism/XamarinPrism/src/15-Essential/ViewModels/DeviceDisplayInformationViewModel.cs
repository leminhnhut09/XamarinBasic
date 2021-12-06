using Prism.AppModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class DeviceDisplayInformationViewModel : BindableBase, IPageLifecycleAware
    {
        private string _orientation;
        public string Orientation
        {
            get { return _orientation; }
            set { SetProperty(ref _orientation, value); }
        }
        private int _rotation;
        public int Rotation
        {
            get { return _rotation; }
            set { SetProperty(ref _rotation, value); }
        }

        private int _width;
        public int Width
        {
            get { return _width; }
            set { SetProperty(ref _width, value); }
        }

        private int _height;
        public int Height
        {
            get { return _height; }
            set { SetProperty(ref _height, value); }
        }
        private int _density;
        public int Density
        {
            get { return _density; }
            set { SetProperty(ref _density, value); }
        }
        public void OnAppearing()
        {
            Orientation = DeviceDisplay.MainDisplayInfo.Orientation.ToString();
            Rotation = (int)DeviceDisplay.MainDisplayInfo.Rotation;
            Width = (int)DeviceDisplay.MainDisplayInfo.Width;
            Height = (int)DeviceDisplay.MainDisplayInfo.Height;
            Density = (int)DeviceDisplay.MainDisplayInfo.Density;
            DeviceDisplay.MainDisplayInfoChanged += OnDeviceDisplayMainDisplayInfoChanged;
        }

        private void OnDeviceDisplayMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            var result = e.DisplayInfo;
            Orientation = result.Orientation.ToString();
            Rotation = (int)result.Rotation;
            Width = (int)result.Width;
            Height = (int)result.Height;
            Density = (int)result.Density;
        }

        public void OnDisappearing()
        {
            DeviceDisplay.MainDisplayInfoChanged -= OnDeviceDisplayMainDisplayInfoChanged;
        }
    }
}
