using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinPrism.src._13_MessageCenter.ViewModels
{
    public class MessageAPageViewModel : BindableBase
    {
        protected INavigationService _navigationService;
        public ObservableCollection<string> Collection { get; set; } = new ObservableCollection<string>();
       

        private DelegateCommand _onSubscribeCommand;
        public DelegateCommand OnSubscribeCommand =>
            _onSubscribeCommand ?? (_onSubscribeCommand = new DelegateCommand(HandleSubscribe));

        private void HandleSubscribe()
        {
            MessagingCenter.Subscribe<MessageBPageViewModel, DateTime>(this, "mess", (sender, arg)=> {
                Collection.Add(arg.ToString());
            });
        }


        private DelegateCommand _onUnsubscribeCommand;
        public DelegateCommand OnUnsubscribeCommand =>
            _onUnsubscribeCommand ?? (_onUnsubscribeCommand = new DelegateCommand(HandleUnsubscribe));

        private void HandleUnsubscribe()
        {
            MessagingCenter.Unsubscribe<MessageBPageViewModel, DateTime>(this, "mess");
        }
        public DelegateCommand OnNavigationCommand { get; set; }
        public MessageAPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            OnNavigationCommand = new DelegateCommand(async () => await HandleNavigation());
        }

        private async Task HandleNavigation()
        {
            await _navigationService.NavigateAsync("MessageBPage");
        }
    }
}
