using Spotify.Uwp.Showcase.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Spotify.Uwp.Showcase.Pages
{
    /// <summary>
    /// User Playlists
    /// </summary>
    public sealed partial class UserPlaylistsPage : Page
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public UserPlaylistsPage() =>
            this.InitializeComponent();
        #endregion Constructor

        #region Event Handlers
        /// <summary>OnNavigatedTo</summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(
            NavigationEventArgs e) =>
                this.DataContext = new UserPlaylistsPageViewModel(
                    SpotifySdk.Instance.SpotifySdkClient);
        #endregion Event Handlers

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            this.DataContext = null;
        #endregion Public Methods
    }
}
