using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using XamarinPrism.src._04_NavigationService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinPrism.src._04_NavigationService.ViewModels
{
    public class TheFirstPageViewModel : BindableBase, INavigationAware, IConfirmNavigationAsync
    {
        protected INavigationService _navigationService;

        protected IPageDialogService _pageDialogService;

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
        public DelegateCommand<Character> OnSendChacterCommand { get; set; }

        public DelegateCommand OnChangedNameCommand { get; set; }
        public TheFirstPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            OnSendChacterCommand = new DelegateCommand<Character>(OnSendTheSecondPage);
        }


        private void OnSendTheSecondPage(Character character)
        {
            if (character != null)
            {
                //var navigationParams = new NavigationParameters
                //{
                //    {"character", "aa" }
                //};
                var navigationParams = new NavigationParameters();
                //navigationParams.Add("character", character);
                navigationParams.Add("title", "The second page");
                Console.WriteLine($"Send: {character.Name}, {character.Age}");
                _navigationService.NavigateAsync("TheSecondPage", navigationParams);
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Character = parameters.GetValue<Character>("character");
            Title = parameters.GetValue<string>("title");
        }

        public Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return _pageDialogService.DisplayAlertAsync("Save", "Would you like to save?", "Save", "Cancel");
        }
    }
}
