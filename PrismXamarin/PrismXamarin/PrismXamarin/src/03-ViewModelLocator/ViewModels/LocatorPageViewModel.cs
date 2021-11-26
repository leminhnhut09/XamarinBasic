using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
//ViewPageModels
namespace PrismXamarin.src._03_ViewModelLocator.ViewModels
{
    public class LocatorPageViewModel : ViewModelBase
    {
        public DelegateCommand NavigativeCommand { get; set; }
        public LocatorPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "View model locator";
            NavigativeCommand = new DelegateCommand(() => Console.WriteLine("Click"));
        }
    }
}
