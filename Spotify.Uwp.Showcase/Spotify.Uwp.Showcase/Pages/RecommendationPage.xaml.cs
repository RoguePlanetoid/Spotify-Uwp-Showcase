using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Spotify.Uwp.Showcase.Pages
{
    /// <summary>
    /// Recommendation Page
    /// </summary>
    public sealed partial class RecommendationPage : Page, IDisposable
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RecommendationPage() =>
            InitializeComponent();
        #endregion Constructor

        #region Event Handlers
        /// <summary>OnNavigatedTo</summary>
        /// <param name="e">Navigation Event Args</param>
        protected override void OnNavigatedTo(
            NavigationEventArgs e) =>
                DataContext = new RecommendationPageViewModel(
                SpotifySdk.Instance.Client, (string)e.Parameter);
        #endregion Event Handlers

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            DataContext = null;
        #endregion Public Methods
    }
}
