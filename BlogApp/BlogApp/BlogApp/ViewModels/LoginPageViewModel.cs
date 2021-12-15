using BlogApp.Helpers;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BlogApp.ViewModels
{
    public class LoginPageViewModel : ConnectivityViewModel, IPageLifecycleAware
    {

        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;

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

        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }

        private DelegateCommand _onNavigationPageCommand;
        public DelegateCommand OnNavigationPageCommand =>
            _onNavigationPageCommand ?? (_onNavigationPageCommand = new DelegateCommand(async ()=> await ExcuteLogin()));

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }

        private async Task ExcuteLogin()
        {
            if (!IsInternet)
            {
                await _pageDialogService.DisplayAlertAsync("Thông báo", "Mất kết nối", "Đóng");
            }
            else if(String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Password))
            {
                await _pageDialogService.DisplayAlertAsync("Thông báo", "Vui lòng điền đầy đủ thông tin theo yêu cầu !", "Đóng");
            }
            else
            {
                if ((UserName.Equals("minhnhut") && Password.Equals("Nhut1234@")))
                {
                    var navigationParams = new NavigationParameters();
                    navigationParams.Add(ContainsKey.Usernamekey, UserName);
                    navigationParams.Add(ContainsKey.Passwordkey, Password);
                    var result = await _navigationService.NavigateAsync("/MainPage/NavigationPage/InfoPage", navigationParams);
                    if(!result.Success)
                    {
                        await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể chuyển trang", "Đóng");
                    }    
                    if (result.Success && IsChecked)
                    {
                       Preferences.Set(ContainsKey.RememberKey, IsChecked);
                       await SecureStorage.SetAsync(ContainsKey.Usernamekey, UserName);
                       await SecureStorage.SetAsync(ContainsKey.Passwordkey, Password);
                    }
                }
                else
                {
                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Tài khoản không tồn tại !", "Đóng");
                }
            }
        }
        public override async void OnAppearing()
        {
            base.OnAppearing();
            await HandleRememberAccount();
        }

        private async Task HandleRememberAccount() {
            if (Preferences.ContainsKey(ContainsKey.RememberKey))
            {
                var username = await SecureStorage.GetAsync(ContainsKey.Usernamekey);
                var password = await SecureStorage.GetAsync(ContainsKey.Passwordkey);

                if(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                {
                    return;
                }
                var navigationParams = new NavigationParameters();
                navigationParams.Add(ContainsKey.Usernamekey, username);
                navigationParams.Add(ContainsKey.Passwordkey, password);

                var result = await _navigationService.NavigateAsync("/MainPage/NavigationPage/InfoPage", navigationParams);
                if (!result.Success)
                {
                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể chuyển trang", "Đóng");
                }
            }
        }
    }
}
