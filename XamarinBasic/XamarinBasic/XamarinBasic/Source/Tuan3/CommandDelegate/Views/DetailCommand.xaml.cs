using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic.Source.Tuan3.CommandDelegate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailCommand : ContentPage
    {
        public DetailCommand(string mess)
        {
            InitializeComponent();
            //numberLabel.Text = number.ToString();
            numberLabel.Text = mess;
        }

        private void OnBackButtonClick(object sender, EventArgs e)
        {

            MessagingCenter.Send<string, string>("this", "mess", "Data gửi về");
            Navigation.PopModalAsync();
        }
    }
}