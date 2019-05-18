using Spotify.Uwp.Showcase.ViewModels;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Spotify.Uwp.Showcase.Pages
{
    /// <summary>
    /// Album Page
    /// </summary>
    public sealed partial class AlbumPage : Page, IDisposable
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AlbumPage() =>
            this.InitializeComponent();
        #endregion Constructor

        #region Event Handlers
        /// <summary>OnNavigatedTo</summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(
            NavigationEventArgs e) =>
                this.DataContext = new AlbumPageViewModel(
                SpotifySdk.Instance.SpotifySdkClient, (string)e.Parameter);
        #endregion Event Handlers

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() => 
            this.DataContext = null;
        #endregion Public Methods
    }
}
