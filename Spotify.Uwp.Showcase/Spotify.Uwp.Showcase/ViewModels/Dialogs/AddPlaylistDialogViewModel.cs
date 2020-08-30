using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Add Playlist Dialog View Model
    /// </summary>
    public class AddPlaylistDialogViewModel : BaseItemDialogViewModel<AddPlaylistViewModel, PlaylistResponse>
    {
        #region Private Methods
        /// <summary>
        /// Add Playlist
        /// </summary>
        /// <param name="viewModel">Add Playlist View Model</param>
        private async void AddPlaylist(AddPlaylistViewModel viewModel) =>
            Result = await Client.AddPlaylistAsync(viewModel.ToAddPlaylistRequest());
        #endregion Private Methods

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Current User Response</param>
        public AddPlaylistDialogViewModel(ISpotifySdkClient client,
            CurrentUserResponse response) :
            base(client, new AddPlaylistViewModel(response))
        {
            // Commands
            PrimaryCommand = new GenericCommand<AddPlaylistViewModel>(AddPlaylist);
        }
        #endregion Constructor
    }
}
