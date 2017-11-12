using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HowYouSay.ValueConverters
{

	public class SelectedTabColorConverter : IValueConverter, IMarkupExtension
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
            var colors = ((string)parameter).Split((';'));
            var isSelected = (bool)value;
            return (isSelected) ? Color.FromHex(colors[0]) : Color.FromHex(colors[1]);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException("Only one way bindings are supported with this converter");
		}

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
