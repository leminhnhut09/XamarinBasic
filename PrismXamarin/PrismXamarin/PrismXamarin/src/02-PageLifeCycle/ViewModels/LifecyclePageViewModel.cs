using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismXamarin.src._02_PageLifeCycle.ViewModels
{
    public class LifecyclePageViewModel : ViewModelBase, IPageLifecycleAware
    {
        //protected INavigationService _navigationService;
        public DelegateCommand NavigateCommand { get; set; }
        public LifecyclePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            //_navigationService = navigationService;
            NavigateCommand = new DelegateCommand(async () => await navigationService.NavigateAsync("DetailLifecyclePage"));
        }

        public void OnAppearing()
        {
            Console.WriteLine("OnAppearing - LifecyclePage Xuất hiện");
        }

        public void OnDisappearing()
        {
            Console.WriteLine("OnDisappearing - LifecyclePage Biến mất");
        }
    }
}
