using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XamarinBasic.Converters
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int genderNumber = (int)value;
                if (genderNumber == 0)
                    return "Nam";
                else
                    return "Nữ";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "Nam";
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
