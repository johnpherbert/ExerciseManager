using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using ExerciseManager.Models;
using System.Windows;

namespace ExerciseManager.Converters
{
    public class BasedOnAmountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility isvisible = Visibility.Collapsed;
            if (value != null)
            {
                isvisible = Visibility.Visible;
            }

            return isvisible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
