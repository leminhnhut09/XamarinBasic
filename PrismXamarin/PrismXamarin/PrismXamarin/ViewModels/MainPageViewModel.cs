using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismXamarin.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        protected INavigationService _navigationService;
        protected IPageDialogService _pageDialogService;

        //protected IPageDialogService _pageDialogService;
        public DelegateCommand<string> NavigateCommand { get; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            Title = "Home Page";
            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
        }

        private void OnNavigateCommandExecuted(string link)
        {
            //Console.WriteLine(link);
            var result =_navigationService.NavigateAsync(link);
            //if (!result.Result.Success)
            //{
            //    _pageDialogService.DisplayAlertAsync("Notifycation", "Page not exist", "Close");
            //}
        }
    }
}
