using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamarinPrism.src._14_Aggregator.Services;

namespace XamarinPrism.src._14_Aggregator.ViewModels
{
    public class AggregatorPageViewModel : BindableBase
    {
        protected IEventAggregator _ea;
        protected INavigationService _navigationService;
        private SubscriptionToken _token;
        public ObservableCollection<string> Collection { get; set; } = new ObservableCollection<string>();

        public DelegateCommand OnSubscribeCommand { get; set; }

        public DelegateCommand OnUnsubscribeCommand { get; set; }

        public DelegateCommand OnNavigationCommand { get; set; }

        public AggregatorPageViewModel(INavigationService navigationService, IEventAggregator ea)
        {
            _navigationService = navigationService;
            _ea = ea;
            OnNavigationCommand = new DelegateCommand(async () => await HandleNavigation());
            OnSubscribeCommand = new DelegateCommand(HandleSubscribe);
            OnUnsubscribeCommand = new DelegateCommand(HandleUnsubscribe);
        }

        private void HandleUnsubscribe()
        {
            _ea.GetEvent<MessageSentEvent>().Unsubscribe(_token);
        }

        private async Task HandleNavigation()
        {
            await _navigationService.NavigateAsync("RecievePage");
        }

        private void HandleSubscribe()
        {
            //message => message.EndsWith("Nhut")
            _token = _ea.GetEvent<MessageSentEvent>().Subscribe(HandleMessage, ThreadOption.PublisherThread, true, HandleFilter);
        }

        private bool HandleFilter(string obj)
        {
            return obj.EndsWith("Message");
        }

        private void HandleMessage(string obj)
        {
            Collection.Add(obj);
        }
    }
}
