using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class PhoneDailerViewModel : BindableBase
    {
        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }
        private DelegateCommand _onClickCommand;
        public DelegateCommand OnClickCommand =>
            _onClickCommand ?? (_onClickCommand = new DelegateCommand(ExecutePhoneDailer));

        void ExecutePhoneDailer()
        {
            try
            {
                PhoneDialer.Open(PhoneNumber);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}
