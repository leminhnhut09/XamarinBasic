using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XamarinPrism.src._11_Api.Models;
using XamarinPrism.src._11_Api.Services;
using XamarinPrism.src._12_ApiHttp.Models;
using XamarinPrism.src._12_ApiHttp.Services;

namespace XamarinPrism.src._11_Api.ViewModel
{
    public class ApiPageViewModel : BindableBase
    {
        protected IPageDialogService _pageDialogService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set { SetProperty(ref _brand, value); }
        }
        public DelegateCommand OnLoadDataCommand { get; set; }
        public DelegateCommand OnPostCommand { get; set; }
        public DelegateCommand OnPutCommand { get; set; }
        public DelegateCommand OnDeleteCommand { get; set; }

        public ObservableCollection<MakeUp> ListMakeUp { get; set; } = new ObservableCollection<MakeUp>();
        //public ObservableCollection<MakeUp> ListMakeUp { get; set; }
        public ApiPageViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            Title = "API";
            OnLoadDataCommand = new DelegateCommand(async () => await ExecuteLoadDataAsync());
            OnPostCommand = new DelegateCommand(async () => await HandlePost());
            OnPutCommand = new DelegateCommand(async () => await HandlePut());
            OnDeleteCommand = new DelegateCommand(async () => await HandleDelete());
        }

        private async Task HandleDelete()
        {
            var apiResponse = RestService.For<IToDoItemService>("https://jsonplaceholder.typicode.com");
            var response = await apiResponse.DeleteToDoItem(1);
        }

        private async Task HandlePut()
        {
            var apiResponse = RestService.For<IToDoItemService>("https://jsonplaceholder.typicode.com");
            var response = await apiResponse.PutToDoItem(new ToDoItem()
            {
                Id = 1,
                Title = "Hello xamarin",
                Completed = true,
                UserId = 1
            }, 1);
        }

        private async Task HandlePost()
        {
            var apiResponse = RestService.For<IToDoItemService>("https://jsonplaceholder.typicode.com");
            var response = await apiResponse.PostToDoItem(new ToDoItem()
            {
                Id = 1,
                Title = "Hello xamarin",
                Completed = true,
                UserId = 1
            });
            
        }

        async Task ExecuteLoadDataAsync()
        {
            var apiResponse = RestService.For<IMakeUp>("https://makeup-api.herokuapp.com");
            //var makeUps = await apiResponse.GetMakeUps("covergirl", "lipstick");
            var makeUps = await apiResponse.GetMakeUps("maybelline");
            foreach (var item in makeUps)
            {
                ListMakeUp.Add(item);
            }
            //Console.WrkiteLine("aaaaaaaaaaa: load xong");
        }
    }
}
