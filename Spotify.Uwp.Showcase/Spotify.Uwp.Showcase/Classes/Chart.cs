using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Spotify.Uwp.Showcase
{
    public class Chart : Grid
    {
        #region Private Members
        private const double circle = 360;
        private double _angle = 0;
        #endregion Private Members

        #region Private Methods
        public Point Compute(double angle, int hole)
        {
            double radians = (Math.PI / 180) * (angle - 90);
            double x = hole * Math.Cos(radians);
            double y = hole * Math.Sin(radians);
            return new Point(x += Radius, y += Radius);
        }

        private Path GetSector(SolidColorBrush fill, double sweep, int hole)
        {
            if (sweep == circle) sweep = 359;
            bool isLargeArc = sweep > 180.0;
            var innerArcStart = Compute(_angle, hole);
            var innerArcEnd = Compute(_angle + sweep, hole);
            var outerArcStart = Compute(_angle, Radius);
            var outerArcEnd = Compute(_angle + sweep, Radius);
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

        private SolidColorBrush Accent()
        {
            return new SolidColorBrush((Color)Application.Current.Resources["SystemAccentColor"]);
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
            this.Children.Clear();
            var sweep = value * Value;
            var sector = GetSector(Accent(), sweep, Hole);
            canvas.Children.Add(sector);
            var viewbox = new Viewbox()
            {
                Child = canvas
            };
            this.Children.Add(viewbox);
        }
        #endregion Private Methods

        #region Events
        /// <summary>
        /// On Value Changed
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        public static void OnValueChanged(DependencyObject obj,
            DependencyPropertyChangedEventArgs args) => 
            ValueChanged?.Invoke(obj);

        public delegate void ValueChangedHandler(object sender);
        public static ValueChangedHandler ValueChanged;
        #endregion Events

        #region Public Properties
        public static readonly DependencyProperty RadiusProperty =
        DependencyProperty.Register("Radius", typeof(int),
        typeof(Chart), new PropertyMetadata(100, OnValueChanged));

        public static readonly DependencyProperty HoleProperty =
        DependencyProperty.Register("Hole", typeof(int),
        typeof(Chart), new PropertyMetadata(50, OnValueChanged));

        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(int),
        typeof(Chart), new PropertyMetadata(0, OnValueChanged));

        public int Radius
        {
            get { return (int)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); Layout(); }
        }

        public int Hole
        {
            get { return (int)GetValue(HoleProperty); }
            set { SetValue(HoleProperty, value); Layout(); }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); Layout(); }
        }
        #endregion Public Properties

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Chart()
        {
            ValueChanged += new ValueChangedHandler((object sender) =>
            {
                if (this == ((Chart)sender))
                    Layout();
            });
        }
        #endregion Constructor
    }
}
