using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismXamarin.src._05_ListView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PrismXamarin.src._05_ListView.ViewModels
{
    public class ListViewPageViewModel : BindableBase
    {
        protected INavigationService _navigationService;
        protected IPageDialogService _pageDialogService;

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

        private ObservableCollection<Product> _collection;
        public ObservableCollection<Product> Collection
        {
            get { return _collection; }
            set { SetProperty(ref _collection, value); }
        }

        public DelegateCommand ItemTappedCommand { get; set; }

        public ListViewPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            Title = "List View";
            Collection = new ObservableCollection<Product>(Product.GetListProduct());
            ItemTappedCommand = new DelegateCommand(ItemTapped);
        }

        //private void ItemTapped()
        //{
        //    //Console.WriteLine("Tapped");
        //    if (Product != null)
        //    {
        //        //C1
        //        var p = new NavigationParameters();
        //        p.Add("product", Product);
        //        //C2
        //        //var p = new NavigationParameters($"product={Product}");
        //        //C3
        //        //var p = new NavigationParameters()
        //        //{
        //        //    { "product", Product }
        //        //};
        //        _navigationService.NavigateAsync("DetailProductPage?title=ListViewEdit", p);
        //    }
        //}

        private async void ItemTapped()
        {
            if (Product != null)
            {
                var result = await _pageDialogService.DisplayAlertAsync("ListView", "Delete Item", "Ok", "Cancle");
                if (result)
                {
                    Collection.Remove(Product);
                }
            }
        }
    }
}
