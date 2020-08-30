using Spotify.NetStandard.Sdk;
using System;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase.Dialogs
{
    /// <summary>
    /// Set Playlist Image Dialog
    /// </summary>
    public sealed partial class SetPlaylistImageDialog : ContentDialog, IDisposable
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SetPlaylistImageDialog() => 
            InitializeComponent();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="playlistResponse">Playlist Response</param>
        public SetPlaylistImageDialog(PlaylistResponse playlistResponse) : this() => 
            DataContext = new SetPlaylistImageDialogViewModel(
                SpotifySdk.Instance.Client, playlistResponse);
        #endregion Constructor

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            DataContext = null;
        #endregion Public Methods
    }
}
