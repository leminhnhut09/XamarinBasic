using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using XamarinPrism.src._04_NavigationService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrism.src._04_NavigationService.ViewModels
{
    public class TheSecondPageViewModel : BindableBase, INavigationAware
    {
        protected INavigationService _navigationService;

        private Character _character;
        public Character Character
        {
            get { return _character; }
            set { SetProperty(ref _character, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand OnBackCommand { get; set; }
        public TheSecondPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Second Page";
            //OnBackCommand = new DelegateCommand(async () => await _navigationService.GoBackAsync());
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Character = parameters.GetValue<Character>("character");
            Title = parameters.GetValue<string>("title");
            Console.WriteLine("Nhan");
        }
    }
}
