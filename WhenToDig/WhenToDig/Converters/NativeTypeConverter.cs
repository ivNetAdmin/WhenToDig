using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WhenToDig.Converters
{
    public class NativeTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            // No format provided.
            if (parameter == null)
                return value;

            string[] parameters = parameter.ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string format = (parameters.Length > 1 ? parameters[1] : "");
            return this.FormatString(value, format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] parameters = parameter.ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string type = parameters[0];

            if (type == "Decimal")
                return decimal.Parse(value.ToString());
            if (type == "Int")
                return int.Parse(value.ToString());
            if (type == "DateTime")
                return DateTime.Parse(value.ToString());
            if (type == "DateTimeOffset")
                return DateTimeOffset.Parse(value.ToString());

            return value;
        }

        private string FormatString(object value, string format)
        {
            if (value != null && string.IsNullOrEmpty(format))
                return value.ToString();

            if(format== "DateTimeOffsetString")
                return DateTimeOffset.Parse(value.ToString()).ToString("dd-MM-yyyy");

            return string.Format(format, value);
        }
    }
}