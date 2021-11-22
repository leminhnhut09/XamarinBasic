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
    public partial class CharacterPage : ContentPage
    {
        public CharacterPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Charactor charactor = e.SelectedItem as Charactor;
            if(charactor != null)
            {
                DetailCharactorPage detail = new DetailCharactorPage();
                detail.BindingContext = charactor;
                Navigation.PushModalAsync(detail);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }
    }
}