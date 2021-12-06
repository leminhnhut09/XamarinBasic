using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using XamarinPrism.src._05_ListView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamarinPrism.src._05_ListView.ViewModels
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

        //private ObservableCollection<Product> _collection;
        //public ObservableCollection<Product> Collection
        //{
        //    get { return _collection; }
        //    set { SetProperty(ref _collection, value); }
        //}
        public ObservableCollection<ProductGroup> Collection { get; set; } 
            = new ObservableCollection<ProductGroup>();

        public DelegateCommand ItemTappedCommand { get; set; }

        public ListViewPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            Title = "List View";
            //Collection = new ObservableCollection<Product>(Product.GetListProduct());
            var group1 = new List<Product>
            {
                new Product("Samsung s7", "image.png", 5000000),
                new Product("Samsung a6", "image.png", 5500000),
                new Product("Samsung a50", "image.png", 7000000),
            };
            Collection.Add(new ProductGroup("Samsung", group1));

            var group2 = new List<Product>
            {
                new Product("Iphone 6", "image.png", 5000000),
                new Product("Iphone 7", "image.png", 5500000),
                new Product("Iphone 8", "image.png", 7000000),
            };
            Collection.Add(new ProductGroup("Iphone", group2));
            var group3 = new List<Product>
            {
                new Product("Xiaomi Redmi note 8", "image.png", 5000000),
                new Product("Xiaomi Redmi note 8 pro", "image.png", 5500000),
            };
            Collection.Add(new ProductGroup("Xiaomi", group3));


            //ItemTappedCommand = new DelegateCommand(ItemTapped);
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

        //private async void ItemTapped()
        //{
        //    if (Product != null)
        //    {
        //        var result = await _pageDialogService.DisplayAlertAsync("ListView", "Delete Item", "Ok", "Cancle");
        //        if (result)
        //        {
        //            Collection.Remove(Product);
        //        }
        //    }
        //}
    }
}
