using System;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.UI;

namespace SupportTicketTracker.Core.Converters
{
    public class ColorValueConverter : MvxValueConverter<int, MvxColor>
    {
        protected override MvxColor Convert(int value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new MvxColor(value);
        }
    }
}
