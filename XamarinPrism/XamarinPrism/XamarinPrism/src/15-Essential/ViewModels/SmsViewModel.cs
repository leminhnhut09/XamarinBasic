using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class SmsViewModel : BindableBase
    {
        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        private string _textSms;
        public string TextSms
        {
            get { return _textSms; }
            set { SetProperty(ref _textSms, value); }
        }
        public DelegateCommand OnSmsCommand { get; set; }

        public SmsViewModel()
        {
            OnSmsCommand = new DelegateCommand(async () => await HandleSms());
        }

        private async Task HandleSms()
        {
            try
            {
                await Sms.ComposeAsync(new SmsMessage
                {
                    Body = TextSms,
                    Recipients = new List<string> { PhoneNumber }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
