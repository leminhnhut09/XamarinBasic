using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinEntity.Converters
{
    public class ReverseGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var result = Boolean.Parse(value.ToString());
                return result == false ? "Nam" : "Nữ";
            }
            catch
            {
                return "Nam";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var result = value as string;
                return result == "Nam" ? false : true;
            }
            catch
            {
                return true;
            }
        }
    }
}
