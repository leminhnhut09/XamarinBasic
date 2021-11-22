using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using XamarinBasic.Source.Tuan3.CommandDelegate.Mvvm.Commands;

namespace XamarinBasic.Source.Tuan3.CommandDelegate.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _email;
        private string _password;

        public string Email 
        { 
            get => _email;
            set
            {
                if(SetProperty(ref _email, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password 
        { 
            get => _password;
            set
            {
                if (SetProperty(ref _password, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        } 

        public DelegateCommand LoginCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(Login, CanLogin);
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private async void Login()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
            if(_email.Equals("admin") && _password.Equals("123456"))
            {
                Debug.WriteLine("login ok");
            }
            else
            {
                Debug.WriteLine("fail");
            }
        }
    }
}
