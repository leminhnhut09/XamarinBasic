using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinBasic.Source.Tuan3.GesturesRegconizer
{
    public class TabbedGesture : INotifyPropertyChanged
    {
        int taps = 0;
        public string ImageSource { get; set; } = "check.png";
        public ICommand TapGestureRecognizer { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TabbedGesture()
        {
            TapGestureRecognizer = new Command(HandleAction);
        }
        void HandleAction(object obj)
        {
            taps++;
            if(taps % 2 == 0)
            {
                if (ImageSource == "check.png")
                {
                    ImageSource = "image.png";
                }
                else
                {
                    ImageSource = "check.png";
                }
                OnPropertyChanged(nameof(ImageSource));
            }
        }
    }
}
