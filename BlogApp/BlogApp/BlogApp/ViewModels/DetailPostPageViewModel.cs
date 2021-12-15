using BlogApp.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.ViewModels
{
    public class DetailPostPageViewModel : BindableBase, INavigationAware
    {
        const string PostKey = "post";
        private string _title = "Chi tiết";
        public string Title 
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private Post _postItem;
        public Post PostItem
        {
            get { return _postItem; }
            set { SetProperty(ref _postItem, value); }
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(PostKey))
            {
                var param = parameters.GetValue<Post>(PostKey);
                if(param != null)
                {
                    PostItem = param;
                }
            }
        }
    }
}
