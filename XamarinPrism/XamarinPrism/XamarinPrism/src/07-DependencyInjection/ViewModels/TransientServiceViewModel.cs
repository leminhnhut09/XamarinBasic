using Prism.Mvvm;
using Prism.Navigation;
using XamarinPrism.src._07_DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamarinPrism.src._07_DependencyInjection.ViewModels
{
    public class TransientServiceViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<int> _listCustomer;
        public ObservableCollection<int> ListCustomer
        {
            get { return _listCustomer; }
            set { SetProperty(ref _listCustomer, value); }
        }

        //private int numberValue;

        //public int NumberValue
        //{
        //    get => numberValue;
        //    set => SetProperty(ref numberValue, value);
        //}

        public TransientServiceViewModel(INavigationService navigationService, ISecondService secondService)
        {
            _navigationService = navigationService;
            ListCustomer = new ObservableCollection<int>(secondService.ListCustomer);
            //NumberValue = secondService.NumberValue;

        }
    }
}
