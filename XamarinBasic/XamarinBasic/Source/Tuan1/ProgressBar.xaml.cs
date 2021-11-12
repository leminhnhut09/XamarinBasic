using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressBar : ContentPage
    {
        public ProgressBar()
        {
            InitializeComponent();
            statusSwitch.Toggled += SwitchStatus_Toggled;
        }

        private void SwitchStatus_Toggled(object sender, ToggledEventArgs e)
        {
            DisplayAlert("Status", $"You have selected the status {e.Value}", "Ok");
        }

        private void OnProgressbarButtonClicked(object sender, EventArgs e)
        {
            percentProgressbar.ProgressTo(10, 9000, Easing.Linear);
        }
    }
}