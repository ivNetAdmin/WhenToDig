using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace WhenToDig.Converters
{
    public class AlternatingHighlightColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color rowcolor = Color.Transparent;
            if (value == null || parameter == null) return Color.White;
            var index = ((ListView)parameter).ItemsSource.Cast<object>().ToList().IndexOf(value);
            if (index % 2 == 0)
            {
                rowcolor = Color.AntiqueWhite;
            }
            return rowcolor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
