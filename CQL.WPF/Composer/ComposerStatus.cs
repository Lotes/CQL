using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CQL.WPF.Composer
{
    public enum ComposerStatus
    {
        Uninitialized,
        CanNotDisplay,
        Ok
    }

    [ValueConversion(typeof(ComposerStatus), typeof(bool))]
    public class ComposerStatusToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(ComposerStatus.Ok);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
