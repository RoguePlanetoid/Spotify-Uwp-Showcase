using Spotify.NetStandard.Sdk;
using System.Collections.Generic;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Clear Playlist Dialog View Model
    /// </summary>
    public class ClearPlaylistDialogViewModel : BaseItemDialogViewModel<PlaylistResponse, StatusResponse>
    {
        #region Private Methods
        /// <summary>
        /// Clear Playlist
        /// </summary>
        /// <param name="playlistResponse">Playlist Response</param>
        private async void ClearPlaylist(PlaylistResponse playlistResponse) =>
            Result = await Client.SetPlaylistItemsAsync(playlistResponse.Id, 
                new List<AddPlaylistItemRequest>());
        #endregion Private Methods

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="playlist">Spotify Playlist</param>
        public ClearPlaylistDialogViewModel(ISpotifySdkClient client,
            PlaylistResponse playlist) :
            base(client, playlist) => 
            PrimaryCommand = new GenericCommand<PlaylistResponse>(ClearPlaylist);
        #endregion Constructor
    }
}
