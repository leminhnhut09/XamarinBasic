using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic.Source.Tuan3.Converter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConverterTabbedPage : TabbedPage
    {
        public ConverterTabbedPage()
        {
            InitializeComponent();
        }

        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            TabbedPage tabbed = sender as TabbedPage;
            DisplayAlert("Noti", tabbed.CurrentPage.Title, "Close");
            //tabbed.CurrentPage.IconImageSource = "image.png";
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }
    }
}