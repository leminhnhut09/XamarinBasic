using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrism.src._00_MainNavigation.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        protected INavigationService _navigationService;
        protected IPageDialogService _pageDialogService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        //protected IPageDialogService _pageDialogService;
        public DelegateCommand<string> NavigateCommand { get; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            Title = "Home Page";
            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
        }

        private void OnNavigateCommandExecuted(string link)
        {
            _navigationService.NavigateAsync(link);
        }
    }
}
