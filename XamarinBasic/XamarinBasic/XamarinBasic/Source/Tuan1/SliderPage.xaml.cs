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
        Slider percentSlider;
        Label percentLabel;
        public SliderPage()
        {
            InitializeComponent();
            percentSlider = new Slider()
            {
                Minimum = 0,
                Maximum = 100,
                BackgroundColor = Color.LemonChiffon
            };
            percentLabel = new Label();
            layoutMain.Children.Add(percentSlider);
            layoutMain.Children.Add(percentLabel);
            percentSlider.ValueChanged += OnPercentSliderValueChanged;
        }

        private void OnPercentSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            string percent = ((Slider)sender).Value.ToString();
            percentLabel.Text = percent;
        }

        private void OnDescriptionEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            string description = descriptionEditor.Text.Trim().ToString();
            if (description.Length == 50)
            {
                DisplayAlert("Notification", "50 character ", "Close");
            }
        }
    }
}