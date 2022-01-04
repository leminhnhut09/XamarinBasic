using LoginFacebookNative.Services;
using LoginFacebookNative.ViewModels;
using LoginFacebookNative.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginFacebookNative
{
    public partial class App : PrismApplication
    {
        public IFacebookLoginService FacebookLoginService { get; private set; }
        public App(IPlatformInitializer platformInitializer, IFacebookLoginService facebookLoginService) : base(platformInitializer)
        {
            FacebookLoginService = facebookLoginService;
        }

        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new MainPage();
        //}

        //protected override void OnStart()
        //{
        //}

        //protected override void OnSleep()
        //{
        //}

        //protected override void OnResume()
        //{
        //}
        protected override async void OnInitialized()
        {
            InitializeComponent();

            var result = await NavigationService.NavigateAsync("LoginPage");
            if (!result.Success)
            {
                Console.WriteLine("Navigation Fail !");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage>();
        }
    }
}
