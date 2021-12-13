using BlogApp.Models;
using BlogApp.Services;
using Prism.Commands;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Prism.Navigation;
using Prism.Services;
using BlogApp.Views;
using Prism.Mvvm;
using Xamarin.Forms;
using Xamarin.Essentials;
using Prism.AppModel;

namespace BlogApp.ViewModels
{
    public class PostPageViewModel : BindableBase, IPageLifecycleAware, IApplicationLifecycleAware
    {
        protected INavigationService _navigationService;
        protected IPageDialogService _pageDialogService;
        protected IAlbumService _albumService;
        protected IUserService _userService;
        protected IPhotoService _photoService;

        private string _title = "Danh Sách";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isbusy;
        public bool IsBusy
        {
            get { return _isbusy; }
            set { SetProperty(ref _isbusy, value); }
        }

        private bool _isInternet;
        public bool IsInternet
        {
            get { return _isInternet; }
            set { SetProperty(ref _isInternet, value); }
        }

        private bool _isNotInternet;
        public bool IsNotInternet
        {
            get { return _isNotInternet; }
            set { SetProperty(ref _isNotInternet, value); }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        private bool _isBusyLoadMore;
        public bool IsBusyLoadMore
        {
            get { return _isBusyLoadMore; }
            set { SetProperty(ref _isBusyLoadMore, value); }
        }

        private int _offset = 0;
        public int OffSet
        {
            get { return _offset; }
            set { SetProperty(ref _offset, value); }
        }

        public List<User> UserList { get; set; } = new List<User>();
        public List<Photo> PhotoList { get; set; } = new List<Photo>();
        public List<Album> AlbumList { get; set; } = new List<Album>();
        public ObservableCollection<Post> PostList { get; set; } = new ObservableCollection<Post>();

        public DelegateCommand<Post> OnItemSelectedCommand { get; set; }
        public DelegateCommand OnRefreshingListViewCommand { get; set; }
        public PostPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
            IAlbumService albumService, IUserService userService, IPhotoService photoService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _albumService = albumService;
            _userService = userService;
            _photoService = photoService;
            OnItemSelectedCommand = new DelegateCommand<Post>(ExcuteItemSelected);
            OnRefreshingListViewCommand = new DelegateCommand(async () => await ExcuteRefreshingListView());
            GetStatusInternet();
            Device.BeginInvokeOnMainThread(async () => await CallApi());
        }

        private async Task ExcuteRefreshingListView()
        {
            RefreshData();
            await CallApi();
            IsRefreshing = false;
        }

        private async void ExcuteItemSelected(Post post)
        {
            if (post != null)
            {
                var navigationParams = new NavigationParameters();
                navigationParams.Add("post", post);
                var result = await _navigationService.NavigateAsync(nameof(DetailPostPage), navigationParams);
                if (!result.Success)
                {
                    await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể chuyển trang", "Đóng");
                }
            }
        }
        public void OnAppearing()
        {
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                IsNotInternet = false;
                IsInternet = true;
                RefreshData();
                Device.BeginInvokeOnMainThread(async () => await CallApi());
            }
            else
            {
                IsNotInternet = true;
                IsInternet = false;
            }
        }

        private void RefreshData()
        {
            UserList.Clear();
            AlbumList.Clear();
            PhotoList.Clear();
            PostList.Clear();
        }

        public void OnDisappearing()
        {
            Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        }

        private void GetStatusInternet()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                IsNotInternet = false;
                IsInternet = true;
            }
            else
            {
                IsNotInternet = true;
                IsInternet = false;
            }
        }

        private async Task CallApi()
        {
            if (!IsInternet)
            {
                return;
            }
            if (!IsRefreshing)
            {
                IsBusy = true;
            }
            // users
            //var responseUser = RestService.For<IUserService>("http://jsonplaceholder.typicode.com");
            //var users = await responseUser.GetUsers();
            var users = await _userService.GetUsers();
            foreach (var item in users)
            {
                UserList.Add(item);
            }
            //var responsePhoto = RestService.For<IPhotoService>("http://jsonplaceholder.typicode.com");
            //var photos = await responsePhoto.GetPhotos();
            var photos = await _photoService.GetPhotos(0, 50);
            foreach (var item in photos)
            {
                PhotoList.Add(new Photo(item.AlbumId, item.Title, item.ThumbnailUrl));
            }

            //var responseAlbum = RestService.For<IAlbumService>("http://jsonplaceholder.typicode.com");
            //var albums = await responseAlbum.GetAlbums();
            var albums = await _albumService.GetAlbums();
            foreach (var item in albums)
            {
                AlbumList.Add(item);
            }
            var listPost = from p in PhotoList
                           join a in AlbumList on p.AlbumId.ToString() equals a.Id.ToString()
                           join u in UserList on a.UserId.ToString() equals u.Id.ToString()
                           select new
                           {
                               p.ThumbnailUrl,
                               p.Title,
                               a.TitleAlbum,
                               u.UserName
                           };
            if (listPost == null)
            {
                IsBusy = false;
                return;
            } 
            foreach (var item in listPost)
            {
                PostList.Add(new Post(item.UserName, item.TitleAlbum, item.Title, item.ThumbnailUrl));
            }
            IsBusy = false;
        }

        public async void LoadMore(Post currentItem)
        {
            int itemIndex = PostList.IndexOf(currentItem);
            Console.WriteLine("indexxxxxxxxxxx:" + itemIndex);
            if (PostList.Count - 3 == itemIndex)
            {
                IsBusyLoadMore = true;
                OffSet = PostList.Count;
                PhotoList.Clear();
                var photos = await _photoService.GetPhotos(OffSet, 50);
                IsBusyLoadMore = false;
                foreach (var item in photos)
                {
                    PhotoList.Add(new Photo(item.AlbumId, item.Title, item.ThumbnailUrl));
                }

                var listPost = from p in PhotoList
                               join a in AlbumList on p.AlbumId.ToString() equals a.Id.ToString()
                               join u in UserList on a.UserId.ToString() equals u.Id.ToString()
                               select new
                               {
                                   p.ThumbnailUrl,
                                   p.Title,
                                   a.TitleAlbum,
                                   u.UserName
                               };
                foreach (var item in listPost)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        PostList.Add(new Post(item.UserName, item.TitleAlbum, item.Title, item.ThumbnailUrl));
                    });
                }
                //PhotoList.Clear();
                Console.WriteLine("PostList" + PostList.Count);
            }
        }

        public async void OnResume()
        {
            GetStatusInternet();
            await CallApi();
        }

        public void OnSleep()
        {
            RefreshData();
        }
    }
}
