using BlogApp.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.ViewModels
{
    public class InfomationPageViewModel : BindableBase, IInitializeAsync
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

        private string _fullName = "Lê Minh Nhựt";
        public string FullName
        {
            get { return _fullName; }
            set { SetProperty(ref _fullName, value); }
        }

        private DelegateCommand _onPopNavigationCommand;
        public DelegateCommand OnPopNavigationCommand =>
            _onPopNavigationCommand ?? (_onPopNavigationCommand = new DelegateCommand(async ()=> await ExecuteOnPopNavigation()));

        public InfomationPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }

        private async Task ExecuteOnPopNavigation()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add(ContainsKey.Usernamekey, UserName);
            navigationParams.Add(ContainsKey.Passwordkey, Password);
            var result = await _navigationService.NavigateAsync("/MainPage/NavigationPage/InfoPage", navigationParams);
            if (!result.Success)
            {
                await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể quay lại !", "Đóng");
            }
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
        }
    }
}
