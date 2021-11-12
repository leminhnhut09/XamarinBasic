using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinBasic.Source.Tuan1;

namespace XamarinBasic
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void ButtonSlider_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SliderPage());
        }

        private void ButtonWebView_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedPageWebView());
        }

        private void ButtonImage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImagePage());
        }

        private void ButtonBoxView_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BoxViewPage());

        }

        private void ButtonGridLayout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Calculator());
        }

        private void ButtonScollView_Clicked(object sender, EventArgs e)
        {
            
        }

        private void ButtonAbsoluteLayout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AbsoluteLayoutPage());
        }

        private void ButtonRelativeLayout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RelativeLayoutPage());
        }

        private void ButtonStackLayout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void ButtonDateAndTime_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DateAndTimePickerPage());
        }

        private void ButtonScrollView_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScrollView());
        }

        private void ButtonProgressBar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProgressBar());
        }

        private void ButtonListView_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListViewPage());
        }
    }
}
