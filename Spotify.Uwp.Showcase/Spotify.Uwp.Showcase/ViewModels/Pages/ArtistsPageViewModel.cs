using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Artists Page View Model
    /// </summary>
    public class ArtistsPageViewModel : BasePageViewModel
    {
        #region Public Properties
        /// <summary>
        /// Followed
        /// </summary>
        public ListArtistViewModel Followed { get; private set; }

        /// <summary>
        /// Top
        /// </summary>
        public ListArtistViewModel Top { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public ArtistsPageViewModel(ISpotifySdkClient client) :
            base(client)
        {
            Followed = new ListArtistViewModel(client, ArtistType.UserFollowed);
            Top = new ListArtistViewModel(client, ArtistType.UserTop);
            // Commands
            client.CommandActions.Artist = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}
