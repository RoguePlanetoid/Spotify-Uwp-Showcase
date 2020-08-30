using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Donut Chart
    /// </summary>
    public class Donut : Grid
    {
        #region Private Members
        private const double circle = 360;
        private double _angle = 0;
        #endregion Private Members

        #region Private Methods
        /// <summary>
        /// Get Point
        /// </summary>
        /// <param name="angle">Angle</param>
        /// <param name="hole">Hole</param>
        /// <returns>Point</returns>
        public Point GetPoint(double angle, int hole)
        {
            double radians = (Math.PI / 180) * (angle - 90);
            double x = hole * Math.Cos(radians);
            double y = hole * Math.Sin(radians);
            return new Point(x += Radius, y += Radius);
        }

        /// <summary>
        /// Get Path
        /// </summary>
        /// <param name="fill">Fill Brush</param>
        /// <param name="sweep">Sweep Angle</param>
        /// <param name="hole">Hole Size</param>
        /// <returns>Path</returns>
        private Path GetPath(Brush fill, double sweep, int hole)
        {
            if (sweep == circle) sweep = 359;
            bool isLargeArc = sweep > 180.0;
            var innerArcStart = GetPoint(_angle, hole);
            var innerArcEnd = GetPoint(_angle + sweep, hole);
            var outerArcStart = GetPoint(_angle, Radius);
            var outerArcEnd = GetPoint(_angle + sweep, Radius);
            var outerArcSize = new Size(Radius, Radius);
            var innerArcSize = new Size(hole, hole);
            var lineOne = new LineSegment()
            {
                Point = outerArcStart
            };
            var arcOne = new ArcSegment()
            {
                SweepDirection = SweepDirection.Clockwise,
                IsLargeArc = isLargeArc,
                Point = outerArcEnd,
                Size = outerArcSize
            };
            var lineTwo = new LineSegment()
            {
                Point = innerArcEnd
            };
            var arcTwo = new ArcSegment()
            {
                SweepDirection = SweepDirection.Counterclockwise,
                IsLargeArc = isLargeArc,
                Point = innerArcStart,
                Size = innerArcSize
            };
            var figure = new PathFigure()
            {
                StartPoint = innerArcStart,
                IsClosed = true,
                IsFilled = true
            };
            figure.Segments.Add(lineOne);
            figure.Segments.Add(arcOne);
            figure.Segments.Add(lineTwo);
            figure.Segments.Add(arcTwo);
            var pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(figure);
            var path = new Path
            {
                Fill = fill,
                Data = pathGeometry
            };
            _angle += sweep;
            return path;
        }

        private void Layout()
        {
            _angle = 0;
            double total = 100;
            double value = (circle / total);
            var canvas = new Canvas()
            {
                Width = Radius * 2,
                Height = Radius * 2
            };
            Children.Clear();
            var sweep = value * Value;
            var sector = GetPath(Fill, sweep, Hole);
            canvas.Children.Add(sector);
            var viewbox = new Viewbox()
            {
                Child = canvas
            };
            Children.Add(viewbox);
        }
        #endregion Private Methods

        #region Events
        /// <summary>
        /// On Value Changed
        /// </summary>
        /// <param name="obj">Dependency Object</param>
        /// <param name="args">Dependency Property Changed Event Args</param>
        public static void OnValueChanged(DependencyObject obj,
            DependencyPropertyChangedEventArgs args) =>
            ValueChanged?.Invoke(obj);

        /// <summary>
        /// Value Changed Handler
        /// </summary>
        /// <param name="sender">Object</param>
        public delegate void ValueChangedHandler(object sender);

        /// <summary>
        /// Value Changed Handler
        /// </summary>
        public static ValueChangedHandler ValueChanged;
        #endregion Events

        #region Public Properties
        /// <summary>
        /// Radius Property
        /// </summary>
        public static readonly DependencyProperty RadiusProperty =
        DependencyProperty.Register(nameof(Radius), typeof(int),
        typeof(Donut), new PropertyMetadata(100, OnValueChanged));

        /// <summary>
        /// Hold Property
        /// </summary>
        public static readonly DependencyProperty HoleProperty =
        DependencyProperty.Register(nameof(Hole), typeof(int),
        typeof(Donut), new PropertyMetadata(50, OnValueChanged));

        /// <summary>
        /// Value Property
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(int),
        typeof(Donut), new PropertyMetadata(0, OnValueChanged));

        /// <summary>
        /// Fill Property
        /// </summary>
        public static readonly DependencyProperty FillProperty =
        DependencyProperty.Register(nameof(Fill), typeof(Brush),
        typeof(Donut), new PropertyMetadata(Colors.Black, OnValueChanged));

        /// <summary>
        /// Radius
        /// </summary>
        public int Radius
        {
            get => (int)GetValue(RadiusProperty);
            set { SetValue(RadiusProperty, value); Layout(); }
        }

        /// <summary>
        /// Hole
        /// </summary>
        public int Hole
        {
            get => (int)GetValue(HoleProperty);
            set { SetValue(HoleProperty, value); Layout(); }
        }

        /// <summary>
        /// Value
        /// </summary>
        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set { SetValue(ValueProperty, value); Layout(); }
        }

        /// <summary>
        /// Fill
        /// </summary>
        public Brush Fill
        {
            get => (Brush)GetValue(FillProperty);
            set { SetValue(FillProperty, value); Layout(); }
        }
        #endregion Public Properties

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Donut() => 
            ValueChanged += new ValueChangedHandler((object sender) =>
            {
                if (this == ((Donut)sender))
                    Layout();
            });
        #endregion Constructor
    }
}