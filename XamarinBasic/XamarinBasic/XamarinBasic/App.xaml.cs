using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBasic.Source.Tuan2;
using XamarinBasic.Source.Tuan3;

namespace XamarinBasic
{
    public partial class App : Application
    {
        internal static double ScreenWidth;
        internal static double ScreenHeight;

        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new MainPage());

            // Week 1 + 2
            //MainPage = new FlyoutPageMain();

            // Week 3
            MainPage = new WeekThreeFlyoutPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
