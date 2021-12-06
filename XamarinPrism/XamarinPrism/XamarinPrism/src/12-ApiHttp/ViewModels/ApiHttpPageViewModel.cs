using Newtonsoft.Json;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XamarinPrism.src._12_ApiHttp.Models;

namespace XamarinPrism.src._12_ApiHttp.ViewModels
{
    public class ApiHttpPageViewModel : BindableBase
    {
        private bool _isInitial = false;
        public bool IsInitial
        {
            get { return _isInitial; }
            set { SetProperty(ref _isInitial, value); }
        }
        public ObservableCollection<ToDoItem> ListToDoItem { get; set; } = new ObservableCollection<ToDoItem>();
        public DelegateCommand OnGetCommand { get; set; }
        public DelegateCommand OnPostCommand { get; set; }
        public DelegateCommand OnPutCommand { get; set; }
        public DelegateCommand OnDeleteCommand { get; set; }
        public ApiHttpPageViewModel()
        {
            OnGetCommand = new DelegateCommand(async () => await GetToDoItemList());
            OnPostCommand = new DelegateCommand(async () => await HandlePost());
            OnPutCommand = new DelegateCommand(async () => await HandlePut());
            OnDeleteCommand = new DelegateCommand(async () => await HandleDelete());
        }

        private async Task HandleDelete()
        {
            int id = 1;
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Delete Success!!!!!");
                }
                else
                {
                    Console.WriteLine("Delete Error!!!!!");
                }
            }
        }

        private async Task HandlePut()
        {
            using(HttpClient httpClient = new HttpClient())
            {
                ToDoItem toDoItem = new ToDoItem(9, 999, "Add item", true);
                string json = JsonConvert.SerializeObject(toDoItem);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"https://jsonplaceholder.typicode.com/posts/1", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Put Success!!!!!");
                }
                else
                {
                    Console.WriteLine("Put Error!!!!!");
                }
            }
        }

        private async Task HandlePost()
        {
            using (var httpClient = new HttpClient())
            {
                ToDoItem toDoItem = new ToDoItem(999, 999, "Add item", true);
                string json = JsonConvert.SerializeObject(toDoItem);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("https://jsonplaceholder.typicode.com/posts", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post Success!!!!!");
                }
                else
                {
                    Console.WriteLine("Post Error!!!!!");
                }
            }
        }

        private async Task GetToDoItemList()
        {
            if (IsInitial) return;
            using (var httpClient = new HttpClient())
            {
                //var toDoJson = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
                //var toDoItem = JsonConvert.DeserializeObject<ToDoItem[]>(toDoJson);
                //foreach (var item in toDoItem)
                //{
                //    ListToDoItem.Add(item);
                //}

                HttpResponseMessage response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var toDoItem = JsonConvert.DeserializeObject<ToDoItem[]>(content);

                    foreach (var item in toDoItem)
                    {
                        ListToDoItem.Add(item);
                    }
                    IsInitial = true;


                }


            }
        }

    }
}
