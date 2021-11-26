using Prism;
using Prism.Ioc;
using PrismXamarin.src._01_AppLifeCycle.ViewModels;
using PrismXamarin.src._01_AppLifeCycle.Views;
using PrismXamarin.src._02_PageLifeCycle.ViewModels;
using PrismXamarin.src._02_PageLifeCycle.Views;
using PrismXamarin.src._04_NavigationService.ViewModels;
using PrismXamarin.src._04_NavigationService.Views;
using PrismXamarin.src._05_ListView.Views;
using PrismXamarin.src._06_DependencyService.ViewModels;
using PrismXamarin.src._06_DependencyService.Views;
using PrismXamarin.src._07_DependencyInjection.Interfaces;
using PrismXamarin.src._07_DependencyInjection.Views;
using PrismXamarin.src._07_DependencyInjection.Services;
using PrismXamarin.src._07_DependencyInjection.ViewModels;
using PrismXamarin.src._08_MasterDetailPage.ViewModels;
using PrismXamarin.src._08_MasterDetailPage.Views;
using PrismXamarin.src._09_TabbedPage.ViewModels;
using PrismXamarin.src._09_TabbedPage.Views;
using PrismXamarin.src._11_XamlNavigation.ViewModel;
using PrismXamarin.src._11_XamlNavigation.Views;
using PrismXamarin.ViewModels;
using PrismXamarin.Views;
using System;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using Prism.Mvvm;
using System.Reflection;
using PrismXamarin.src._03_ViewModelLocator.ViewPages;

namespace PrismXamarin
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");

            //await NavigationService.NavigateAsync("PrismMasterDetailPage/NavigationPage/ViewA");
            //await NavigationService.NavigateAsync("NavigationPage/LocatorPage");
        }
        //protected override void ConfigureViewModelLocator()
        //{
        //    base.ConfigureViewModelLocator();
        //    ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
        //    {
        //        var viewName = viewType.FullName.Replace(".ViewPages.", ".CustomViewModel.");
        //        var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
        //        var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";
        //        return Type.GetType(viewModelName);

        //    });
        //}


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            // 1. App life cycle
            containerRegistry.RegisterForNavigation<AppLifeCycleMainPage>();
            containerRegistry.RegisterForNavigation<ViewAPage, ViewAPageViewModel>();

            // 2. Page life cycle
            containerRegistry.RegisterForNavigation<LifecyclePage, LifecyclePageViewModel>();
            containerRegistry.RegisterForNavigation<DetailLifecyclePage, DetailLifeCyclePageViewModel>();

            // 3. ViewModelLocator
            //containerRegistry.RegisterForNavigation<LocatorPage, LocatorPageViewModel>();
            //containerRegistry.RegisterForNavigation<LocatorPage, CustomPageViewModel>();
            containerRegistry.RegisterForNavigation<LocatorPage>();

            // 4.Navigation Service
            containerRegistry.RegisterForNavigation<NavigationMainPage, NavigationMainPageViewModel>();
            containerRegistry.RegisterForNavigation<TheFirstPage>();
            containerRegistry.RegisterForNavigation<TheSecondPage>();

            // 5. List View
            containerRegistry.RegisterForNavigation<ListViewPage>();
            containerRegistry.RegisterForNavigation<DetailProductPage>();

            // 6. Dependency Service
            containerRegistry.RegisterForNavigation<DependencyServicePage, DependencyServicePageViewModel>();

            // 7. Dependency Injection
            containerRegistry.RegisterForNavigation<SingletonService, SingeltonServiceViewModel>();
            containerRegistry.RegisterForNavigation<MainServicePage, MainServicePageViewModel>();
            containerRegistry.RegisterForNavigation<TransientService, TransientServiceViewModel>();
            containerRegistry.RegisterSingleton<ICustomService, CustomService>();
            containerRegistry.Register<ISecondService, SecondService>();

            // 8. MasterDetail Page
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<PrismMasterDetailPage, PrismMasterDetailPageViewModel>();

            // 9. Tabbed Page
            containerRegistry.RegisterForNavigation<PrismTabbedPage1, PrismTabbedPage1ViewModel>();
            containerRegistry.RegisterForNavigation<TabA>();
            containerRegistry.RegisterForNavigation<TabB>();

            // 10. Navigation Page
            // 11. Xaml Navigation
            containerRegistry.RegisterForNavigation<XamlA, XamlViewModel>();
            containerRegistry.RegisterForNavigation<XamlNavigationPage>();

        }

        // Initialize() ->  OnStart()
        protected override void OnStart()
        {
            base.OnStart();
            //Console.WriteLine("OnStart");
        }
        protected override void Initialize()
        {
            base.Initialize();
            //Console.WriteLine("Initialize");
        }
        protected override void OnSleep()
        {
            base.OnSleep();
            //Console.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            base.OnResume();
            //Console.WriteLine("OnResume");
        }
    }
}
