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

namespace BlogApp.ViewModels
{
    public class MainPageViewModel : BindableBase, IInitializeAsync
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

        private DelegateCommand<string> _onNavigationCommand;
        public DelegateCommand<string> OnNavigationCommand =>
            _onNavigationCommand ?? (_onNavigationCommand = new DelegateCommand<string>(ExecuteNavigation));
        public DelegateCommand OnLogOutCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            OnLogOutCommand = new DelegateCommand(async ()=> await ExcuteLogout());
        }

        private async Task ExcuteLogout()
        {
            bool isLogout = await _pageDialogService.DisplayAlertAsync("Thông báo", "Bạn có muốn thoát ?", "Đồng ý", "Từ chối");
            if (isLogout)
            {
                if (Preferences.ContainsKey("isRemember"))
                {
                    Preferences.Clear();
                }
                var result = await _navigationService.NavigateAsync($"/{nameof(LoginPage)}");
                if (!result.Success)
                {
                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể đăng xuất", "Đóng");
                }
            }
        }

        private async void ExecuteNavigation(string parameter)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("username", UserName);
            navigationParams.Add("password", Password);

            var result = await _navigationService.NavigateAsync($"NavigationPage/{parameter}", navigationParams);
            if (!result.Success)
            {
                await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể chuyển trang", "Đóng");
            }
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if(parameters.ContainsKey("username"))
            {
                UserName = parameters.GetValue<string>("username");
            }
            if (parameters.ContainsKey("password"))
            {
                Password = parameters.GetValue<string>("password");
            }
        }
    }
}
