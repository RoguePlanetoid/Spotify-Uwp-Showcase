using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Featured Page View Model
    /// </summary>
    public class FeaturedPageViewModel : BasePageViewModel
    {
        #region Public Properties
        /// <summary>
        /// Featured Playlists
        /// </summary>
        public ListPlaylistViewModel Featured { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public FeaturedPageViewModel(ISpotifySdkClient client) :
            base(client)
        {
            Featured = new ListPlaylistViewModel(client, PlaylistType.Featured);
            // Command Action
            client.CommandActions.Playlist = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}