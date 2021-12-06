using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinPrism.src._15_Essential.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Screenshot : ContentPage
    {
        public Screenshot()
        {
            InitializeComponent();
        }


        private async void OnScreenShotClicked(object sender, EventArgs e)
        {
            var screenshot = await Xamarin.Essentials.Screenshot.CaptureAsync();
            var stream = await screenshot.OpenReadAsync();

            screenImage.Source = ImageSource.FromStream(() => stream);
        }
    }
}