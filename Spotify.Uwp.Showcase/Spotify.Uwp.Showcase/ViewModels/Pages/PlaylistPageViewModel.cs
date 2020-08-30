using Spotify.NetStandard.Sdk;
using Spotify.Uwp.Showcase.Dialogs;
using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Playlist Page View Model
    /// </summary>
    public class PlaylistPageViewModel : BaseItemViewModel<PlaylistResponse>
    {
        #region Private Methods
        /// <summary>
        /// Set Playlist Image
        /// </summary>
        /// <param name="response">Playlist Response</param>
        private async void SetPlaylistImage(PlaylistResponse response)
        {
            var dialog = new SetPlaylistImageDialog(response);
            var result = await dialog.ShowAsync();
            if(result == ContentDialogResult.Secondary)
                Refresh();
        }

        /// <summary>
        /// Set Playlist
        /// </summary>
        /// <param name="response">Playlist Response</param>
        private async void SetPlaylist(PlaylistResponse response)
        {
            var dialog = new PlaylistDialog(response);
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary && 
                dialog.SetPlaylist.Result.IsSuccess)
                Refresh();
        }

        /// <summary>
        /// Clear Playlist
        /// </summary>
        /// <param name="response">Playlist Response</param>
        private async void ClearPlaylist(PlaylistResponse response)
        {
            var dialog = new ClearPlaylistDialog(response);
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary &&
                dialog.ClearPlaylist.Result.IsSuccess)
                PlaylistItems.Refresh();
        }
        #endregion Private Methods

        #region Public Properties
        /// <summary>
        /// Playlist Items
        /// </summary>
        public ListPlaylistItemViewModel PlaylistItems { get; private set; }

        /// <summary>
        /// Clear Playlist
        /// </summary>
        public ICommand ClearPlaylistCommand { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="playlistId">Spotify Playlist Id</param>
        public PlaylistPageViewModel(ISpotifySdkClient client, string playlistId) :
            base(client, playlistId)
        {
            // Values
            PlaylistItems = new ListPlaylistItemViewModel(client, playlistId);
            // Command Actions
            client.CommandActions.Track = (item) => NavigatePage(item);
            client.CommandActions.Album = (item) => NavigatePage(item);
            client.CommandActions.Artist = (item) => NavigatePage(item);
            client.CommandActions.Playlist = (item) => NavigatePage(item);
            client.CommandActions.User = (item) => NavigatePage(item);
            client.CommandActions.SetPlaylistImage = (item) => SetPlaylistImage(item);
            client.CommandActions.SetPlaylist = (item) => SetPlaylist(item);
            client.CommandActions.RemovePlaylistItem = (item) => PlaylistItems.Remove(item);
            ClearPlaylistCommand = new GenericCommand<PlaylistResponse>(ClearPlaylist);
            // Events
            PlaylistItems.ResponseRemoved += (object sender, ResponseRemovedArgs<PlaylistItemResponse> e) =>
            {
                client.PlaylistItemResponseRemovedHandler(Item, e);
            };
            PlaylistItems.ResponseMoved += (object sender, ResponseMovedArgs e) =>
            {
                client.PlaylistItemResponseMovedHandler(Item, e);
            };
        }
        #endregion Constructor
    }
}
