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
        const string LIST_COLOR = "#f2f2f2";
        const string ALTERNATE_COLOR = "#e6e6e6";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color rowcolor = Color.FromHex(LIST_COLOR);
            if (value == null || parameter == null) return Color.White;
            var index = ((ListView)parameter).ItemsSource.Cast<object>().ToList().IndexOf(value);
            if (index % 2 == 0)
            {
                rowcolor = rowcolor = Color.FromHex(ALTERNATE_COLOR);
            }
            return rowcolor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
