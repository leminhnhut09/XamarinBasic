using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

using XamarinPrism.src._15_Essential.Services;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class ColorConvertersViewModel : INotifyPropertyChanged
    {
        int alpha = 100;
        int saturation = 100;
        int hue = 360;
        int luminosity = 100;
        string hex = "#3498db";

        public ColorConvertersViewModel()
        {
        }

        public int Alpha
        {
            get => alpha;
            set
            {
                SetProperty(ref alpha, value);
                SetColor();
            }
        }

        public int Saturation
        {
            get => saturation;
            set
            {
                SetProperty(ref saturation, value);
                SetColor();
            }
        }

        public int Hue
        {
            get => hue;
            set
            {
                SetProperty(ref hue, value);
                SetColor();
            }
        }

        public int Luminosity
        {
            get => luminosity;
            set
            {
                SetProperty(ref luminosity, value);
                SetColor();
            }
        }

        public string Hex
        {
            get => hex;
            set
            {
                SetProperty(ref hex, value);
                SetColor();
            }
        }

        public Color RegularColor { get; set; }
        public Color AlphaColor { get; set; }
        public Color SaturationColor { get; set; }
        public Color HueColor { get; set; }
        public Color LuminosityColor { get; set; }
        public Color ComplementColor { get; set; }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private DelegateCommand _onLoginCommand;
        public DelegateCommand OnLoginCommand =>
            _onLoginCommand ?? (_onLoginCommand = new DelegateCommand(HandleLogin));

        void HandleLogin()
        {
            var service = Xamarin.Forms.DependencyService.Get<IStatusBar>();
            bool isValid = !String.IsNullOrEmpty(Text);
            service?.SetStatusBar(isValid ? Color.Green : Color.Red);
        }


        private void SetColor()
        {
            try
            {
                var color = ColorConverters.FromHex(Hex);

                RegularColor = color;
                AlphaColor = color.WithAlpha(Alpha);
                SaturationColor = color.WithSaturation(Saturation);
                HueColor = color.WithHue(Hue);
                LuminosityColor = color.WithLuminosity(Luminosity);
                ComplementColor = color.GetComplementary();
                OnPropertyChanged(nameof(RegularColor));
                OnPropertyChanged(nameof(AlphaColor));
                OnPropertyChanged(nameof(SaturationColor));
                OnPropertyChanged(nameof(HueColor));
                OnPropertyChanged(nameof(LuminosityColor));
                OnPropertyChanged(nameof(ComplementColor));

            }
            catch (Exception)
            {

            }
        }
        protected virtual bool SetProperty<T>(ref T backingStore,
                                              T value,
                                              [CallerMemberName] string propertyName = null,
                                              Action onChanged = null,
                                              Func<T, T, bool> validateValue = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            if (validateValue != null && !validateValue(backingStore, value))
            {
                return false;
            }

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
