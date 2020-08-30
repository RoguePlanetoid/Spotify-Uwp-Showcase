using Spotify.NetStandard.Sdk;
using System;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase.Dialogs
{
    /// <summary>
    /// Playlist Dialog
    /// </summary>
    public sealed partial class PlaylistDialog : ContentDialog, IDisposable
    {
        #region Public Properties
        /// <summary>
        /// Set Playlist Dialog View Model
        /// </summary>
        public SetPlaylistDialogViewModel SetPlaylist { get; set; }

        /// <summary>
        /// Add Playlist Dialog View Model
        /// </summary>
        public AddPlaylistDialogViewModel AddPlaylist { get; set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public PlaylistDialog() =>
            InitializeComponent();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="playlistResponse">Playlist Response</param>
        public PlaylistDialog(PlaylistResponse playlistResponse) : this() => 
            DataContext = SetPlaylist = new SetPlaylistDialogViewModel(
                SpotifySdk.Instance.Client, playlistResponse);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="currentUserResponse">Current User Response</param>
        public PlaylistDialog(CurrentUserResponse currentUserResponse) : this() =>
            DataContext = AddPlaylist = new AddPlaylistDialogViewModel(
                SpotifySdk.Instance.Client, currentUserResponse);
        #endregion Constructor

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            DataContext = null;
        #endregion Public Methods
    }
}
