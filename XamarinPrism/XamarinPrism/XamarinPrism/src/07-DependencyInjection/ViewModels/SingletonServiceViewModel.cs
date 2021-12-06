using Prism.Mvvm;
using Prism.Navigation;
using XamarinPrism.src._07_DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace XamarinPrism.src._07_DependencyInjection.ViewModels
{
    public class SingeltonServiceViewModel : BindableBase
    {

        protected INavigationService _navigationService;

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

        public SingeltonServiceViewModel(INavigationService navigationService, ICustomService customService)
        {
            _navigationService = navigationService;
            ListCustomer = new ObservableCollection<int>(customService.ListCustomer);
            //NumberValue = customService.NumberValue;
        }

    }
}
