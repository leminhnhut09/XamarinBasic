using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrismXamarin.src._01_AppLifeCycle.ViewModels
{
    public class AppLifeCycleMainPageViewModel : ViewModelBase, IApplicationLifecycleAware
    {
        protected INavigationService _navigationService;
        public DelegateCommand OnGoToViewACommand { get; set; }
        public AppLifeCycleMainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Main Page";
            OnGoToViewACommand = new DelegateCommand(GoToViewA);
        }

        private void GoToViewA()
        {
            _navigationService.NavigateAsync("ViewAPage");
        }
        public void OnResume()
        {
            Console.WriteLine("MainPage - OnResume");
        }

        public void OnSleep()
        {
            Console.WriteLine("MainPage - OnSleep");
        }
    }
}
