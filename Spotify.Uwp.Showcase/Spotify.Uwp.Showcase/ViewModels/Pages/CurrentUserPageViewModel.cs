using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Current User Page View Model
    /// </summary>
    public class CurrentUserPageViewModel : BaseItemViewModel<CurrentUserResponse>
    {
        #region Public Properties
        /// <summary>
        /// Current User Addable
        /// </summary>
        public ListPlaylistViewModel Playlists { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public CurrentUserPageViewModel(ISpotifySdkClient client) :
            base(client)
        {
            Playlists = new ListPlaylistViewModel(client, PlaylistType.CurrentUserAddable);
            // Command Actions
            client.CommandActions.Playlist = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}
