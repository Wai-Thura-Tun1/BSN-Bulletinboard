using System;
using System.Globalization;
using System.Windows.Data;

namespace Bulletinboard.Front.AppLibrary
{
    public class iDateTimeConverter : IValueConverter
    {
        /// <summary>
        /// Convert 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>
        /// The <see cref="object?"/>
        /// </returns>
        object? IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fmtString = CommonLibrary.iConvert.ToString(parameter);

            return CommonLibrary.iConvert.ToDateTime(value);
        }

        /// <summary>
        /// Convert back
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>
        /// The <see cref="object?"/>
        /// </returns>
        object? IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CommonLibrary.iConvert.ToDateTimeNullable(value);
        }


    }

}
