using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MultipleSelection_ScatterPoints
{
    public class ScatterAngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var Value = value as ScatterSegment;
            if (Value != null)
            {
                var ydata = Value.YData;
                var angle = (ydata >= 25) ? 180 :0;

                return angle;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ScatterAdornmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var Value = value as ChartAdornment;
            if (Value != null)
            {
                var ydata = Value.YData;
                var variate = (Value.Item as StockModel).Variation;
                if (ydata >= 25)
                    return String.Format("+" + variate);
                return String.Format("-" + variate);
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ScatterInteriorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var Value = value as ScatterSegment;
            if (Value != null)
            {
                var ydata = Value.YData;
                Brush interior;

                interior = ydata >= 25 ? new SolidColorBrush(Color.FromArgb(0xFF, 0x2B, 0xD2, 0x6E)) :
                   new SolidColorBrush(Color.FromArgb(0xFF, 0xE3, 0x46, 0x5D)); ;

                return interior;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var Value = value as StockModel;
            if (Value != null)
            {
                var ydata = Value.Count;
                var variation = Value.Variation;

                if (ydata >= 25)
                    return String.Format("+" + variation);

                return String.Format("-" + variation);
            }

            return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
