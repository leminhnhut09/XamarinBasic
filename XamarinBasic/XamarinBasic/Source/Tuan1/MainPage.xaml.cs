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

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void OnSliderButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SliderPage());
        }

        private void OnWebViewButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedPageWebView());
        }

        private void OnImageButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImagePage());
        }

        private void OnBoxViewButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BoxViewPage());

        }

        private void OnGridLayoutButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Calculator());
        }

        private void OnScollViewButtonClicked(object sender, EventArgs e)
        {
            
        }

        private void OnAbsoluteLayoutButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AbsoluteLayoutPage());
        }

        private void OnRelativeLayoutButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RelativeLayoutPage());
        }

        private void OnStackLayoutButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void OnDateAndTimeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DateAndTimePickerPage());
        }

        private void OnScrollViewButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScrollView());
        }

        private void OnProgressBarButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProgressBar());
        }

        private void OnListViewButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListViewPage());
        }
    }
}
