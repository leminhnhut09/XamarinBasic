using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinPrism.src._14_Aggregator.Services;

namespace XamarinPrism.src._14_Aggregator.ViewModels
{
    public class RecievePageViewModel : BindableBase
    {
        protected IEventAggregator _ea;

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public DelegateCommand OnSendEventCommand { get; set; }
        public RecievePageViewModel(IEventAggregator ea)
        {
            _ea = ea;
            OnSendEventCommand = new DelegateCommand(HandleSendEvent);
            //_ea.GetEvent<MessageSentEvent>().Subscribe(HandleMessage, ThreadOption.UIThread);
        }

        private void HandleSendEvent()
        {
            _ea.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
