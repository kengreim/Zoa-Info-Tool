using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Core;

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
            if (runway is not null)
            {
                return runway.ToString();
            }
            else
            {
                return "Any";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
