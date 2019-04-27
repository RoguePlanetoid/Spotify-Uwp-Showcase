using Spotify.Uwp.Showcase.ViewModels;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Spotify.Uwp.Showcase.Pages
{
    /// <summary>
    /// Recommended Page
    /// </summary>
    public sealed partial class RecommendedPage : Page, IDisposable
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RecommendedPage() =>
            this.InitializeComponent();
        #endregion Constructor

        #region Event Handlers
        /// <summary>OnNavigatedTo</summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(
            NavigationEventArgs e) =>
                this.DataContext = new RecommendedPageViewModel(
                SpotifySdk.Instance.SpotifySdkClient);
        #endregion Event Handlers

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            this.DataContext = null;
        #endregion Public Methods
    }
}
