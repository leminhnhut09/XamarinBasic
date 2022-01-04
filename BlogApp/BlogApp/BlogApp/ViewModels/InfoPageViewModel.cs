using BlogApp.Helpers;
using BlogApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.ViewModels
{
    public class InfoPageViewModel : BindableBase, IInitializeAsync
    {
        private string _avatar = "image.png";
        public string Avatar
        {
            get { return _avatar; }
            set { SetProperty(ref _avatar, value); }
        }
        private string _userName = "";
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
        private string _password = "";
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _fullName = "Lê Minh Nhựt";
        public string FullName
        {
            get { return _fullName; }
            set { SetProperty(ref _fullName, value); }
        }

        private Account accountLogin;
        public Account AccountLogin
        {
            get { return accountLogin; }
            set { SetProperty(ref accountLogin, value); }
        }
        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(ContainsKey.Usernamekey))
            {
                UserName = parameters.GetValue<string>(ContainsKey.Usernamekey);
            }
            if (parameters.ContainsKey(ContainsKey.Passwordkey))
            {
                Password = parameters.GetValue<string>(ContainsKey.Passwordkey);
            }
            if (parameters.ContainsKey(ContainsKey.AccountKey))
            {
                AccountLogin = parameters.GetValue<Account>(ContainsKey.AccountKey);
            }
        }
    }
}
