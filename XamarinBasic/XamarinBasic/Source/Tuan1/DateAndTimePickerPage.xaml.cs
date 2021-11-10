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

        private void ButtonProcess_Clicked(object sender, EventArgs e)
        {
            string currentDate = dpNgay.Date.ToString("dd/MM/yyyy");
            string currentTime = tpThoiGian.Time.ToString();
            DisplayAlert("Notification", $"Date: {currentDate} \nTime: {currentTime}", "Ok");
        }
    }
}