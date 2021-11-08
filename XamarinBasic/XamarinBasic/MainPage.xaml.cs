using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinBasic.Source.Calculator;

namespace XamarinBasic
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void btnSlider_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SliderPage());
        }

        private void btnWebView_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedPageWebView());
        }

        private void btnImage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImagePage());
        }

        private void btnBoxView_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BoxViewPage());

        }

        private void btnGridLayout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CaculatorPage());
        }

        private void btnScollView_Clicked(object sender, EventArgs e)
        {
            
        }

        private void btnAbsoluteLayout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AbsoluteLayoutPage());
        }

        private void btnRelativeLayout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RelativeLayoutPage());
        }

        private void btnStackLayout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void btnDateAndTime_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DateAndTimePickerPage());
        }

        private void btnScrollView_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScrollView());
        }

        private void btnProgressBar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProgressBar());
        }

        private void btnListView_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListViewPage());
        }
    }
}
