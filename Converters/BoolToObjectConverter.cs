using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Microsoft.Extensions.DependencyModel;

namespace Aigul.Converters;

public class BoolToObjectConverter : IValueConverter
{
    public object? TrueObject
    {
        get; set;
    }

    public object? FalseObject
    {
        get; set;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var boolValue = (value as bool?) ?? false;
        return boolValue ? TrueObject : FalseObject;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;
}
