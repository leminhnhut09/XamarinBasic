using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using XamarinPrism.src._04_NavigationService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinPrism.src._04_NavigationService.ViewModels
{
    public class NavigationMainPageViewModel
    {
        protected INavigationService _navigationService;

        protected IPageDialogService _pageDialogService;
        public Character Character { get; set; }
        public DelegateCommand<Character> OnSendChacterCommand { get; set; }
        public NavigationMainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            Character = new Character("Nguyễn A", 16, new DateTime(2021, 11, 24));

            OnSendChacterCommand = new DelegateCommand<Character>(OnSendTheFirstPage);
        }

        private bool CanExcute(Character character)
        {
            return character != null;
        }

        private void OnSendTheFirstPage(Character character)
        {
            if (character != null)
            {
                //var navigationParams = new NavigationParameters
                //{
                //    {"character", "aa" }
                //};
                var navigationParams = new NavigationParameters();
                navigationParams.Add("character", character);
                navigationParams.Add("title", "The first page");
                _navigationService.NavigateAsync("TheFirstPage", navigationParams);
            }
        }
    }
}
