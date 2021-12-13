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
        protected INavigationService _navigationService;
        protected IPageDialogService _pageDialogService;
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

        public DelegateCommand OnNavigationPageCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            OnNavigationPageCommand = new DelegateCommand(async ()=> await ExcuteLogin());
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
                    navigationParams.Add("username", UserName);
                    navigationParams.Add("password", Password);
                    var result = await _navigationService.NavigateAsync("/MainPage/NavigationPage/InfoPage", navigationParams);
                    //await _pageDialogService.DisplayAlertAsync("Thông báo", "Đăng nhập thành công", "Đóng");
                    if(!result.Success)
                    {
                        await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể chuyển trang", "Đóng");
                    }    
                    if (result.Success && IsChecked)
                    {
                       Preferences.Set("isRemember", IsChecked);
                       await SecureStorage.SetAsync("username", UserName);
                       await SecureStorage.SetAsync("password", Password);
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
            if (Preferences.ContainsKey("isRemember"))
            {
                var username = await SecureStorage.GetAsync("username");
                var pass = await SecureStorage.GetAsync("password");

                var navigationParams = new NavigationParameters();
                navigationParams.Add("username", username);
                navigationParams.Add("password", pass);

                var result = await _navigationService.NavigateAsync("/MainPage/NavigationPage/InfoPage", navigationParams);
                if (!result.Success)
                {
                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể chuyển trang", "Đóng");
                }
            }
        }
    }
}
