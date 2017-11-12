using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HowYouSay.ValueConverters
{

	public class InverseBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
            var isTrue = (bool)value;
			return !isTrue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException("Only one way bindings are supported with this converter");
		}

		
	}
}
