using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace ZOAHelper.Utils
{
    public static class Converters
    {
        public static GridLength GridLengthTrueEqualsStar(bool value)
        {
            return value ? new GridLength(1, GridUnitType.Star) : GridLength.Auto;
        }

        public static GridLength GridLengthTrueEqualsAuto(bool value)
        {
            return value ? GridLength.Auto : new GridLength(1, GridUnitType.Star);
        }
    }

    public class AliasRunwayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int? runway = (int?)value;
            return runway is not null ? runway.ToString() : "Any";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
