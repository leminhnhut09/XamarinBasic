using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XamarinBasic.Converters
{
    public class YearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? date = value as DateTime?;
            if(date != null)
            {
                return (int)date.Value.Year;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int year = int.Parse(value.ToString());
            DateTime dateTime = new DateTime(year, 1, 1);
            return dateTime;
        }
    }
}