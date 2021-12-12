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
        private string _title = "Detail Post";
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
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("post"))
            {
                var param = parameters.GetValue<Post>("post");
                if(param != null)
                {
                    PostItem = param;
                }
            }
        }
    }
}
