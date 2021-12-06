using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class MainThreadViewModel : BindableBase
    {
        private string _count;
        public string Count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }

        private bool _isEnable = true;
        public bool IsEnable
        {
            get { return _isEnable; }
            set { SetProperty(ref _isEnable, value); }
        }

        public DelegateCommand OnClickCommand { get; set; }
        public MainThreadViewModel()
        {
            OnClickCommand = new DelegateCommand(async() => await HandleClick());
        }

        private async Task HandleClick()
        {
            IsEnable = false;
            // Luồng khác
            await Task.Run(async () =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        Count += 1;
                    });
                    await Task.Delay(1000);
                }
            });
            IsEnable = true;
        }
    }
}
