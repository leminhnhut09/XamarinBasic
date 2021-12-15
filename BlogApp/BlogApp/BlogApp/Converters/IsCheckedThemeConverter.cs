using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace BlogApp.Converters
{
    public class IsCheckedThemeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int theme = (int)value;
            var key = parameter as string;
            if(key != null)
            {
                if (key.Equals("system") && theme == 0)
                {
                    return true;
                }
                if (key.Equals("light") && theme == 1)
                {
                    return true;
                }
                if (key.Equals("dark") && theme == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
