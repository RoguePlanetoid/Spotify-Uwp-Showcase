using Spotify.NetStandard.Sdk;
using Spotify.Uwp.Showcase.Dialogs;
using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Playlists Page View Model
    /// </summary>
    public class PlaylistsPageViewModel : BasePageViewModel
    {
        #region Private Methods
        /// <summary>
        /// Add Playlist
        /// </summary>
        private async void AddPlaylist()
        {
            var current = await Client.GetCurrentUserAsync();
            var dialog = new PlaylistDialog(current);
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary && 
                dialog.AddPlaylist.Result.IsSuccess)
                NavigatePage(dialog.AddPlaylist.Result);
        }
        #endregion Private Methods

        #region Public Properties
        /// <summary>
        /// User
        /// </summary>
        public ListPlaylistViewModel Playlists { get; private set; }

        /// <summary>
        /// Add Playlist Command
        /// </summary>
        public ICommand AddPlaylistCommand { get; set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public PlaylistsPageViewModel(ISpotifySdkClient client) :
            base(client)
        {
            Playlists = new ListPlaylistViewModel(client, PlaylistType.CurrentUser);
            // Command Actions
            client.CommandActions.Playlist = (item) => NavigatePage(item);
            // Add Playlist
            AddPlaylistCommand = new RelayCommand(item => AddPlaylist());
        }
        #endregion Constructor
    }
}
