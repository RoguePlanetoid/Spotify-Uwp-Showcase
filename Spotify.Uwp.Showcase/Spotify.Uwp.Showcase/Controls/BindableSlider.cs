using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Bindable Slider
    /// </summary>
    public class Slider : Windows.UI.Xaml.Controls.Slider
    {
        #region Private Members
        private bool _isStarted;
        #endregion Private Members

        #region Private Methods
        /// <summary>
        /// Slider Manipulation Starting
        /// </summary>
        /// <param name="sender">Slider</param>
        /// <param name="e">Manipulation Starting Routed Event Args</param>
        private void BindableSlider_ManipulationStarting(object sender,
            ManipulationStartingRoutedEventArgs e) =>
            _isStarted = true;

        /// <summary>
        /// Slider Manipulation Completed
        /// </summary>
        /// <param name="sender">Slider</param>
        /// <param name="e">Manipulation Starting Routed Event Args</param>
        private void BindableSlider_ManipulationCompleted(object sender,
            ManipulationCompletedRoutedEventArgs e)
        {
            if (_isStarted)
            {
                var slider = (Slider)sender;
                var value = (int)slider.Value;
                if(ValueChangedCommand != null)
                    ValueChangedCommand.Execute(value);
            }
            _isStarted = false;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="value">Value</param>
        private void Update(object value)
        {
            if (!_isStarted)
                Value = (int)value;
        }
        #endregion Private Methods

        #region Event Handlers
        private delegate void CurrentChangedHandler(object value);
        private static CurrentChangedHandler CurrentChanged;

        private static void OnCurrentChanged(DependencyObject obj,
           DependencyPropertyChangedEventArgs args) =>
           CurrentChanged?.Invoke(args.NewValue);
        #endregion Event Handlers

        #region Constructor
        /// <summary>
        /// Bindable Slider
        /// </summary>
        public Slider()
        {
            ManipulationMode = ManipulationModes.All;     
            ManipulationStarting += BindableSlider_ManipulationStarting;
            ManipulationCompleted += BindableSlider_ManipulationCompleted;
            CurrentChanged += new CurrentChangedHandler((object value) => 
                Update(value));
        }
        #endregion Constructor

        #region Dependancy Properties
        /// <summary>
        /// Value Changed Command
        /// </summary>
        public static DependencyProperty ValueChangedCommandProperty
            = DependencyProperty.Register(
                nameof(ValueChangedCommand),
                typeof(ICommand),
                typeof(Slider),
                new PropertyMetadata(null));

        /// <summary>
        /// Current
        /// </summary>
        public static DependencyProperty CurrentProperty
            = DependencyProperty.Register(
                nameof(Current),
                typeof(int),
                typeof(Slider),
                new PropertyMetadata(null, OnCurrentChanged));
        #endregion Dependancy Properties

        #region Public Properties
        /// <summary>
        /// Current
        /// </summary>
        public int Current
        {
            get => (int)GetValue(CurrentProperty);
            set => SetValue(CurrentProperty, value);
        }

        /// <summary>
        /// Value Changed Command
        /// </summary>
        public ICommand ValueChangedCommand
        {
            get => (ICommand)GetValue(ValueChangedCommandProperty);
            set => SetValue(ValueChangedCommandProperty, value);
        }
        #endregion Public Properties
    }
}
