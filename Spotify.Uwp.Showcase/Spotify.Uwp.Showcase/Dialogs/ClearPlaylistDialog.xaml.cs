using Spotify.NetStandard.Sdk;
using System;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase.Dialogs
{
    /// <summary>
    /// Clear Playlist Dialog
    /// </summary>
    public sealed partial class ClearPlaylistDialog : ContentDialog, IDisposable
    {
        #region Public Properties
        /// <summary>
        /// Clear Playlist Dialog View Model
        /// </summary>
        public ClearPlaylistDialogViewModel ClearPlaylist { get; set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ClearPlaylistDialog() =>
            InitializeComponent();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="playlistResponse">Playlist Response</param>
        public ClearPlaylistDialog(PlaylistResponse playlistResponse) : this() =>
            DataContext = ClearPlaylist = new ClearPlaylistDialogViewModel(
                SpotifySdk.Instance.Client, playlistResponse);
        #endregion Constructor

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            DataContext = null;
        #endregion Public Methods
    }
}
