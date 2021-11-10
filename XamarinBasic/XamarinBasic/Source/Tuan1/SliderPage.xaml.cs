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
    public partial class SliderPage : ContentPage
    {
        Slider sliderPercent;
        Label labelShowPercent;
        public SliderPage()
        {
            InitializeComponent();
            sliderPercent = new Slider()
            {
                Minimum = 0,
                Maximum = 100,
                BackgroundColor = Color.LemonChiffon
            };
            labelShowPercent = new Label();
            layoutMain.Children.Add(sliderPercent);
            layoutMain.Children.Add(labelShowPercent);
            sliderPercent.ValueChanged += SliderPercent_ValueChanged;
        }

        private void SliderPercent_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            string percent = ((Slider)sender).Value.ToString();
            labelShowPercent.Text = percent;
        }

        private void EditorDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            string description = editorDescription.Text.Trim().ToString();
            if (description.Length == 50)
            {
                DisplayAlert("Notification", "50 character ", "Close");
            }
        }
    }
}