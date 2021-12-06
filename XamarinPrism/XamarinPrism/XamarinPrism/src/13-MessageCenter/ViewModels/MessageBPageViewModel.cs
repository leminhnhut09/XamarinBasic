using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace XamarinPrism.src._13_MessageCenter.ViewModels
{
    public class MessageBPageViewModel : BindableBase
    {
        private DelegateCommand _onSendMessageCommand;
        public DelegateCommand OnSendMessageCommand =>
            _onSendMessageCommand ?? (_onSendMessageCommand = new DelegateCommand(HandleSendMessage));

        void HandleSendMessage()
        {
            MessagingCenter.Send<MessageBPageViewModel, DateTime>(this, "mess", DateTime.Now.Date);
        }
    }

}
