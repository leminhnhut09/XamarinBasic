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

        private DelegateCommand _onPopNavigationCommand;
        public DelegateCommand OnPopNavigationCommand =>
            _onPopNavigationCommand ?? (_onPopNavigationCommand = new DelegateCommand(async ()=> await ExecuteOnPopNavigation()));

        private async Task ExecuteOnPopNavigation()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("username", UserName);
            navigationParams.Add("password", Password);
            var result = await _navigationService.GoBackAsync(navigationParams, true, true);
            if (!result.Success)
            {
                await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể quay lại !", "Đóng");
            }
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("username"))
            {
                UserName = parameters.GetValue<string>("username");
            }
            if (parameters.ContainsKey("password"))
            {
                Password = parameters.GetValue<string>("password");
            }
        }

        public InfomationPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
