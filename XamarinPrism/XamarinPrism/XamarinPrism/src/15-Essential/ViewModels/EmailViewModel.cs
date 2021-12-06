using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class EmailViewModel : BindableBase
    {
        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { SetProperty(ref _subject, value); }
        }

        private string _to;
        public string To
        {
            get { return _to; }
            set { SetProperty(ref _to, value); }
        }

        private string _cc;
        public string Cc
        {
            get { return _cc; }
            set { SetProperty(ref _cc, value); }
        }
        private string _bbc;
        public string Bbc
        {
            get { return _bbc; }
            set { SetProperty(ref _bbc, value); }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand OnSendEmailCommand { get; set; }

        public EmailViewModel()
        {
            OnSendEmailCommand = new DelegateCommand(ExecuteSendEmail);
        }

        async void ExecuteSendEmail()
        {
            try
            {
                // Title, Body, To [CC...]
                var message1 = new EmailMessage(Subject, Message, To);
                var message2 = new EmailMessage()
                {
                    Subject = Subject,
                    Body = Message,
                    // danh sách người nhận
                    To = new List<string>() { To, },
                    Cc = new List<string>() { Cc},
                    Bcc = new List<string>() { Bbc }
                };

                //await Email.ComposeAsync(Subject, Message, To);
                await Email.ComposeAsync(message2);

            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
    }
}
