using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using XamarinPrism;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinPrism.src._06_DependencyService.ViewModels
{
    public class DependencyServicePageViewModel : BindableBase
    {
        protected INavigationService _navigationService;
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public DelegateCommand OnSpeakCommand { get; set; }

        public DependencyServicePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            OnSpeakCommand = new DelegateCommand(Speak);
        }

        private void Speak()
        {
            DependencyService.Get<ITextToSpeech>().Speak("Helo xamain form !!");
        }
    }
}
