using System;
using Windows.UI.Xaml.Data;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// String Format Convertor
    /// </summary>
    public class StringFormatConverter : IValueConverter
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var format = parameter as string;
            return !string.IsNullOrEmpty(format) ? string.Format(format, value) : value;
        }

        /// <summary>
        /// Convert Back
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language) => 
            throw new NotImplementedException();
    }
}
