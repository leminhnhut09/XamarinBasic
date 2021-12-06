using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinPrism.src._12_ApiHttp.Models;

namespace XamarinPrism.src._12_ApiHttp.Services
{
    public interface IToDoItemService
    {
        [Post("/posts")]
        Task<ToDoItem> PostToDoItem([Body]ToDoItem item);

        [Put("/posts/{id}")]
        Task<ToDoItem> PutToDoItem([Body] ToDoItem item, int id);

        [Delete("/posts/{id}")]
        Task<ToDoItem> DeleteToDoItem(int id);

    }
}
