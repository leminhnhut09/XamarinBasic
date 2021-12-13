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
        protected INavigationService _navigationService;
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

        private DelegateCommand _onNavigationCommand;
        public DelegateCommand OnNavigationCommand =>
            _onNavigationCommand ?? (_onNavigationCommand = new DelegateCommand(ExecuteNavigation));
        public InfoPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        async void ExecuteNavigation()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("username", UserName);
            navigationParams.Add("password", Password);
            //await _navigationService.NavigateAsync("InfomationPage");
            await _navigationService.NavigateAsync("InfomationPage", navigationParams, true, true);
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
    }
}
