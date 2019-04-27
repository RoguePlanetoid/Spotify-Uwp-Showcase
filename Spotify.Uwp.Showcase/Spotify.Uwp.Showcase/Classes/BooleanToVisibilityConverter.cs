using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Spotify.Uwp.Showcase
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language) =>
            (bool)value ? Visibility.Visible : Visibility.Collapsed;

        /// <summary>
        /// Convert Back
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language) =>
            (Visibility)value == Visibility.Visible;
    }
}
