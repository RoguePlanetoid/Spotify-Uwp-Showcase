using Spotify.NetStandard.Sdk;
using System;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase.Dialogs
{
    /// <summary>
    /// Add Playlist Item Dialog
    /// </summary>
    public sealed partial class AddPlaylistItemDialog : ContentDialog, IDisposable
    {
        #region Public Properties
        /// <summary>
        /// Add Playlist Item View Model
        /// </summary>
        public AddPlaylistItemDialogViewModel AddPlaylistItem { get; set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AddPlaylistItemDialog() =>
            InitializeComponent();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="playItemResponse">Playlist Response</param>
        public AddPlaylistItemDialog(IPlayItemResponse playItemResponse) : this() =>
            DataContext = AddPlaylistItem = new AddPlaylistItemDialogViewModel(
                SpotifySdk.Instance.Client, playItemResponse);
        #endregion Constructor

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            DataContext = null;
        #endregion Public Methods
    }
}
