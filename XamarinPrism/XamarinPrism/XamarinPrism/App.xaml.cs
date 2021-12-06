using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using essential = Xamarin.Essentials;
using XamarinPrism.src._00_MainNavigation.ViewModels;
using XamarinPrism.src._00_MainNavigation.Views;
using XamarinPrism.src._01_AppLifeCycle.ViewModels;
using XamarinPrism.src._01_AppLifeCycle.Views;
using XamarinPrism.src._02_PageLifeCycle.ViewModels;
using XamarinPrism.src._02_PageLifeCycle.Views;
using XamarinPrism.src._04_NavigationService.ViewModels;
using XamarinPrism.src._04_NavigationService.Views;
using XamarinPrism.src._05_ListView.ViewModels;
using XamarinPrism.src._05_ListView.Views;
using XamarinPrism.src._06_DependencyService.ViewModels;
using XamarinPrism.src._06_DependencyService.Views;
using XamarinPrism.src._07_DependencyInjection.Interfaces;
using XamarinPrism.src._07_DependencyInjection.Services;
using XamarinPrism.src._07_DependencyInjection.ViewModels;
using XamarinPrism.src._07_DependencyInjection.Views;
using XamarinPrism.src._08_MasterDetailPage.ViewModels;
using XamarinPrism.src._08_MasterDetailPage.Views;
using XamarinPrism.src._09_TabbedPage.ViewModels;
using XamarinPrism.src._09_TabbedPage.Views;
using XamarinPrism.src._10_XamlNavigation.ViewModel;
using XamarinPrism.src._10_XamlNavigation.Views;
using XamarinPrism.src._11_Api.ViewModel;
using XamarinPrism.src._11_Api.Views;
using XamarinPrism.src._12_ApiHttp.ViewModels;
using XamarinPrism.src._12_ApiHttp.Views;
using XamarinPrism.src._13_MessageCenter.ViewModels;
using XamarinPrism.src._13_MessageCenter.Views;
using XamarinPrism.src._14_Aggregator.ViewModels;
using XamarinPrism.src._14_Aggregator.Views;
using XamarinPrism.src._15_Essential.ViewModels;
using XamarinPrism.src._15_Essential.Views;
using System.Diagnostics;

namespace XamarinPrism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {
        }
        protected override async void OnInitialized()
        {
            InitializeComponent();
            essential.AppActions.OnAppAction += OnAppActions;
            // VersionTracking.Track();
            essential.VersionTracking.Track();
            var result = await NavigationService.NavigateAsync("NavigationPage/MainPage");
            if (!result.Success)
            {
                Console.WriteLine("errrrrrrrrrrrrrrrrr");
            }
        }

        private void OnAppActions(object sender, essential.AppActionEventArgs e)
        {
            //if (Application.Current != this && Application.Current is App app)
            //{
            //    essential.AppActions.OnAppAction -= app.OnAppActions;
            //    return;
            //}
            essential.MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.GoToAsync($"//{e.AppAction.Id}");
                //await Shell.Current.GoToAsync("NavigationPage/MainPage");

            });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            // 01 - AppLifeCycle
            containerRegistry.RegisterForNavigation<AppLifeCycleMainPage, AppLifeCycleMainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewAPage, ViewAPageViewModel>();
            // 02 - PageLifeCycle
            containerRegistry.RegisterForNavigation<LifecyclePage, LifecyclePageViewModel>();
            containerRegistry.RegisterForNavigation<DetailLifecyclePage, DetailLifeCyclePageViewModel>();
            // 04 - NavigationService
            containerRegistry.RegisterForNavigation<NavigationMainPage, NavigationMainPageViewModel>();
            containerRegistry.RegisterForNavigation<TheFirstPage, TheFirstPageViewModel>();
            containerRegistry.RegisterForNavigation<TheSecondPage, TheSecondPageViewModel>();
            // 05 - ListView
            containerRegistry.RegisterForNavigation<ListViewPage, ListViewPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailProductPage, DetailProductPageViewModel>();
            // 06 - DependencyService
            containerRegistry.RegisterForNavigation<DependencyServicePage, DependencyServicePageViewModel>();
            // 07 - DependencyInjection
            containerRegistry.RegisterSingleton<ICustomService, CustomService>();
            containerRegistry.Register<ISecondService, SecondService>();
            containerRegistry.RegisterForNavigation<MainServicePage, MainServicePageViewModel>();
            containerRegistry.RegisterForNavigation<SingletonService, SingeltonServiceViewModel>();
            containerRegistry.RegisterForNavigation<TransientService, TransientServiceViewModel>();
            // 08 - MasterDetailPage
            containerRegistry.RegisterForNavigation<PrismMasterDetailPage, PrismMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            // 09 - TabbedPage
            containerRegistry.RegisterForNavigation<PrismTabbedPage1, PrismTabbedPage1ViewModel>();
            containerRegistry.RegisterForNavigation<TabA, TabAViewModel>();
            containerRegistry.RegisterForNavigation<TabB, TabBViewModel>();
            // 10 - XamlNavigation 
            containerRegistry.RegisterForNavigation<XamlNavigationPage>();
            containerRegistry.RegisterForNavigation<XamlA, XamlAViewModel>();
            // 11 - Api
            containerRegistry.RegisterForNavigation<ApiPage, ApiPageViewModel>();
            // 12 - ApiHttp
            containerRegistry.RegisterForNavigation<ApiHttpPage, ApiHttpPageViewModel>();
            // 13 - Message Center
            containerRegistry.RegisterForNavigation<MessageAPage, MessageAPageViewModel>();
            containerRegistry.RegisterForNavigation<MessageBPage, MessageBPageViewModel>();
            // 14 - Aggregetor
            containerRegistry.RegisterForNavigation<AggregatorPage, AggregatorPageViewModel>();
            containerRegistry.RegisterForNavigation<RecievePage, RecievePageViewModel>();
            // 15 - Essentials
            containerRegistry.RegisterForNavigation<MainEssentialPage, MainEssentialPageViewModel>();
            containerRegistry.RegisterForNavigation<AppInfomation, AppInfomationViewModel>();
            containerRegistry.RegisterForNavigation<Batterry, BatterryViewModel>();
            containerRegistry.RegisterForNavigation<Clipboard, ClipboardViewModel>();
            containerRegistry.RegisterForNavigation<ColorConverters, ColorConvertersViewModel>();
            containerRegistry.RegisterForNavigation<Connectivity, ConnectivityViewModel>();
            containerRegistry.RegisterForNavigation<DetectShake, DetectShakeViewModel>();
            containerRegistry.RegisterForNavigation<DeviceDisplayInformation, DeviceDisplayInformationViewModel>();
            containerRegistry.RegisterForNavigation<DeviceInfomation, DeviceInfomationViewModel>();
            containerRegistry.RegisterForNavigation<Email, EmailViewModel>();
            containerRegistry.RegisterForNavigation<FilePicker, FilePickerViewModel>();
            containerRegistry.RegisterForNavigation<FileSystemHelpers, FileSystemHelpersViewModel>();
            containerRegistry.RegisterForNavigation<FlaskLight, FlaskLightViewModel>();
            containerRegistry.RegisterForNavigation<GeoCoding, GeoCodingViewModel>();
            containerRegistry.RegisterForNavigation<Geolocation, GeolocationViewModel>();
            containerRegistry.RegisterForNavigation<Gyroscope, GyroscopeViewModel>();
            containerRegistry.RegisterForNavigation<HapticFeedback, HapticFeedbackViewModel>();
            containerRegistry.RegisterForNavigation<Launcher, LauncherViewModel>();
            containerRegistry.RegisterForNavigation<MainThread, MainThreadViewModel>();
            containerRegistry.RegisterForNavigation<Map, MapViewModel>();
            containerRegistry.RegisterForNavigation<MediaPicker, MediaPickerViewModel>();
            containerRegistry.RegisterForNavigation<Browser, BrowserViewModel>();
            containerRegistry.RegisterForNavigation<PhoneDailer, PhoneDailerViewModel>();
            containerRegistry.RegisterForNavigation<Preferences, PreferencesViewModel>();
            containerRegistry.RegisterForNavigation<Screenshot, ScreenshotViewModel>();
            containerRegistry.RegisterForNavigation<SecureStorage, SecureStorageViewModel>();
            containerRegistry.RegisterForNavigation<Share, ShareViewModel>();
            containerRegistry.RegisterForNavigation<Sms, SmsViewModel>();
            containerRegistry.RegisterForNavigation<TextToSpeech, TextToSpeechViewModel>();
            containerRegistry.RegisterForNavigation<UnitConverters, UnitConvertersViewModel>();
            containerRegistry.RegisterForNavigation<VersionTracking, VersionTrackingViewModel>();
            containerRegistry.RegisterForNavigation<Vibrate, VibrateViewModel>();
            containerRegistry.RegisterForNavigation<WebAuthenticator, WebAuthenticatorViewModel>();

        }



        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new MainPage();
        //}

        protected override async void OnStart()
        {
            try
            {
                await essential.AppActions.SetAsync(
                    new essential.AppAction("app_info", "App Info", icon: "app_info_action_icon"),
                    new essential.AppAction("battery_info", "Battery Info"));
            }
            catch (essential.FeatureNotSupportedException ex)
            {
                Debug.WriteLine("App Actions not supported");
            }
        }

        //protected override void OnSleep()
        //{
        //}

        //protected override void OnResume()
        //{
        //}

    }
}
