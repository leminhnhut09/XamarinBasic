using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic.Source.Tuan3.CustomRenderer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomRendererPage : ContentPage
    {
        public CustomRendererPage()
        {
            InitializeComponent();
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            DisplayAlert("Noti", "Custom renderer", "Đóng");
        }

        private void MyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DisplayAlert("Noti", "Real", "Đóng");
        }
    }
}