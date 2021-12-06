using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using XamarinPrism.src._07_DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrism.src._07_DependencyInjection.ViewModels
{
    public class MainServicePageViewModel : BindableBase
    {

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

       
        public MainServicePageViewModel(INavigationService navigationService)
        {
            Title = "Dependecy Inject";
        }
    }
}
