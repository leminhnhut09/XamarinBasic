using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class VibrateViewModel
    {
        private DelegateCommand _onVibrateCommand;
        public DelegateCommand OnVibrateCommand =>
            _onVibrateCommand ?? (_onVibrateCommand = new DelegateCommand(HandleVibrate));
        private DelegateCommand _onCancelVibrateCommand;
        public DelegateCommand OnCancelVibrateCommand =>
            _onCancelVibrateCommand ?? (_onCancelVibrateCommand = new DelegateCommand(HandleCancelVibrate));

        void HandleCancelVibrate()
        {
            Vibration.Cancel();
        }
        void HandleVibrate()
        {
            Vibration.Vibrate(TimeSpan.FromMilliseconds(3000));
        }
    }
}
