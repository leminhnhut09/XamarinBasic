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
    public partial class DateAndTimePickerPage : ContentPage
    {
        public DateAndTimePickerPage()
        {
            InitializeComponent();
        }

        private void OnProcessButtonClicked(object sender, EventArgs e)
        {
            string currentDate = datePicker.Date.ToString("dd/MM/yyyy");
            string currentTime = timePicker.Time.ToString();
            DisplayAlert("Notification", $"Date: {currentDate} \nTime: {currentTime}", "Ok");
        }
    }
}