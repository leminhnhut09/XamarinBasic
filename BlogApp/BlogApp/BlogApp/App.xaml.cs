using BlogApp.Helpers;
using BlogApp.Services;
using BlogApp.Themes;
using BlogApp.ViewModels;
using BlogApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlogApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            var result = await NavigationService.NavigateAsync("LoginPage");
            if (!result.Success)
            {
                Console.WriteLine("Navigation Fail !");
            }
        }

        private void OnRequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            string theme = e.RequestedTheme.ToString();
            LoadTheme(theme);
        }

        private void LoadTheme(string theme)
        {
            Console.WriteLine("themeeeeeeeeee:" + theme);
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (theme)
                {
                    case "Dark":
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case "Light":
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<InfoPage, InfoPageViewModel>();
            containerRegistry.RegisterForNavigation<InfomationPage, InfomationPageViewModel>();
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IAlbumService, AlbumService>();
            containerRegistry.Register<IPhotoService, PhotoService>();
            containerRegistry.RegisterForNavigation<PostPage, PostPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingPage, SettingPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailPostPage, DetailPostPageViewModel>();
        }
        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new MainPage();
        //}

        protected override void OnStart()
        {
            int theme = Preferences.Get("theme", 0);
            TheTheme.SetTheme(theme);
        }

        //protected override void OnSleep()
        //{
        //}

        //protected override void OnResume()
        //{
        //    //LoadTheme();
        //}

    }
}
