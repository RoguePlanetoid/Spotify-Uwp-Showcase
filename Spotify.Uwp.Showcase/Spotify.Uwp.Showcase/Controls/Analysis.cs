using Spotify.NetStandard.Sdk;
using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Analysis Display
    /// </summary>
    public class Analysis : Canvas
    {
        #region Private Class
        /// <summary>
        /// Analysis Item
        /// </summary>
        private class AnalysisItem
        {
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="start">Start</param>
            /// <param name="duration">Duration</param>
            public AnalysisItem(float? start, float? duration)
            {
                Start = start ?? 0;
                Duration = duration ?? 0;
            }

            /// <summary>
            /// Start
            /// </summary>
            public double Start { get; set; }

            /// <summary>
            /// Duration
            /// </summary>
            public double Duration { get; set; }
        }
        #endregion Private Class

        /// <summary>
        /// Colours
        /// </summary>
        public readonly Color[] colours =
        {
            Color.FromArgb(230, 0, 215, 96),
            Color.FromArgb(230, 245, 115, 160),
            Color.FromArgb(230, 80, 155, 245),
            Color.FromArgb(230, 255, 100, 55),
            Color.FromArgb(230, 180, 155, 200),
            Color.FromArgb(230, 250, 230, 45),
            Color.FromArgb(230, 0, 100, 80),
            Color.FromArgb(75, 40, 150, 160),
            Color.FromArgb(30, 50, 100, 160)
        };

        #region Private Methods
        /// <summary>
        /// Get Items
        /// </summary>
        /// <param name="response">Audio Analysis Response</param>
        /// <returns>Dictionary of String, List of Analysis Item</returns>
        private Dictionary<string, List<AnalysisItem>> GetItems(
            AudioAnalysisResponse response) => new Dictionary<string, List<AnalysisItem>>
            {
                {
                    nameof(response.Sections),
                    response.Sections.Select(section => 
                        new AnalysisItem(section.Start, section.Duration)).ToList()
                },
                {
                    nameof(response.Bars),
                    response.Bars.Select(bar => 
                        new AnalysisItem(bar.Start, bar.Duration)).ToList()
                },
                {
                    nameof(response.Beats),
                    response.Beats.Select(beat =>
                        new AnalysisItem(beat.Start, beat.Duration)).ToList()
                },
                {
                    nameof(response.Tatums),
                    response.Tatums.Select(tatum =>
                        new AnalysisItem(tatum.Start, tatum.Duration)).ToList()
                },
                {
                    nameof(response.Segments),
                    response.Segments.Select(segment =>
                        new AnalysisItem(segment.Start, segment.Duration)).ToList()
                }
            };

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            if (Value != null)
            {
                var height = Height;
                var dict = GetItems(Value);
                double rowHeight = height / dict.Count();
                for (int row = 0; row < dict.Count(); row++)
                {
                    double itemHeight = rowHeight / (row + 1);
                    var element = dict.ElementAt(row);
                    for (int col = 0; col < element.Value.Count(); col++)
                    {
                        var item = element.Value[col];
                        var fill = new SolidColorBrush(colours[col % colours.Length]);
                        var rect = new Rectangle()
                        {
                            Width = item.Duration,
                            Height = itemHeight,
                            Fill = fill
                        };
                        var left = item.Start;
                        var top = row == 0 ? 0 : row * itemHeight;
                        SetLeft(rect, left);
                        SetTop(rect, top);
                        Children.Add(rect);
                    }
                }
            }
        }
        #endregion Private Methods

        #region Event Handlers
        private delegate void ValueChangedHandler(object sender);
        private static ValueChangedHandler ValueChanged;

        private static void OnValueChanged(DependencyObject obj,
           DependencyPropertyChangedEventArgs args) =>
           ValueChanged?.Invoke(obj);
        #endregion Event Handlers

        #region Dependency Properties
        /// <summary>
        /// Value Property
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(AudioAnalysisResponse),
        typeof(Analysis), new PropertyMetadata(null, OnValueChanged));
        #endregion Dependancy Property

        #region Public Properties
        /// <summary>
        /// Audio Analysis Response
        /// </summary>
        public AudioAnalysisResponse Value
        {
            get => (AudioAnalysisResponse)GetValue(ValueProperty);
            set { SetValue(ValueProperty, value); }
        }
        #endregion Public Properties

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Analysis() =>
            ValueChanged += new ValueChangedHandler((object sender) =>
            {
                if (this == ((Analysis)sender))
                    Update();
            });
        #endregion Constructor
    }
}
