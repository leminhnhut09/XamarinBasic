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
    public partial class DetailCharactorPage : ContentPage
    {
        public DetailCharactorPage()
        {
            InitializeComponent();
        }


        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }
    }
}