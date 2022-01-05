using BlogApp.Models;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.ViewModels
{
    public class DetailPostPageViewModel : ViewModelBase
    {
        const string PostKey = "post";
        private Post _postItem;

        public DetailPostPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : 
            base(navigationService, pageDialogService)
        {
            Title = "Chi tiết";
        }

        public Post PostItem
        {
            get { return _postItem; }
            set { SetProperty(ref _postItem, value); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
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
