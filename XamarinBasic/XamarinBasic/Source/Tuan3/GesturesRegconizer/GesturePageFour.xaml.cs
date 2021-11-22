using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace XamarinBasic.Source.Tuan3.GesturesRegconizer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GesturePageFour : ContentPage
    {
        public GesturePageFour()
        {
            InitializeComponent();
        }

        private void OnDragStarting(object sender, DragStartingEventArgs e)
        {
            e.Data.Text = "My text data goes here";
        }
    }
}