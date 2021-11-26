using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using PrismXamarin.src._09_TabbedPage.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PrismXamarin.src._09_TabbedPage.ViewModels
{
    public class PrismTabbedPage1ViewModel : BindableBase
    {
        protected INavigationService _navigationService;

        public PrismTabbedPage1ViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}
