﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SciChart.Charting.Visuals.Annotations;
using System.Globalization;
namespace ModbusMaster
{
    public class AnnotationGetXCoordinateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var annotation = value as AnnotationBase;

            var xAxis = annotation.XAxis;
            var result = annotation.X1;

            if (xAxis != null && result != null)
            {
                var xCoordCalculator = xAxis.GetCurrentCoordinateCalculator();

                var position = xCoordCalculator == null ? (double)result : xCoordCalculator.GetCoordinate((double)result);
                position = Math.Round(position);

                result = position.ToString(culture) + " px";
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
