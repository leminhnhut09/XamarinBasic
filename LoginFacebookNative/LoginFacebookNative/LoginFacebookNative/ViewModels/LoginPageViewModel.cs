using LoginFacebookNative.Models;
using LoginFacebookNative.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginFacebookNative.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;
        readonly IFacebookLoginService _facebookLoginService;

        private DelegateCommand<string> _onLoginFacebookSuccessCommand;
        public DelegateCommand<string> OnLoginFacebookSuccessCommand =>
            _onLoginFacebookSuccessCommand ?? (_onLoginFacebookSuccessCommand = new DelegateCommand<string>(async (authToken) => await ExcuteLoginSuccess(authToken)));

        private async Task ExcuteLoginSuccess(string authToken)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"https://graph.facebook.com/me?fields=first_name,last_name,email,picture&access_token={authToken}");
            var data = JsonConvert.DeserializeObject<FacebookProfile>(response);
        }

        private DelegateCommand<string> _onLoginFacebookErrorCommand;
        public DelegateCommand<string> OnLoginFacebookErrorCommand =>
            _onLoginFacebookErrorCommand ?? (_onLoginFacebookErrorCommand = new DelegateCommand<string>(async (err) => await ExcuteLoginError(err)));

        private async Task ExcuteLoginError(string err)
        {
            await _pageDialogService.DisplayAlertAsync("Notification", $"Authentication failed: {err}", "Close");
        }

        private DelegateCommand _onLoginFacebookCancel;
        public DelegateCommand OnLoginFacebookCancel =>
            _onLoginFacebookCancel ?? (_onLoginFacebookCancel = new DelegateCommand(async () => await ExcuteLoginCancel()));

        private async Task ExcuteLoginCancel()
        {
            await _pageDialogService.DisplayAlertAsync("Notification", "Cancel", "Close");
        }

        private DelegateCommand _onFacebookLogoutCommand;
        public DelegateCommand OnFacebookLogoutCommand =>
            _onFacebookLogoutCommand ?? (_onFacebookLogoutCommand = new DelegateCommand(ExcuteLogout, CanExcuteLogout));

        private bool CanExcuteLogout()
        {
            return !string.IsNullOrEmpty(_facebookLoginService.AccessToken);
        }

        private void ExcuteLogout()
        {
            _facebookLoginService.Logout();
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _facebookLoginService = DependencyService.Get<IFacebookLoginService>();
            //_facebookLoginService.AccessTokenChanged = (string oldToken, string newToken) => OnFacebookLogoutCommand.RaiseCanExecuteChanged();

            _facebookLoginService = (Application.Current as App).FacebookLoginService;
            //_facebookLoginService.AccessTokenChanged = (string oldToken, string newToken) => OnFacebookLogoutCommand.RaiseCanExecuteChanged();
        }

    }
}
