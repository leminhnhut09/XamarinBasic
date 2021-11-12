using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBasic.Source.Tuan2;

namespace XamarinBasic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new MainPage());
            MainPage = new FlyoutPageMain();
            //MainPage = new ListViewSelectedItemBehavior();
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
