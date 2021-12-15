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
        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;
        private IAlbumService _albumService;
        private IUserService _userService;
        private IPhotoService _photoService;

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

        List<User> UserList { get; set; } = new List<User>();
        List<Photo> PhotoList { get; set; } = new List<Photo>();
        List<Album> AlbumList { get; set; } = new List<Album>();
        public ObservableCollection<Post> PostList { get; set; } = new ObservableCollection<Post>();

        public DelegateCommand<Post> OnItemSelectedCommand { get; set; }

        private DelegateCommand _onRefreshingListViewCommand;
        public DelegateCommand OnRefreshingListViewCommand =>
            _onRefreshingListViewCommand ?? (_onRefreshingListViewCommand = new DelegateCommand(async () => await ExcuteRefreshingListView()));

        public PostPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
            IAlbumService albumService, IUserService userService, IPhotoService photoService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _albumService = albumService;
            _userService = userService;
            _photoService = photoService;
            OnItemSelectedCommand = new DelegateCommand<Post>(ExcuteItemSelected);
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
        public async void OnAppearing()
        {
            GetStatusInternet();
            await CallApi();
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                IsInternet = true;
                RefreshData();
                Device.BeginInvokeOnMainThread(async () => await CallApi());
            }
            else
            {
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
                IsInternet = true;
            }
            else
            {
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

            var users = await _userService.GetUsers();
            UserList.AddRange(users);

            var photos = await _photoService.GetPhotos(0, 50);
            PhotoList.AddRange(photos);

            var albums = await _albumService.GetAlbums();
            AlbumList.AddRange(albums);

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

        public async Task LoadMore(Post currentItem)
        {
            int itemIndex = PostList.IndexOf(currentItem);
            if (PostList.Count - 3 == itemIndex)
            {
                IsBusyLoadMore = true;
                OffSet = PostList.Count;
                PhotoList.Clear();
                var photos = await _photoService.GetPhotos(OffSet, 50);
                IsBusyLoadMore = false;
                PhotoList.AddRange(photos);

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
