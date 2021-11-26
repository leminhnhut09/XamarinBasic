using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismXamarin.src._07_DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismXamarin.src._07_DependencyInjection.ViewModels
{
    public class MainServicePageViewModel : BindableBase
    {
        protected INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateToSingletonPageCommand { get; set; }

        public MainServicePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToSingletonPageCommand = new DelegateCommand(NavigateToSingletonPage);
        }

        private async void NavigateToSingletonPage()
        {
            await _navigationService.NavigateAsync("SingletonServicePage");
        }
    }
}
