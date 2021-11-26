using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismXamarin.src._01_AppLifeCycle.ViewModels
{
    public class ViewAPageViewModel : ViewModelBase, IApplicationLifecycleAware
    {
        protected INavigationService _navigationService;
        public DelegateCommand OnBackCommand { get; private set; }
        public ViewAPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "View A";
            OnBackCommand = new DelegateCommand(async () => await _navigationService.GoBackAsync());
        }

        public void OnResume()
        {
            //Console.WriteLine("View A - OnResume");
        }

        public void OnSleep()
        {
            //Console.WriteLine("View A - OnSleep");
        }
    }
}
