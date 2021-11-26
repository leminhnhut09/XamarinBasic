using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismXamarin.src._08_MasterDetailPage.ViewModels
{
    public class PrismMasterDetailPageViewModel : BindableBase
    {
        private INavigationService _navigationService { get; }

        public PrismMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(NavigateCommandExecuted);
        }

        public DelegateCommand<string> NavigateCommand { get; }

        private async void NavigateCommandExecuted(string view)
        {
            var result = await _navigationService.NavigateAsync($"NavigationPage/{view}");
            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
    }
}
