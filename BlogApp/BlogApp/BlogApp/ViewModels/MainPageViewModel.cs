using BlogApp.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BlogApp.ViewModels
{
    public class MainPageViewModel
    {
        protected INavigationService _navigationService;
        protected IPageDialogService _pageDialogService;

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
            bool isLogout = await _pageDialogService.DisplayAlertAsync("Thông báo", "Bạn có muốn đăng xuất không?", "Đồng ý", "Từ chối");
            if (isLogout)
            {
                if (Preferences.ContainsKey("isRemember"))
                {
                    Preferences.Remove("isRemember");
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
            var result = await _navigationService.NavigateAsync($"NavigationPage/{parameter}");
            if (!result.Success)
            {
                await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể chuyển trang !", "Đóng");
            }
        }
    }
}
