using BlogApp.Helpers;
using BlogApp.Models;
using BlogApp.Services;
using BlogApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BlogApp.ViewModels
{
    public class MainPageViewModel : BindableBase, IInitializeAsync
    {
        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;
        private ILoginFacebookService _loginFacebookService;

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

        private Account accountLogin;
        public Account AccountLogin
        {
            get { return accountLogin; }
            set { SetProperty(ref accountLogin, value); }
        }

        private DelegateCommand<string> _onNavigationCommand;
        public DelegateCommand<string> OnNavigationCommand =>
            _onNavigationCommand ?? (_onNavigationCommand = new DelegateCommand<string>(ExecuteNavigation));

        private DelegateCommand _onLogOutCommand;
        public DelegateCommand OnLogOutCommand =>
            _onLogOutCommand ?? (_onLogOutCommand = new DelegateCommand(async () => await ExcuteLogout()));
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ILoginFacebookService loginFacebookService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _loginFacebookService = loginFacebookService;
        }
        private async void ExecuteNavigation(string parameter)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add(ContainsKey.Usernamekey, UserName);
            navigationParams.Add(ContainsKey.Passwordkey, Password);

            var result = await _navigationService.NavigateAsync($"NavigationPage/{parameter}", navigationParams);
            if (!result.Success)
            {
                await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể chuyển trang", "Đóng");
            }
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if(parameters.ContainsKey(ContainsKey.Usernamekey))
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
        async Task ExcuteLogout()
        {
            bool isLogout = await _pageDialogService.DisplayAlertAsync("Thông báo", "Bạn có muốn thoát ?", "Đồng ý", "Từ chối");
            if (isLogout)
            {
                if (Preferences.ContainsKey(ContainsKey.RememberKey))
                {
                    Preferences.Clear();
                }
                _loginFacebookService.Logout();
                var result = await _navigationService.NavigateAsync($"/{nameof(LoginPage)}");
                if (!result.Success)
                {
                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể đăng xuất", "Đóng");
                }
            }
        }
    }
}
