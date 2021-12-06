using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class BatterryViewModel : BindableBase
    {
        private Color _backgroundColor;
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { SetProperty(ref _backgroundColor, value); }
        }

        private double _chargeLevel;
        public double ChargeLevel
        {
            get { return _chargeLevel; }
            set { SetProperty(ref _chargeLevel, value); }
        }

        private string _state;
        public string State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        private string _sourceCharge;
        public string SourceCharge
        {
            get { return _sourceCharge; }
            set { SetProperty(ref _sourceCharge, value); }
        }

        public BatterryViewModel()
        {
            SetBackGround(Battery.ChargeLevel, Battery.State == BatteryState.Charging);
            GetBattery();
            Battery.BatteryInfoChanged += OnBatteryInfoChanged;
        }

        private void GetBattery()
        {
            ChargeLevel = Battery.ChargeLevel;
            State = Battery.State.ToString();
            SourceCharge = Battery.PowerSource.ToString();
        }

        private void OnBatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            SetBackGround(e.ChargeLevel, e.State == BatteryState.Charging);
            GetBattery();
        }

        void SetBackGround(double level, bool charging)
        {
            Color? color = null;
            var status = charging ? "Charging" : "Not Charging";
            if(level > .5f)
            {
                color = Color.Green.MultiplyAlpha((float)level);
            }
            else if(level > .2f)
            {
                color = Color.Yellow.MultiplyAlpha((float)(1d - level));
            }
            else
            {
                color = Color.Red.MultiplyAlpha((float)(1d - level));
            }
            BackgroundColor = color.Value;
        }
    }
}
