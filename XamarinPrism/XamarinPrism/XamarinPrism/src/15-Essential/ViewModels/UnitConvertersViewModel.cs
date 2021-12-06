using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class UnitConvertersViewModel : BindableBase
    {
        private double _fahrenheit;
        public double Fahrenheit
        {
            get { return _fahrenheit; }
            set { SetProperty(ref _fahrenheit, value); }
        }

        private double _celsius;
        public double Celsius
        {
            get { return _celsius; }
            set { SetProperty(ref _celsius, value); }
        }

        private double _mile;
        public double Mile
        {
            get { return _mile; }
            set { SetProperty(ref _mile, value); }
        }

        private DelegateCommand _onConvertFtoCCommand;
        public DelegateCommand OnConvertFtoCCommand =>
            _onConvertFtoCCommand ?? (_onConvertFtoCCommand = new DelegateCommand(HandleConvertFtoC));

        void HandleConvertFtoC()
        {
            Celsius = UnitConverters.FahrenheitToCelsius(Fahrenheit);
            Mile = UnitConverters.KilometersToMiles(Fahrenheit);
        }
    }
}
