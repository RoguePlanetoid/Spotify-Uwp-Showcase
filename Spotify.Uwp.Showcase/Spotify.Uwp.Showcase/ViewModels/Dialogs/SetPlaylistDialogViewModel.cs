using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Set Playlist Dialog View Model
    /// </summary>
    public class SetPlaylistDialogViewModel : BaseItemDialogViewModel<SetPlaylistViewModel, StatusResponse>
    {
        #region Private Methods
        /// <summary>
        /// Set Playlist
        /// </summary>
        /// <param name="viewModel">Set Playlist View Model</param>
        private async void SetPlaylist(SetPlaylistViewModel viewModel) =>
            Result = await Client.SetPlaylistAsync(viewModel.ToSetPlaylistRequest());
        #endregion Private Methods

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Playlist Response</param>
        public SetPlaylistDialogViewModel(ISpotifySdkClient client, 
            PlaylistResponse response) :
            base(client, new SetPlaylistViewModel(response))
        {
            // Commands
            PrimaryCommand = new GenericCommand<SetPlaylistViewModel>(SetPlaylist);
        }
        #endregion Constructor
    }
}
