using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Prism.Unity;
using System;
using Xamarin.Forms;
using XamarinEntity.Models;
using XamarinEntity.Services;
using XamarinEntity.ViewModels;
using XamarinEntity.Views;

namespace XamarinEntity
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {
        }

        protected async override void OnInitialized()
        {
            var result = await NavigationService.NavigateAsync("NavigationPage/GradePage");
            if (!result.Success)
            {
                Console.WriteLine("Navigation fail!");
            }
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterForNavigation<StudentPage, StudentPageViewModel>();
            containerRegistry.RegisterForNavigation<AddStudentPage, AddStudentPageViewModel>();
            containerRegistry.RegisterForNavigation<GradePage, GradePageViewModel>();

            // Service
            containerRegistry.Register<IStudentService, StudentService>();
            containerRegistry.Register<IGradeService, GradeService>();

        }

        protected override void OnResume()
        {
            this.PopupPluginOnResume();
        }

        protected override void OnSleep()
        {
            this.PopupPluginOnSleep();
        }
    }
}
