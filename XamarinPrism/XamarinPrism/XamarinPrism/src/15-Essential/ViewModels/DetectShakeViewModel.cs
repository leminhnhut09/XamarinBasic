using Prism.AppModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class DetectShakeViewModel : BindableBase, IPageLifecycleAware
    {
        private int _count = 0;
        public int Count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }
        public void OnAppearing()
        {
            Accelerometer.ShakeDetected += OnAccelerometerShakeDetected;
            Accelerometer.Start(SensorSpeed.Fastest);
        }

        private void OnAccelerometerShakeDetected(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Count++;
            });
        }

        public void OnDisappearing()
        {
            Accelerometer.Stop();
            Accelerometer.ShakeDetected -= OnAccelerometerShakeDetected;
        }
    }
}
