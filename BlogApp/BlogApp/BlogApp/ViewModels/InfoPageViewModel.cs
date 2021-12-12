using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.ViewModels
{
    public class InfoPageViewModel : BindableBase
    {
        protected INavigationService _navigationService;
        private string _avatar = "image.png";
        public string Avatar
        {
            get { return _avatar; }
            set { SetProperty(ref _avatar, value); }
        }
        private string _userName = "Lê Minh Nhựt";
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
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
            //await _navigationService.NavigateAsync("InfomationPage");
            await _navigationService.NavigateAsync("InfomationPage", null, true, true);
        }
    }
}
