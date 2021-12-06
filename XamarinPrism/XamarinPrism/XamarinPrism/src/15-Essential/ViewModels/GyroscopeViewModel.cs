using Prism.AppModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class GyroscopeViewModel : BindableBase, IPageLifecycleAware
    {
        private string _x;
        public string X
        {
            get { return _x; }
            set { SetProperty(ref _x, value); }
        }

        private string _y;
        public string Y
        {
            get { return _y; }
            set { SetProperty(ref _y, value); }
        }
        private string _z;
        public string Z
        {
            get { return _z; }
            set { SetProperty(ref _z, value); }
        }
        public void OnAppearing()
        {
            Gyroscope.ReadingChanged += OnGyroscopeReadingChanged;
            Gyroscope.Start(SensorSpeed.Game);
        }

        private void OnGyroscopeReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var data = e.Reading;
                if (data != null)
                {
                    X = data.AngularVelocity.X.ToString();
                    Y = data.AngularVelocity.Y.ToString();
                    Z = data.AngularVelocity.Z.ToString();
                }
            });
        }

        public void OnDisappearing()
        {
            Gyroscope.Stop();
            Gyroscope.ReadingChanged -= OnGyroscopeReadingChanged;
        }
    }
}
