using BlogApp.Models;
using BlogApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlogApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostPage : ContentPage
    {
        public PostPage()
        {
            InitializeComponent();
        }

        private async void OnListViewItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var viewmodel = BindingContext as PostPageViewModel;
            //(BindingContext as PostPageViewModel).LoadMore(e.Item as Post);
            if(viewmodel != null)
            {
                await viewmodel.LoadMore(e.Item as Post);
            }
        }
    }
}