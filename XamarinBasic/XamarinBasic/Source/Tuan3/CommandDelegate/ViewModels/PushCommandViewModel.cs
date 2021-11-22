using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinBasic.Source.Tuan3.CommandDelegate.Views;

namespace XamarinBasic.Source.Tuan3.CommandDelegate.ViewModels
{
    public class PushCommandViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand Command { get; set; }

        public ICommand NavigationCommand { get; set; }

        public INavigation Navigation { get; set; }

        public string Text => $"Count: {count}";

        int count = 0;

        public PushCommandViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Command = new Command<string>(HandleClick);
            NavigationCommand = new Command<string>(HandelLoginPage);
        }

        private void HandelLoginPage(string mess)
        {
            Navigation.PushModalAsync(new DetailCommand(mess));
        }

        private void HandleClick(string i)
        {
            if (int.TryParse(i, out int num))
            {
                count += num;
                OnPropertyChanged(nameof(Text));
            }
        }
    }
}
