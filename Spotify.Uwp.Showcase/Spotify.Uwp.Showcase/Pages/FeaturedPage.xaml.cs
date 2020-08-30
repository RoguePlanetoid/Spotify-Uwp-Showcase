using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Spotify.Uwp.Showcase.Pages
{
    /// <summary>
    /// Featured Page
    /// </summary>
    public sealed partial class FeaturedPage : Page, IDisposable
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FeaturedPage() =>
            InitializeComponent();
        #endregion Constructor

        #region Event Handlers
        /// <summary>OnNavigatedTo</summary>
        /// <param name="e">Navigation Event Args</param>
        protected override void OnNavigatedTo(
            NavigationEventArgs e) =>
                DataContext = new FeaturedPageViewModel(
                SpotifySdk.Instance.Client);
        #endregion Event Handlers

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            DataContext = null;
        #endregion Public Methods
    }
}
