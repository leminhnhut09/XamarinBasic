using Prism.Mvvm;
using Prism.Navigation;
using PrismXamarin.src._05_ListView.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismXamarin.src._05_ListView.ViewModels
{
    public class DetailProductPageViewModel : BindableBase, INavigationAware
    {

        protected INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private Product _product;
        public Product Product
        {
            get { return _product; }
            set { SetProperty(ref _product, value); }
        }

        public DetailProductPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Detail Product";
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("product"))
            {
            Product = parameters.GetValue<Product>("product");
            }

            if (parameters.ContainsKey("title"))
            {
            Title = parameters.GetValue<string>("title");

            }

        }
    }
}
