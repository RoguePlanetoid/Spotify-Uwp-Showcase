using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// User Page View Model
    /// </summary>
    public class UserPageViewModel : BaseItemViewModel<UserResponse>
    {
        #region Public Properties
        /// <summary>
        /// User
        /// </summary>
        public ListPlaylistViewModel Playlists { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify SDK Client</param>
        /// <param name="userId">User Id</param>
        public UserPageViewModel(ISpotifySdkClient client, string userId) :
            base(client, userId)
        {
            Playlists = new ListPlaylistViewModel(client, PlaylistType.User, userId);
            // Command Actions
            client.CommandActions.Playlist = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}
