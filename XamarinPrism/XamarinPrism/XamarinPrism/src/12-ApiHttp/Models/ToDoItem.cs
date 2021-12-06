using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace XamarinPrism.src._12_ApiHttp.Models
{
    public class ToDoItem
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        public ToDoItem()
        {

        }
        public ToDoItem(int userId, int id, string title, bool completed)
        {
            UserId = userId;
            Id = id;
            Title = title;
            Completed = completed;
        }
    }
}
