using Prism.AppModel;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismXamarin.src._02_PageLifeCycle.ViewModels
{
    public class DetailLifeCyclePageViewModel : ViewModelBase, IPageLifecycleAware
    {
        public DetailLifeCyclePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public void OnAppearing()
        {
            Console.WriteLine("OnAppearing - DetailLifeCyclePage Xuất hiện");
        }

        public void OnDisappearing()
        {
            Console.WriteLine("OnDisappearing - DetailLifeCyclePage Biến mất");
        }
    }
}
