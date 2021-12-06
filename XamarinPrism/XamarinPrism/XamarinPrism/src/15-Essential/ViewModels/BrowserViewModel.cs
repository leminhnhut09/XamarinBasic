using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class BrowserViewModel
    {
        private DelegateCommand _onOpenBrowserCommand;
        public DelegateCommand OnOpenBrowserCommand =>
            _onOpenBrowserCommand ?? (_onOpenBrowserCommand = new DelegateCommand(HanleOpenBrowser));

        async void HanleOpenBrowser()
        {
            await Browser.OpenAsync("http://xamarin.com", BrowserLaunchMode.External);
        }

        private DelegateCommand _onOpenBrowserOutCommand;
        public DelegateCommand OnOpenBrowserOutCommand =>
            _onOpenBrowserOutCommand ?? (_onOpenBrowserOutCommand = new DelegateCommand(HandleOpenBrowserOut));

        async void HandleOpenBrowserOut()
        {
            await Browser.OpenAsync("http://xamarin.com", BrowserLaunchMode.SystemPreferred);
        }
    }
}
