using BlogApp.Helpers;
using BlogApp.Models;
using BlogApp.Services;
using Newtonsoft.Json;
using Plugin.FacebookClient;
using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BlogApp.ViewModels
{
    public class LoginPageViewModel : ConnectivityViewModel, IPageLifecycleAware
    {
        readonly string[] fbRequestFields = { "email", "first_name", "picture", "gender", "last_name" };
        readonly string[] fbPermisions = { "email", "public_profile"};

        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;
        private ILoginFacebookService _loginFacebookService;
        IFacebookClient _facebookService = CrossFacebookClient.Current;

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

        //private DelegateCommand _onLoginFacebookCommand;
        //public DelegateCommand OnLoginFacebookCommand =>
        //    _onLoginFacebookCommand ?? (_onLoginFacebookCommand = new DelegateCommand(async () => await ExcuteLoginFaceBook()));


        //private async Task ExcuteLoginFaceBook()
        //{
        //    try
        //    {
        //        if (_facebookService.IsLoggedIn)
        //        {
        //            _facebookService.Logout();
        //        }
        //        EventHandler<FBEventArgs<string>> userDataDelegate = null;

        //        userDataDelegate = async (object sender, FBEventArgs<string> e) =>
        //        {
        //            if (e == null) return;

        //            switch (e.Status)
        //            {
        //                case FacebookActionStatus.Completed:
        //                    var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(e.Data);
        //                    var account = new Account
        //                    {
        //                        Email = facebookProfile.Email,
        //                        Picture = facebookProfile.Picture.Data.Url
        //                    };
        //                    var navigationParams = new NavigationParameters();
        //                    navigationParams.Add(ContainsKey.AccountKey, account);
        //                    var result = await _navigationService.NavigateAsync("/MainPage/NavigationPage/InfoPage", navigationParams);
        //                    if (!result.Success)
        //                    {
        //                        await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể chuyển trang", "Đóng");
        //                    }
        //                    break;
        //                case FacebookActionStatus.Canceled:
        //                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Đã hủy đăng nhập facebook", "Đóng");
        //                    break;
        //                case FacebookActionStatus.Error:
        //                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Lỗi đăng nhập", "Đóng");
        //                    break;
        //                case FacebookActionStatus.Unauthorized:
        //                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Lỗi", "Đóng");
        //                    break;
        //                default:
        //                    break;
        //            }
        //            _facebookService.OnUserData -= userDataDelegate;
        //        };

        //        _facebookService.OnUserData += userDataDelegate;
        //        await _facebookService.RequestUserDataAsync(fbRequestFields, fbPermisions);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.ToString());
        //    }
        //}


        private DelegateCommand _onLoginFacebookCommand;
        public DelegateCommand OnLoginFacebookCommand =>
            _onLoginFacebookCommand ?? (_onLoginFacebookCommand = new DelegateCommand(async () => await ExcuteLoginFaceBook()));
        private async Task ExcuteLoginFaceBook()
        {
            await _loginFacebookService.Login(OnLoginComplete);
        }
        private void FacebookLogin()
        {
            _loginFacebookService.Login(OnLoginComplete);
        }
        private async void OnLoginComplete(Account account, string message)
        {
            if (account != null)
            {
                
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Error", message, "Ok");
            }
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ILoginFacebookService loginFacebookService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _loginFacebookService = loginFacebookService;
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
