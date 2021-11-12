using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic.Source.Tuan1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailRegister : ContentPage
    {
        public DetailRegister()
        {
            InitializeComponent();
        }

        private void OnRemoveButtonClick(object sender, EventArgs e)
        {
            Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
        }

        private void OnInsertButtonClick(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
        }
    }
}