using BlogApp.Helpers;
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
            int? theme = value as int?;
            var key = parameter as string;
            if(key != null && theme != null)
            {
                if (key.Equals(ContainsKey.ThemeSystemKey) && theme == 0)
                {
                    return true;
                }
                if (key.Equals(ContainsKey.ThemeLightKey) && theme == 1)
                {
                    return true;
                }
                if (key.Equals(ContainsKey.ThemeDarkKey) && theme == 2)
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
